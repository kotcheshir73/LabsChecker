using LabsChecker.Logics;
using LabsChecker.Models;
using System.Data;

namespace LabsChecker.Forms;

public partial class LabWorkConfigForm : Form
{
	private readonly LabWorkLogic _labWorkLogic;

	private List<LabWorkModel> _labWorkModels = [];

	private LabWorkModel? _updatedLabWork = null;

	public LabWorkConfigForm(LabWorkLogic labWorkLogic)
	{
		InitializeComponent();
		_labWorkLogic = labWorkLogic ?? throw new ArgumentNullException(nameof(labWorkLogic));
	}

	private void LabWorkConfigForm_Load(object sender, EventArgs e)
	{
		try
		{
			_labWorkModels = _labWorkLogic.LabWorkList;
			ReloadList();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void ReloadList()
	{
		listBoxLabWorks.Items.Clear();
		listBoxLabWorks.Items.AddRange(_labWorkModels.Select(x => x.LabWorkTitle).ToArray());
		taskConfigControl.LabWorkModel = null;
	}

	private void ButtonSaveLabWorks_Click(object sender, EventArgs e)
	{
		try
		{
			_labWorkLogic.SaveData();
			ReloadList();
			MessageBox.Show("Сохранение завершено");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void ButtonAddLabWork_Click(object sender, EventArgs e)
	{
		panelLabWorkChange.Visible = true;
		textBoxLabWorkName.Text = string.Empty;
		textBoxLabWorkName.Focus();
		_updatedLabWork = null;
	}

	private void ButtonUpdLabWork_Click(object sender, EventArgs e)
	{
		if (listBoxLabWorks.SelectedItem == null)
		{
			MessageBox.Show("Не выбрана ни одна запись");
			return;
		}

		_updatedLabWork = _labWorkModels.FirstOrDefault(x => x.LabWorkTitle == listBoxLabWorks.SelectedItem.ToString());
		if (_updatedLabWork == null)
		{
			MessageBox.Show("Не найдена запись по имени");
			return;
		}

		panelLabWorkChange.Visible = true;
		textBoxLabWorkName.Text = _updatedLabWork.LabWorkTitle;
		textBoxLabWorkName.Focus();
	}

	private void ButtonDelLabWork_Click(object sender, EventArgs e)
	{
		if (listBoxLabWorks.SelectedItem == null)
		{
			MessageBox.Show("Не выбрана ни одна запись");
			return;
		}

		if (MessageBox.Show("Удалить?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
		{
			return;
		}

		var work = _labWorkModels.FirstOrDefault(x => x.LabWorkTitle == listBoxLabWorks.SelectedItem.ToString());
		if (work == null)
		{
			MessageBox.Show("Не найдена запись по имени");
			return;
		}

		_labWorkModels.Remove(work);
		ReloadList();
	}

	private void ButtonSaveLabWork_Click(object sender, EventArgs e)
	{
		if (string.IsNullOrEmpty(textBoxLabWorkName.Text))
		{
			MessageBox.Show("Не введено название");
			return;
		}

		if (_labWorkModels.Any(x => x.LabWorkTitle == textBoxLabWorkName.Text))
		{
			MessageBox.Show("Уже есть работа с таким названием");
			return;
		}

		if (_updatedLabWork == null)
		{
			_updatedLabWork = new();
			_labWorkModels.Add(_updatedLabWork);
		}

		_updatedLabWork.LabWorkTitle = textBoxLabWorkName.Text;

		panelLabWorkChange.Visible = false;
		ReloadList();
	}

	private void ButtonCancelLabWork_Click(object sender, EventArgs e)
	{
		panelLabWorkChange.Visible = false;
		ReloadList();
	}

	private void ListBoxLabWorks_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (listBoxLabWorks.SelectedItem == null)
		{
			MessageBox.Show("Не выбрана ни одна запись");
			return;
		}

		var selectedLabWork = _labWorkModels.FirstOrDefault(x => x.LabWorkTitle == listBoxLabWorks.SelectedItem.ToString());
		if (selectedLabWork == null)
		{
			MessageBox.Show("Не найдена запись по имени");
			return;
		}

		taskConfigControl.LabWorkModel = selectedLabWork;
	}
}