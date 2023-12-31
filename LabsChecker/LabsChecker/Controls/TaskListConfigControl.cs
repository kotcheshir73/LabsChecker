using LabsChecker.Models;

namespace LabsChecker.Controls;

public partial class TaskListConfigControl : UserControl
{
	private LabWorkModel? _selectedLabWork = null;

	private TaskModel? _copyTask = null;

	public LabWorkModel? LabWorkModel
	{
		set
		{
			if (value != null)
			{
				_selectedLabWork = value;
				LoadTasks();
			}
			else
			{
				tabControlTasks.TabPages.Clear();
			}
		}
		get
		{
			return _selectedLabWork;
		}
	}

	public TaskListConfigControl()
	{
		InitializeComponent();
	}

	private void LoadTasks()
	{
		if (_selectedLabWork == null)
		{
			MessageBox.Show("Не выбрана работа");
			return;
		}

		var index = 0;
		tabControlTasks.TabPages.Clear();
		foreach (var task in _selectedLabWork.Tasks)
		{
			var page = new TabPage
			{
				Location = new Point(4, 24),
				Name = $"tabPage{index}",
				Padding = new Padding(3),
				Size = new Size(723, 566),
				TabIndex = index++,
				Text = task.TaskTitle,
				UseVisualStyleBackColor = true
			};

			tabControlTasks.TabPages.Add(page);
		}

		panelTaskBlock.Visible = true;
	}

	private void ButtonAddTask_Click(object sender, EventArgs e)
	{
		if (_selectedLabWork == null)
		{
			MessageBox.Show("Не выбрана работа");
			return;
		}

		if (string.IsNullOrEmpty(textBoxTaskName.Text))
		{
			MessageBox.Show("Не введено название");
			return;
		}

		if (_selectedLabWork.Tasks.Any(x => x.TaskTitle == textBoxTaskName.Text))
		{
			MessageBox.Show("Уже есть блок с таким названием");
			return;
		}

		_selectedLabWork.Tasks.Add(new TaskModel { TaskTitle = textBoxTaskName.Text });
		LoadTasks();
	}

	private void ButtonUpdTask_Click(object sender, EventArgs e)
	{
		if (_selectedLabWork == null)
		{
			MessageBox.Show("Не выбрана работа");
			return;
		}

		if (tabControlTasks.SelectedTab == null)
		{
			MessageBox.Show("Не выбран блок");
			return;
		}

		if (string.IsNullOrEmpty(textBoxTaskName.Text))
		{
			MessageBox.Show("Не введено название");
			return;
		}

		if (_selectedLabWork.Tasks.Any(x => x.TaskTitle == textBoxTaskName.Text))
		{
			MessageBox.Show("Уже есть блок с таким названием");
			return;
		}

		var task = _selectedLabWork.Tasks.FirstOrDefault(x => x.TaskTitle == tabControlTasks.SelectedTab.Text);
		if (task == null)
		{
			MessageBox.Show($"Не найден блок по имени {tabControlTasks.SelectedTab.Text}");
			return;
		}

		task.TaskTitle = textBoxTaskName.Text;
		LoadTasks();
	}

	private void ButtonDelTask_Click(object sender, EventArgs e)
	{
		if (_selectedLabWork == null)
		{
			MessageBox.Show("Не выбрана работа");
			return;
		}

		if (tabControlTasks.SelectedTab == null)
		{
			MessageBox.Show("Не выбран блок");
			return;
		}

		if (MessageBox.Show("Удалить?", "Запрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
		{
			return;
		}


		var task = _selectedLabWork.Tasks.FirstOrDefault(x => x.TaskTitle == tabControlTasks.SelectedTab.Text);
		if (task == null)
		{
			MessageBox.Show($"Не найден блок по имени {tabControlTasks.SelectedTab.Text}");
			return;
		}

		_selectedLabWork.Tasks.Remove(task);
		LoadTasks();
	}

	private void ButtonCopyTask_Click(object sender, EventArgs e)
	{
		if (_selectedLabWork == null)
		{
			MessageBox.Show("Не выбрана работа");
			return;
		}

		if (tabControlTasks.SelectedTab == null)
		{
			MessageBox.Show("Не выбран блок");
			return;
		}

		_copyTask = _selectedLabWork.Tasks.FirstOrDefault(x => x.TaskTitle == tabControlTasks.SelectedTab.Text);
		if (_copyTask == null)
		{
			MessageBox.Show($"Не найден блок по имени {tabControlTasks.SelectedTab.Text}");
			return;
		}

		buttonPasteTask.Enabled = true;
	}

	private void ButtonPasteTask_Click(object sender, EventArgs e)
	{
		if (_selectedLabWork == null)
		{
			MessageBox.Show("Не выбрана работа");
			return;
		}

		if (_copyTask == null)
		{
			MessageBox.Show("Нет скопированного блока");
			return;
		}

		var newTask = (TaskModel)_copyTask.Clone();
		while(_selectedLabWork.Tasks.Any(x => x.TaskTitle == newTask.TaskTitle))
		{
			newTask.TaskTitle = $"{newTask.TaskTitle} 1";
		}

		_selectedLabWork.Tasks.Add(newTask);
		LoadTasks();
	}
}