namespace LabsChecker.Models;

/// <summary>
/// Модель описания ошибки в проверяемой работе
/// </summary>
public class ErrorModel : ICloneable
{
	/// <summary>
	/// Идентификатор
	/// </summary>
	public Guid Id { get; set; } = Guid.NewGuid();

	/// <summary>
	/// Текст ошибки
	/// </summary>
	public string Text { get; set; } = string.Empty;

	/// <summary>
	/// Вес ошибки
	/// </summary>
	public double Weight { get; set; }

	/// <summary>
	/// Признак, что наличие этой ошибки обозначает работу непверно оформленной
	/// </summary>
	public bool IsStop { get; set; }

	/// <summary>
	/// Создание дубликата
	/// </summary>
	/// <returns></returns>
	public object Clone()
	{
		return MemberwiseClone();
	}
}