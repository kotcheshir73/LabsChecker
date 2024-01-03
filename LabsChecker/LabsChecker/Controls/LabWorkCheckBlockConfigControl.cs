using LabsChecker.Extenstions;
using LabsChecker.Logics;

namespace LabsChecker.Controls;

public partial class LabWorkCheckBlockConfigControl : UserControl
{
	private readonly LabWorkLogic _labWorkLogic;

	private string _selectedLabWorkName = string.Empty;

	public string? SetLabWorkName
	{
		set
		{
			if (value.IsNotEmpty())
			{
				_selectedLabWorkName = value ?? string.Empty;
				LoadTasks();
			}
		}
	}

	public LabWorkCheckBlockConfigControl(LabWorkLogic labWorkLogic)
	{
		InitializeComponent();
		_labWorkLogic = labWorkLogic ?? throw new ArgumentNullException(nameof(labWorkLogic));
	}

	private void LoadTasks()
	{
		if (_selectedLabWorkName.IsNullOrEmpty())
		{
			MessageBox.Show("Не выбрана работа");
			return;
		}

		var list = _labWorkLogic.GetBlocks(_selectedLabWorkName);
		if (list == null)
		{
			MessageBox.Show("Нет блоков по работе");
			return;
		}

		var index = 0;
		tabControlItems.TabPages.Clear();
		foreach (var block in list)
		{
			var page = new TabPage
			{
				Location = new Point(4, 24),
				Name = $"tabPage{index}",
				Padding = new Padding(3),
				Size = new Size(723, 566),
				TabIndex = index++,
				Text = block.BlockTitle,
				UseVisualStyleBackColor = true,
				Tag = block.Id
			};

			page.Controls.Add(new LabWorkCheckItemConfigControl(_labWorkLogic)
			{
				Dock = DockStyle.Fill,
				Location = new Point(3, 3),
				Name = $"taskConfigControl{block.Id}",
				Size = new Size(723, 503),
				TabIndex = 0,
				SetLabWorkName = _selectedLabWorkName,
				SetLabWorkBlockId = block.Id
			});

			tabControlItems.TabPages.Add(page);
		}

		panelTaskBlock.Visible = true;
	}

	private void ButtonAddTask_Click(object sender, EventArgs e)
	{
		if (_selectedLabWorkName.IsNullOrEmpty())
		{
			MessageBox.Show("Не выбрана работа");
			return;
		}

		if (string.IsNullOrEmpty(textBoxTaskName.Text))
		{
			MessageBox.Show("Не введено название");
			return;
		}

		try
		{
			_labWorkLogic.InsertCheckBlock(_selectedLabWorkName, textBoxTaskName.Text);
			LoadTasks();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void ButtonUpdTask_Click(object sender, EventArgs e)
	{
		if (_selectedLabWorkName.IsNullOrEmpty())
		{
			MessageBox.Show("Не выбрана работа");
			return;
		}

		if (tabControlItems.SelectedTab == null)
		{
			MessageBox.Show("Не выбран блок");
			return;
		}

		if (string.IsNullOrEmpty(textBoxTaskName.Text))
		{
			MessageBox.Show("Не введено название");
			return;
		}

		try
		{
			_labWorkLogic.UpdateCheckBlock(_selectedLabWorkName, (Guid?)tabControlItems.SelectedTab.Tag, textBoxTaskName.Text);
			LoadTasks();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void ButtonDelTask_Click(object sender, EventArgs e)
	{
		if (_selectedLabWorkName.IsNullOrEmpty())
		{
			MessageBox.Show("Не выбрана работа");
			return;
		}

		if (tabControlItems.SelectedTab == null)
		{
			MessageBox.Show("Не выбран блок");
			return;
		}

		if (MessageBox.Show("Удалить?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
		{
			return;
		}

		try
		{
			_labWorkLogic.DeleteCheckBlock(_selectedLabWorkName, (Guid?)tabControlItems.SelectedTab.Tag);
			LoadTasks();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void ButtonCopyTask_Click(object sender, EventArgs e)
	{
		if (_selectedLabWorkName.IsNullOrEmpty())
		{
			MessageBox.Show("Не выбрана работа");
			return;
		}

		if (tabControlItems.SelectedTab == null)
		{
			MessageBox.Show("Не выбран блок");
			return;
		}

		try
		{
			_labWorkLogic.CopyBlock(_selectedLabWorkName, (Guid?)tabControlItems.SelectedTab.Tag);
			buttonPasteTask.Enabled = true;
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

	}

	private void ButtonPasteTask_Click(object sender, EventArgs e)
	{
		if (_selectedLabWorkName.IsNullOrEmpty())
		{
			MessageBox.Show("Не выбрана работа");
			return;
		}

		try
		{
			_labWorkLogic.PasteBlock(_selectedLabWorkName);
			LoadTasks();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}