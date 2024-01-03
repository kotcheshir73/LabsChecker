namespace LabsChecker.Controls
{
	partial class LabWorkConfigControl
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
			groupBoxLabWorks = new GroupBox();
			listBoxLabWorks = new ListBox();
			buttonSaveLabWorks = new Button();
			buttonAddLabWork = new Button();
			buttonUpdLabWork = new Button();
			buttonDelLabWork = new Button();
			panelLabWorkChange = new Panel();
			buttonCancelLabWork = new Button();
			buttonSaveLabWork = new Button();
			textBoxLabWorkName = new TextBox();
			labelLabWorkName = new Label();
			groupBoxLabWorks.SuspendLayout();
			panelLabWorkChange.SuspendLayout();
			SuspendLayout();
			// 
			// groupBoxLabWorks
			// 
			groupBoxLabWorks.Controls.Add(listBoxLabWorks);
			groupBoxLabWorks.Controls.Add(buttonSaveLabWorks);
			groupBoxLabWorks.Controls.Add(buttonAddLabWork);
			groupBoxLabWorks.Controls.Add(buttonUpdLabWork);
			groupBoxLabWorks.Controls.Add(buttonDelLabWork);
			groupBoxLabWorks.Controls.Add(panelLabWorkChange);
			groupBoxLabWorks.Dock = DockStyle.Left;
			groupBoxLabWorks.Location = new Point(0, 0);
			groupBoxLabWorks.Name = "groupBoxLabWorks";
			groupBoxLabWorks.Size = new Size(235, 717);
			groupBoxLabWorks.TabIndex = 0;
			groupBoxLabWorks.TabStop = false;
			groupBoxLabWorks.Text = "Лабораторные работы";
			// 
			// listBoxLabWorks
			// 
			listBoxLabWorks.Dock = DockStyle.Fill;
			listBoxLabWorks.FormattingEnabled = true;
			listBoxLabWorks.ItemHeight = 15;
			listBoxLabWorks.Location = new Point(3, 118);
			listBoxLabWorks.Name = "listBoxLabWorks";
			listBoxLabWorks.Size = new Size(229, 504);
			listBoxLabWorks.TabIndex = 5;
			listBoxLabWorks.SelectedIndexChanged += ListBoxLabWorks_SelectedIndexChanged;
			// 
			// buttonSaveLabWorks
			// 
			buttonSaveLabWorks.Dock = DockStyle.Bottom;
			buttonSaveLabWorks.Location = new Point(3, 622);
			buttonSaveLabWorks.Name = "buttonSaveLabWorks";
			buttonSaveLabWorks.Size = new Size(229, 23);
			buttonSaveLabWorks.TabIndex = 4;
			buttonSaveLabWorks.Text = "Сохранить";
			buttonSaveLabWorks.UseVisualStyleBackColor = true;
			buttonSaveLabWorks.Click += ButtonSaveLabWorks_Click;
			// 
			// buttonAddLabWork
			// 
			buttonAddLabWork.Dock = DockStyle.Bottom;
			buttonAddLabWork.Location = new Point(3, 645);
			buttonAddLabWork.Name = "buttonAddLabWork";
			buttonAddLabWork.Size = new Size(229, 23);
			buttonAddLabWork.TabIndex = 2;
			buttonAddLabWork.Text = "Добавить";
			buttonAddLabWork.UseVisualStyleBackColor = true;
			buttonAddLabWork.Click += ButtonAddLabWork_Click;
			// 
			// buttonUpdLabWork
			// 
			buttonUpdLabWork.Dock = DockStyle.Bottom;
			buttonUpdLabWork.Location = new Point(3, 668);
			buttonUpdLabWork.Name = "buttonUpdLabWork";
			buttonUpdLabWork.Size = new Size(229, 23);
			buttonUpdLabWork.TabIndex = 3;
			buttonUpdLabWork.Text = "Изменить";
			buttonUpdLabWork.UseVisualStyleBackColor = true;
			buttonUpdLabWork.Click += ButtonUpdLabWork_Click;
			// 
			// buttonDelLabWork
			// 
			buttonDelLabWork.Dock = DockStyle.Bottom;
			buttonDelLabWork.Location = new Point(3, 691);
			buttonDelLabWork.Name = "buttonDelLabWork";
			buttonDelLabWork.Size = new Size(229, 23);
			buttonDelLabWork.TabIndex = 1;
			buttonDelLabWork.Text = "Удалить";
			buttonDelLabWork.UseVisualStyleBackColor = true;
			buttonDelLabWork.Click += ButtonDelLabWork_Click;
			// 
			// panelLabWorkChange
			// 
			panelLabWorkChange.Controls.Add(buttonCancelLabWork);
			panelLabWorkChange.Controls.Add(buttonSaveLabWork);
			panelLabWorkChange.Controls.Add(textBoxLabWorkName);
			panelLabWorkChange.Controls.Add(labelLabWorkName);
			panelLabWorkChange.Dock = DockStyle.Top;
			panelLabWorkChange.Location = new Point(3, 19);
			panelLabWorkChange.Name = "panelLabWorkChange";
			panelLabWorkChange.Size = new Size(229, 99);
			panelLabWorkChange.TabIndex = 0;
			panelLabWorkChange.Visible = false;
			// 
			// buttonCancelLabWork
			// 
			buttonCancelLabWork.Location = new Point(137, 59);
			buttonCancelLabWork.Name = "buttonCancelLabWork";
			buttonCancelLabWork.Size = new Size(75, 23);
			buttonCancelLabWork.TabIndex = 3;
			buttonCancelLabWork.Text = "Отмена";
			buttonCancelLabWork.UseVisualStyleBackColor = true;
			buttonCancelLabWork.Click += ButtonCancelLabWork_Click;
			// 
			// buttonSaveLabWork
			// 
			buttonSaveLabWork.Location = new Point(9, 59);
			buttonSaveLabWork.Name = "buttonSaveLabWork";
			buttonSaveLabWork.Size = new Size(75, 23);
			buttonSaveLabWork.TabIndex = 2;
			buttonSaveLabWork.Text = "Сохранить";
			buttonSaveLabWork.UseVisualStyleBackColor = true;
			buttonSaveLabWork.Click += ButtonSaveLabWork_Click;
			// 
			// textBoxLabWorkName
			// 
			textBoxLabWorkName.Location = new Point(9, 30);
			textBoxLabWorkName.Name = "textBoxLabWorkName";
			textBoxLabWorkName.Size = new Size(203, 23);
			textBoxLabWorkName.TabIndex = 1;
			// 
			// labelLabWorkName
			// 
			labelLabWorkName.AutoSize = true;
			labelLabWorkName.Location = new Point(9, 12);
			labelLabWorkName.Name = "labelLabWorkName";
			labelLabWorkName.Size = new Size(62, 15);
			labelLabWorkName.TabIndex = 0;
			labelLabWorkName.Text = "Название:";
			// 
			// LabWorkConfigControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(groupBoxLabWorks);
			Name = "LabWorkConfigControl";
			Size = new Size(913, 717);
			groupBoxLabWorks.ResumeLayout(false);
			panelLabWorkChange.ResumeLayout(false);
			panelLabWorkChange.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private GroupBox groupBoxLabWorks;
		private ListBox listBoxLabWorks;
		private Button buttonSaveLabWorks;
		private Button buttonAddLabWork;
		private Button buttonUpdLabWork;
		private Button buttonDelLabWork;
		private Panel panelLabWorkChange;
		private Button buttonCancelLabWork;
		private Button buttonSaveLabWork;
		private TextBox textBoxLabWorkName;
		private Label labelLabWorkName;
	}
}
