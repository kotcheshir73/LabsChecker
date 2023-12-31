namespace LabsChecker.Models;

/// <summary>
/// Блок лаборатороной работы
/// </summary>
public class TaskModel : ICloneable
{
	/// <summary>
	/// Заголовок
	/// </summary>
	public string TaskTitle { get; set; } = string.Empty;

	/// <summary>
	/// Требования
	/// </summary>
	public List<string> Requirements { get; set; } = [];

	/// <summary>
	/// Что смотреть по коду
	/// </summary>
	public List<string> CheckList { get; set; } = [];

	/// <summary>
	/// Перечень встречаемых ошибок оформления
	/// </summary>
	public List<ErrorModel> ErrorList { get; set; } = [];

	/// <summary>
	/// Создание дубликата
	/// </summary>
	/// <returns></returns>
	public object Clone()
	{
		return new TaskModel()
		{
			TaskTitle = TaskTitle,
			Requirements = new List<string>(Requirements),
			CheckList = new List<string>(CheckList),
			ErrorList = new List<ErrorModel>(ErrorList.Select(x => (ErrorModel)x.Clone()))
		};
	}
}