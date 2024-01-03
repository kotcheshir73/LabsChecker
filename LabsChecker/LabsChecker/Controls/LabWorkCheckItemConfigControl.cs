using LabsChecker.Extenstions;
using LabsChecker.Logics;

namespace LabsChecker.Controls;

public partial class LabWorkCheckItemConfigControl : UserControl
{
	private readonly LabWorkLogic _labWorkLogic;

	private string _selectedLabWorkName = string.Empty;

	private Guid? _selectedLabWorkBlockId = null;

	public string? SetLabWorkName
	{
		set
		{
			if (value.IsNotEmpty())
			{
				_selectedLabWorkName = value ?? string.Empty;
				LoadItems();
			}
		}
	}

	public Guid? SetLabWorkBlockId
	{
		set
		{
			if (value.HasValue)
			{
				_selectedLabWorkBlockId = value.Value;
				LoadItems();
			}
		}
	}

	public LabWorkCheckItemConfigControl(LabWorkLogic labWorkLogic)
	{
		InitializeComponent();
		_labWorkLogic = labWorkLogic ?? throw new ArgumentNullException(nameof(labWorkLogic));
	}

	private void LoadItems()
	{
		if (_selectedLabWorkName.IsNullOrEmpty() || !_selectedLabWorkBlockId.HasValue)
		{
			return;
		}

		var list = _labWorkLogic.GetItems(_selectedLabWorkName, _selectedLabWorkBlockId.Value);
		if (list == null)
		{
			MessageBox.Show("Нет элементов в блоке");
			return;
		}

		foreach (var item in list)
		{
			var panel = CreatePanel(item.Id);
			panel.Controls["textBoxRequirement"]!.Text = item.Requirement;
			panel.Controls["textBoxCheckList"]!.Text = item.CheckList;
			panel.Controls["textBoxErrorList"]!.Text = string.Join(Environment.NewLine, item.ErrorList);

			AddRow(panel);
		}
	}

	private void ButtonAddItem_Click(object sender, EventArgs e)
	{
		AddRow(CreatePanel(Guid.NewGuid()));
	}

	private void AddRow(Panel panel)
	{
		tableLayoutPanel.RowCount++;
		tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
		tableLayoutPanel.Controls.Add(panel, 1, tableLayoutPanel.RowCount - 2);
	}

	private Panel CreatePanel(Guid id)
	{
		var panelItem = new Panel
		{
			Location = new Point(3, 3),
			Name = $"panelItem_{id}",
			Size = new Size(620, 204),
			Dock = DockStyle.Fill,
			TabIndex = 0
		};

		panelItem.Controls.Add(new Button
		{
			Location = new Point(5, 90),
			Name = "buttonFix",
			Size = new Size(75, 25),
			TabIndex = 10,
			Text = "Зафиксировать",
			UseVisualStyleBackColor = true,
			Tag = id
		});
		panelItem.Controls.Add(new TextBox
		{
			Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
			Location = new Point(100, 62),
			Multiline = true,
			Name = "textBoxErrorList",
			Size = new Size(500, 40),
			TabIndex = 5,
			ScrollBars = ScrollBars.Vertical
		});
		panelItem.Controls.Add(new Label
		{
			AutoSize = true,
			Location = new Point(3, 64),
			Name = "labelErrorList",
			Size = new Size(57, 15),
			TabIndex = 4,
			Text = "Ошибки:"
		});
		panelItem.Controls.Add(new TextBox
		{
			Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
			Location = new Point(100, 32),
			Name = "textBoxCheckList",
			Size = new Size(500, 23),
			TabIndex = 3
		});
		panelItem.Controls.Add(new Label
		{
			AutoSize = true,
			Location = new Point(3, 34),
			Name = "labelCheckList",
			Size = new Size(90, 15),
			TabIndex = 2,
			Text = "Что проверять:"
		});
		panelItem.Controls.Add(new TextBox
		{
			Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
			Location = new Point(100, 2),
			Name = "textBoxRequirement",
			Size = new Size(500, 23),
			TabIndex = 1
		});
		panelItem.Controls.Add(new Label
		{
			AutoSize = true,
			Location = new Point(3, 4),
			Name = "labelRequirement",
			Size = new Size(75, 15),
			TabIndex = 0,
			Text = "Требование:"
		});

		panelItem.Controls["buttonFix"]!.Click += ButtonFix_Click;

		return panelItem;
	}

	private void ButtonFix_Click(object? sender, EventArgs e)
	{
		if (_selectedLabWorkName.IsNullOrEmpty() || !_selectedLabWorkBlockId.HasValue)
		{
			return;
		}

		if (sender is not Button button)
		{
			return;
		}

		var id = (Guid)button.Tag!;
		if (button.Parent is not Panel panel)
		{
			return;
		}

		try
		{
			_labWorkLogic.FixItem(_selectedLabWorkName, _selectedLabWorkBlockId.Value, id,
				panel.Controls["textBoxRequirement"]!.Text,
				panel.Controls["textBoxCheckList"]!.Text,
				panel.Controls["textBoxErrorList"]!.Text.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries));
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}