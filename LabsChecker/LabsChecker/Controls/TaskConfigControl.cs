using LabsChecker.Models;
using System.Collections.Generic;
using System.Data;

namespace LabsChecker.Controls;

public partial class TaskConfigControl : UserControl
{
	private TaskModel? _selectedTask = null;

	public TaskModel? TaskModel
	{
		set
		{
			if (value != null)
			{
				_selectedTask = value;
				LoadLists();
			}
			else
			{
				textBoxRequirements.Text = string.Empty;
				textBoxCheckList.Text = string.Empty;
				dataGridViewErrorList.Rows.Clear();
			}
		}
		get
		{
			return _selectedTask;
		}
	}

	public TaskConfigControl()
	{
		InitializeComponent();
	}

	private void LoadLists()
	{
		if (_selectedTask == null)
		{
			MessageBox.Show("Не выбран блок");
			return;
		}

		if (_selectedTask.Requirements != null && _selectedTask.Requirements.Count > 0)
		{
			textBoxRequirements.Text = string.Join(Environment.NewLine, _selectedTask.Requirements);
		}

		if (_selectedTask.CheckList != null && _selectedTask.CheckList.Count > 0)
		{
			textBoxCheckList.Text = string.Join(Environment.NewLine, _selectedTask.CheckList);
		}

		if (_selectedTask.ErrorList != null && _selectedTask.ErrorList.Count > 0)
		{
			dataGridViewErrorList.Rows.Clear();
			foreach (var elem in _selectedTask.ErrorList)
			{
				dataGridViewErrorList.Rows.Add(new object[] { elem.Id, elem.Text, elem.Weight, elem.IsStop });
			}
		}
	}

	private void TextBoxRequirements_Leave(object sender, EventArgs e)
	{
		if (_selectedTask == null)
		{
			return;
		}

		if (string.IsNullOrEmpty(textBoxRequirements.Text))
		{
			return;
		}

		_selectedTask.Requirements.Clear();
		_selectedTask.Requirements.AddRange(textBoxRequirements.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries));
	}

	private void TextBoxCheckList_Leave(object sender, EventArgs e)
	{
		if (_selectedTask == null)
		{
			return;
		}

		if (string.IsNullOrEmpty(textBoxCheckList.Text))
		{
			return;
		}

		_selectedTask.CheckList.Clear();
		_selectedTask.CheckList.AddRange(textBoxCheckList.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries));
	}

	private void TextBoxErrorList_Leave(object sender, EventArgs e)
	{
		if (_selectedTask == null)
		{
			return;
		}

		if (dataGridViewErrorList.Rows.Count == 0)
		{
			return;
		}

		_selectedTask.ErrorList.Clear();
	}

	private void DataGridViewErrorList_RowLeave(object sender, DataGridViewCellEventArgs e)
	{
		if (_selectedTask == null)
		{
			return;
		}

		if (dataGridViewErrorList.Rows[e.RowIndex].Cells["ColumnId"].Value == null)
		{
			var errorModel = new ErrorModel();

			LoadErrorModel(errorModel, e.RowIndex);

			_selectedTask.ErrorList.Add(errorModel);
		}
		else
		{
			var id = new Guid(dataGridViewErrorList.Rows[e.RowIndex].Cells["ColumnId"].Value.ToString() ?? string.Empty);
			var errorModel = _selectedTask.ErrorList.FirstOrDefault(x => x.Id == id);
			if (errorModel == null)
			{
				MessageBox.Show($"Не найдена запись с идентификатором {id}");
				return;
			}

			LoadErrorModel(errorModel, e.RowIndex);
		}
	}

	private void LoadErrorModel(ErrorModel model, int rowIndex)
	{
		model.Text = dataGridViewErrorList.Rows[rowIndex].Cells["ColumnText"].Value?.ToString() ?? string.Empty;
		model.IsStop = Convert.ToBoolean(dataGridViewErrorList.Rows[rowIndex].Cells["ColumnIsStop"].Value);

		if (dataGridViewErrorList.Rows[rowIndex].Cells["ColumnWeight"].Value != null &&
					double.TryParse(dataGridViewErrorList.Rows[rowIndex].Cells["ColumnWeight"].Value.ToString(), out var d))
		{
			model.Weight = d;
		}
		else
		{
			model.Weight = 0;
		}
	}

	private void DataGridViewErrorList_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
	{
		if (_selectedTask == null)
		{
			e.Cancel = true;
			return;
		}

		if (MessageBox.Show("Удалить?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
		{
			e.Cancel = true;
			return;
		}

		var idStr = e.Row?.Cells["ColumnId"]?.Value.ToString();
		if (string.IsNullOrEmpty(idStr))
		{
			e.Cancel = true;
			return;
		}

		var id = new Guid(idStr);
		var errorModel = _selectedTask.ErrorList.FirstOrDefault(x => x.Id == id);
		if (errorModel == null)
		{
			MessageBox.Show($"Не найдена запись с идентификатором {id}");
			e.Cancel = true;
			return;
		}

		_selectedTask.ErrorList.Remove(errorModel);
	}
}