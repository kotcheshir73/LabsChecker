namespace LabsChecker.Models;

/// <summary>
/// Единица проверки лабораторной работы
/// </summary>
public class LabWorkCheckItemModel
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	public Guid Id { get; set; } = Guid.NewGuid();

	/// <summary>
	/// Описание требования
	/// </summary>
	public string Requirement { get; set; } = string.Empty;

	/// <summary>
	/// Где смотреть
	/// </summary>
	public string CheckList { get; set; } = string.Empty;

	/// <summary>
	/// Перечень встречаемых ошибок оформления кода
	/// </summary>
	public List<string> ErrorList { get; set; } = [];
}