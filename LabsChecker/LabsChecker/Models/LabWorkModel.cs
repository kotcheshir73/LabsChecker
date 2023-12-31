namespace LabsChecker.Models;

/// <summary>
/// Лабораторная работа
/// </summary>
public class LabWorkModel
{
	/// <summary>
	/// Название работы
	/// </summary>
	public string LabWorkTitle { get; set; } = string.Empty;

	/// <summary>
	/// Перечень возможных требвоания по работе
	/// </summary>
	public List<TaskModel> Tasks { get; set; } = [];
}