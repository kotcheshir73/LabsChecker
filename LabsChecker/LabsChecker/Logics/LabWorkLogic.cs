using LabsChecker.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace LabsChecker.Logics;

/// <summary>
/// Логика работы с лабораторынми работами
/// </summary>
public class LabWorkLogic(IConfiguration configuration)
{
	private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

	private bool _isLoad = false;

	private List<LabWorkModel>? _labWorkList = null;

	public List<LabWorkModel> LabWorkList
	{
		get
		{
			if (!_isLoad)
			{
				LoadData();
			}

			return _labWorkList ??= [];
		}
	}

	public void LoadData()
	{
		var fileName = _configuration.GetSection("DataFileName")?.Value;
		if (string.IsNullOrEmpty(fileName))
		{
			throw new InvalidOperationException("Не задан файл с данными по лабораторным работам");
		}

		_labWorkList = File.Exists(fileName) ? 
			JsonConvert.DeserializeObject<List<LabWorkModel>>(File.ReadAllText(fileName)) : 
			([]);

		_isLoad = true;
	}

	public void SaveData()
	{
		if (_labWorkList == null)
		{
			throw new InvalidOperationException("Список пуст, сохранять нечего");
		}

		var fileName = _configuration.GetSection("DataFileName")?.Value;
		if (string.IsNullOrEmpty(fileName))
		{
			throw new InvalidOperationException("Не задан файл с данными по лабораторным работам");
		}

		File.WriteAllText(fileName, JsonConvert.SerializeObject(_labWorkList));
	}
}