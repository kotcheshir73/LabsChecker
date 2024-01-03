using LabsChecker.Extenstions;
using LabsChecker.Logics;

namespace LabsChecker.Controls;

public partial class LabWorkConfigControl : UserControl
{
	private readonly LabWorkLogic _labWorkLogic;

	private Guid? _updatedLabWorkId = null;

	private readonly LabWorkCheckBlockConfigControl _labWorkCheckBlockConfigControl;

	public LabWorkConfigControl(LabWorkLogic labWorkLogic)
	{
		InitializeComponent();
		_labWorkLogic = labWorkLogic ?? throw new ArgumentNullException(nameof(labWorkLogic));

		_labWorkCheckBlockConfigControl = new LabWorkCheckBlockConfigControl(labWorkLogic)
		{
			Dock = DockStyle.Fill,
			Location = new Point(0, 0),
			Name = "LabWorkBlockConfigControl",
			Size = new Size(678, 717),
			TabIndex = 1
		};

		Controls.Clear();
		Controls.Add(_labWorkCheckBlockConfigControl);
		Controls.Add(groupBoxLabWorks);

		ReloadList();
	}

	private void ReloadList()
	{
		listBoxLabWorks.Items.Clear();
		listBoxLabWorks.Items.AddRange(_labWorkLogic.GetTitles.ToArray());
		_labWorkCheckBlockConfigControl.SetLabWorkName = string.Empty;
	}

	private void ButtonSaveLabWorks_Click(object sender, EventArgs e)
	{
		try
		{
			_labWorkLogic.SaveData();
			MessageBox.Show("Сохранение завершено");
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void ButtonAddLabWork_Click(object sender, EventArgs e)
	{
		panelLabWorkChange.Visible = true;
		textBoxLabWorkName.Text = string.Empty;
		textBoxLabWorkName.Focus();
		_updatedLabWorkId = null;
	}

	private void ButtonUpdLabWork_Click(object sender, EventArgs e)
	{
		if (listBoxLabWorks.SelectedItem == null)
		{
			MessageBox.Show("Не выбрана ни одна запись");
			return;
		}

		_updatedLabWorkId = _labWorkLogic[listBoxLabWorks.SelectedItem.ToString()]?.Id;
		if (_updatedLabWorkId == null)
		{
			MessageBox.Show("Не найдена запись по имени");
			return;
		}

		panelLabWorkChange.Visible = true;
		textBoxLabWorkName.Text = listBoxLabWorks.SelectedItem.ToString();
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

		try
		{
			_labWorkLogic.DeleteLabWorkByKey(listBoxLabWorks.SelectedItem.ToString());
		}
		catch(Exception ex)
		{
			MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		ReloadList();
	}

	private void ButtonSaveLabWork_Click(object sender, EventArgs e)
	{
		if (textBoxLabWorkName.Text.IsNullOrEmpty())
		{
			MessageBox.Show("Не введено название");
			return;
		}

		try
		{
			if (_updatedLabWorkId.HasValue)
			{
				_labWorkLogic.UpdateLabWorkName(_updatedLabWorkId.Value, textBoxLabWorkName.Text);
			}
			else
			{
				_labWorkLogic.InsertLabWork(new() { LabWorkTitle = textBoxLabWorkName.Text });
			}

			panelLabWorkChange.Visible = false;
			ReloadList();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
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
			return;
		}

		_labWorkCheckBlockConfigControl.SetLabWorkName = listBoxLabWorks.SelectedItem.ToString();
	}
}