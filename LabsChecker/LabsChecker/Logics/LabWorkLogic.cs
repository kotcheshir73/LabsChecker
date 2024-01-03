using LabsChecker.Extenstions;
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

	private List<LabWorkModel>? _labWorkList = null;

	private LabWorkCheckBlockModel? _copyBlock = null;

	private List<LabWorkModel> LabWorkList
	{
		get
		{
			_labWorkList ??= LoadData();
			return _labWorkList;
		}
	}

	public IEnumerable<string> GetTitles => LabWorkList.Select(x => x.LabWorkTitle);

	public LabWorkModel? this[string? key] => string.IsNullOrEmpty(key) ? null :
		LabWorkList.FirstOrDefault(x => x.LabWorkTitle == key);

	public IEnumerable<LabWorkCheckBlockModel>? GetBlocks(string key) => string.IsNullOrEmpty(key) ? null :
		LabWorkList.FirstOrDefault(x => x.LabWorkTitle == key)?.Blocks;

	public IEnumerable<LabWorkCheckItemModel>? GetItems(string key, Guid blockId) =>
		GetBlocks(key)?.FirstOrDefault(x => x.Id == blockId)?.Items;

	public void SaveData()
	{
		if (LabWorkList == null)
		{
			throw new InvalidOperationException("Список пуст, сохранять нечего");
		}

		var fileName = _configuration.GetSection("DataFileName")?.Value;
		if (string.IsNullOrEmpty(fileName))
		{
			throw new InvalidOperationException("Не задан файл с данными по лабораторным работам");
		}

		File.WriteAllText(fileName, JsonConvert.SerializeObject(LabWorkList));
	}

	public void InsertLabWork(LabWorkModel? newItem)
	{
		ArgumentNullException.ThrowIfNull(newItem);

		if (newItem.LabWorkTitle.IsNullOrEmpty())
		{
			throw new InvalidOperationException("Необходимо задать название работы");
		}

		if (LabWorkList.Any(x => x.LabWorkTitle == newItem.LabWorkTitle))
		{
			throw new InvalidOperationException("Уже есть работа с таким названием");
		}

		LabWorkList.Add(newItem);
	}

	public void UpdateLabWorkName(Guid id, string newName)
	{
		if (newName.IsNullOrEmpty())
		{
			throw new ArgumentNullException(nameof(newName));
		}

		if (LabWorkList.Any(x => x.LabWorkTitle == newName))
		{
			throw new InvalidOperationException("Уже есть работа с таким названием");
		}

		var item = LabWorkList.FirstOrDefault(x => x.Id == id) ??
			throw new InvalidOperationException($"Не найдена работа пл ключу {id}");

		item.LabWorkTitle = newName;
	}

	public void DeleteLabWorkByKey(string? key)
	{
		if (key.IsNullOrEmpty())
		{
			throw new ArgumentNullException(nameof(key));
		}

		if (LabWorkList == null || LabWorkList.Count == 0)
		{
			throw new InvalidOperationException("Список пуст, удалять нечего");
		}

		var item = this[key] ?? throw new InvalidOperationException($"Не найден элемент по ключу {key}");
		LabWorkList.Remove(item);
	}

	public void InsertCheckBlock(string key, string blockName)
	{
		if (key.IsNullOrEmpty())
		{
			throw new ArgumentNullException(nameof(key));
		}

		if (blockName.IsNullOrEmpty())
		{
			throw new ArgumentNullException(nameof(blockName));
		}

		var labWork = LabWorkList.FirstOrDefault(x => x.LabWorkTitle == key) ?? throw new InvalidOperationException("Нет работы с таким названием");
		var blocks = labWork.Blocks ?? throw new InvalidOperationException("Нет блоков по этой работе");
		if (blocks.Any(x => x.BlockTitle == blockName))
		{
			throw new InvalidOperationException("Уже есть блок с таким названием");
		}

		blocks.Add(new LabWorkCheckBlockModel { BlockTitle = blockName });
	}

	public void UpdateCheckBlock(string key, Guid? id, string blockName)
	{
		if (key.IsNullOrEmpty())
		{
			throw new ArgumentNullException(nameof(key));
		}

		if (!id.HasValue)
		{
			throw new ArgumentNullException(nameof(id));
		}

		if (blockName.IsNullOrEmpty())
		{
			throw new ArgumentNullException(nameof(blockName));
		}

		var labWork = LabWorkList.FirstOrDefault(x => x.LabWorkTitle == key) ?? throw new InvalidOperationException("Нет работы с таким названием");
		var blocks = labWork.Blocks ?? throw new InvalidOperationException("Нет блоков по этой работе");
		if (blocks.Any(x => x.BlockTitle == blockName))
		{
			throw new InvalidOperationException("Уже есть блок с таким названием");
		}

		var block = blocks.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"Не найден блок по идентификатору {id}");
		block.BlockTitle = blockName;
	}

	public void DeleteCheckBlock(string key, Guid? id)
	{
		if (key.IsNullOrEmpty())
		{
			throw new ArgumentNullException(nameof(key));
		}

		if (!id.HasValue)
		{
			throw new ArgumentNullException(nameof(id));
		}

		var labWork = LabWorkList.FirstOrDefault(x => x.LabWorkTitle == key) ?? throw new InvalidOperationException("Нет работы с таким названием");
		var blocks = labWork.Blocks ?? throw new InvalidOperationException("Нет блоков по этой работе");

		var block = blocks.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"Не найден блок по идентификатору {id}");
		blocks.Remove(block);
	}

	public void CopyBlock(string key, Guid? id)
	{
		if (key.IsNullOrEmpty())
		{
			throw new ArgumentNullException(nameof(key));
		}

		if (!id.HasValue)
		{
			throw new ArgumentNullException(nameof(id));
		}

		var labWork = LabWorkList.FirstOrDefault(x => x.LabWorkTitle == key) ?? throw new InvalidOperationException("Нет работы с таким названием");
		var blocks = labWork.Blocks ?? throw new InvalidOperationException("Нет блоков по этой работе");
		_copyBlock = blocks.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException($"Не найден блок по идентификатору {id}");
	}

	public void PasteBlock(string key)
	{
		if (key.IsNullOrEmpty())
		{
			throw new ArgumentNullException(nameof(key));
		}

		if (_copyBlock == null)
		{
			throw new InvalidOperationException("Нет скопированного блока");
		}

		var labWork = LabWorkList.FirstOrDefault(x => x.LabWorkTitle == key) ?? throw new InvalidOperationException("Нет работы с таким названием");
		var blocks = labWork.Blocks ?? throw new InvalidOperationException("Нет блоков по этой работе");
		var newBlock = _copyBlock.Copy();
		while (blocks.Any(x => x.BlockTitle == newBlock.BlockTitle))
		{
			newBlock.BlockTitle = $"{newBlock.BlockTitle}+";
		}

		blocks.Add(newBlock);
	}

	public void FixItem(string key, Guid blockId, Guid itemId, string requirement, string checkList,
		IEnumerable<string> errorList)
	{
		if (key.IsNullOrEmpty())
		{
			throw new ArgumentNullException(nameof(key));
		}

		if (requirement.IsNullOrEmpty())
		{
			throw new ArgumentNullException(nameof(requirement));
		}

		var labWork = LabWorkList.FirstOrDefault(x => x.LabWorkTitle == key) ?? throw new InvalidOperationException("Нет работы с таким названием");
		var blocks = labWork.Blocks ?? throw new InvalidOperationException("Нет блоков по этой работе");
		var block = blocks.FirstOrDefault(x => x.Id == blockId) ?? throw new InvalidOperationException($"Не найден блок по идентификатору {blockId}");
		var item = block.Items.FirstOrDefault(x => x.Id == itemId);
		if (item == null)
		{
			item = new() { Id = itemId };
			block.Items.Add(item);
		}

		item.Requirement = requirement;
		item.CheckList = checkList;
		item.ErrorList = errorList.ToList();
	}

	public void DelItem(string key, Guid blockId, Guid itemId)
	{
		if (key.IsNullOrEmpty())
		{
			throw new ArgumentNullException(nameof(key));
		}

		var labWork = LabWorkList.FirstOrDefault(x => x.LabWorkTitle == key) ?? throw new InvalidOperationException("Нет работы с таким названием");
		var blocks = labWork.Blocks ?? throw new InvalidOperationException("Нет блоков по этой работе");
		var block = blocks.FirstOrDefault(x => x.Id == blockId) ?? throw new InvalidOperationException($"Не найден блок по идентификатору {blockId}");
		var item = block.Items.FirstOrDefault(x => x.Id == itemId) ?? throw new InvalidOperationException($"Не найден элемент блока по идентификатору {itemId}");
		block.Items.Remove(item);
	}

	private List<LabWorkModel> LoadData()
	{
		var fileName = _configuration.GetSection("DataFileName")?.Value;
		if (string.IsNullOrEmpty(fileName))
		{
			throw new InvalidOperationException("Не задан файл с данными по лабораторным работам");
		}

		return File.Exists(fileName) ?
			JsonConvert.DeserializeObject<List<LabWorkModel>>(File.ReadAllText(fileName)) ?? [] :
			([]);
	}
}