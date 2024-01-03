namespace LabsChecker.Controls
{
	partial class LabWorkCheckBlockConfigControl
	{
		/// <summary> 
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором компонентов

		/// <summary> 
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			panelTaskBlock = new Panel();
			buttonPasteTask = new Button();
			buttonCopyTask = new Button();
			buttonDelTask = new Button();
			buttonUpdTask = new Button();
			buttonAddTask = new Button();
			textBoxTaskName = new TextBox();
			labelTaskName = new Label();
			tabControlItems = new TabControl();
			panelTaskBlock.SuspendLayout();
			SuspendLayout();
			// 
			// panelTaskBlock
			// 
			panelTaskBlock.Controls.Add(buttonPasteTask);
			panelTaskBlock.Controls.Add(buttonCopyTask);
			panelTaskBlock.Controls.Add(buttonDelTask);
			panelTaskBlock.Controls.Add(buttonUpdTask);
			panelTaskBlock.Controls.Add(buttonAddTask);
			panelTaskBlock.Controls.Add(textBoxTaskName);
			panelTaskBlock.Controls.Add(labelTaskName);
			panelTaskBlock.Dock = DockStyle.Top;
			panelTaskBlock.Location = new Point(0, 0);
			panelTaskBlock.Name = "panelTaskBlock";
			panelTaskBlock.Size = new Size(786, 72);
			panelTaskBlock.TabIndex = 3;
			panelTaskBlock.Visible = false;
			// 
			// buttonPasteTask
			// 
			buttonPasteTask.Enabled = false;
			buttonPasteTask.Location = new Point(110, 35);
			buttonPasteTask.Name = "buttonPasteTask";
			buttonPasteTask.Size = new Size(98, 23);
			buttonPasteTask.TabIndex = 6;
			buttonPasteTask.Text = "Вставить";
			buttonPasteTask.UseVisualStyleBackColor = true;
			buttonPasteTask.Click += ButtonPasteTask_Click;
			// 
			// buttonCopyTask
			// 
			buttonCopyTask.Location = new Point(6, 35);
			buttonCopyTask.Name = "buttonCopyTask";
			buttonCopyTask.Size = new Size(98, 23);
			buttonCopyTask.TabIndex = 5;
			buttonCopyTask.Text = "Копировать";
			buttonCopyTask.UseVisualStyleBackColor = true;
			buttonCopyTask.Click += ButtonCopyTask_Click;
			// 
			// buttonDelTask
			// 
			buttonDelTask.Location = new Point(529, 5);
			buttonDelTask.Name = "buttonDelTask";
			buttonDelTask.Size = new Size(75, 23);
			buttonDelTask.TabIndex = 4;
			buttonDelTask.Text = "Удалить";
			buttonDelTask.UseVisualStyleBackColor = true;
			buttonDelTask.Click += ButtonDelTask_Click;
			// 
			// buttonUpdTask
			// 
			buttonUpdTask.Location = new Point(448, 6);
			buttonUpdTask.Name = "buttonUpdTask";
			buttonUpdTask.Size = new Size(75, 23);
			buttonUpdTask.TabIndex = 3;
			buttonUpdTask.Text = "Изменить";
			buttonUpdTask.UseVisualStyleBackColor = true;
			buttonUpdTask.Click += ButtonUpdTask_Click;
			// 
			// buttonAddTask
			// 
			buttonAddTask.Location = new Point(367, 6);
			buttonAddTask.Name = "buttonAddTask";
			buttonAddTask.Size = new Size(75, 23);
			buttonAddTask.TabIndex = 2;
			buttonAddTask.Text = "Добавить";
			buttonAddTask.UseVisualStyleBackColor = true;
			buttonAddTask.Click += ButtonAddTask_Click;
			// 
			// textBoxTaskName
			// 
			textBoxTaskName.Location = new Point(110, 6);
			textBoxTaskName.Name = "textBoxTaskName";
			textBoxTaskName.Size = new Size(251, 23);
			textBoxTaskName.TabIndex = 1;
			// 
			// labelTaskName
			// 
			labelTaskName.AutoSize = true;
			labelTaskName.Location = new Point(6, 9);
			labelTaskName.Name = "labelTaskName";
			labelTaskName.Size = new Size(98, 15);
			labelTaskName.TabIndex = 0;
			labelTaskName.Text = "Название блока:";
			// 
			// tabControlItems
			// 
			tabControlItems.Dock = DockStyle.Fill;
			tabControlItems.Location = new Point(0, 72);
			tabControlItems.Name = "tabControlItems";
			tabControlItems.SelectedIndex = 0;
			tabControlItems.Size = new Size(786, 649);
			tabControlItems.TabIndex = 4;
			// 
			// LabWorkCheckBlockConfigControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(tabControlItems);
			Controls.Add(panelTaskBlock);
			Name = "LabWorkCheckBlockConfigControl";
			Size = new Size(786, 721);
			panelTaskBlock.ResumeLayout(false);
			panelTaskBlock.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Panel panelTaskBlock;
		private Button buttonPasteTask;
		private Button buttonCopyTask;
		private Button buttonDelTask;
		private Button buttonUpdTask;
		private Button buttonAddTask;
		private TextBox textBoxTaskName;
		private Label labelTaskName;
		private TabControl tabControlItems;
	}
}
