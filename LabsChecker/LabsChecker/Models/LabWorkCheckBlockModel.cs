namespace LabsChecker.Models;

/// <summary>
/// Блок проверки лабораторной работы
/// </summary>
public class LabWorkCheckBlockModel
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	public Guid Id { get; set; } = Guid.NewGuid();

	/// <summary>
	/// Заголовок
	/// </summary>
	public string BlockTitle { get; set; } = string.Empty;

	/// <summary>
	/// Элементы
	/// </summary>
	public List<LabWorkCheckItemModel> Items { get; set; } = [];
}