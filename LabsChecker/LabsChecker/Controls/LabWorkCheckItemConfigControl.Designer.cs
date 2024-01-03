namespace LabsChecker.Controls
{
	partial class LabWorkCheckItemConfigControl
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
			panelTools = new Panel();
			buttonDelItem = new Button();
			buttonAddItem = new Button();
			tableLayoutPanel = new TableLayoutPanel();
			panelTools.SuspendLayout();
			SuspendLayout();
			// 
			// panelTools
			// 
			panelTools.Controls.Add(buttonDelItem);
			panelTools.Controls.Add(buttonAddItem);
			panelTools.Dock = DockStyle.Right;
			panelTools.Location = new Point(835, 0);
			panelTools.Name = "panelTools";
			panelTools.Size = new Size(36, 738);
			panelTools.TabIndex = 0;
			// 
			// buttonDelItem
			// 
			buttonDelItem.Location = new Point(3, 39);
			buttonDelItem.Name = "buttonDelItem";
			buttonDelItem.Size = new Size(30, 30);
			buttonDelItem.TabIndex = 1;
			buttonDelItem.Text = "-";
			buttonDelItem.UseVisualStyleBackColor = true;
			// 
			// buttonAddItem
			// 
			buttonAddItem.Location = new Point(3, 3);
			buttonAddItem.Name = "buttonAddItem";
			buttonAddItem.Size = new Size(30, 30);
			buttonAddItem.TabIndex = 0;
			buttonAddItem.Text = "+";
			buttonAddItem.UseVisualStyleBackColor = true;
			buttonAddItem.Click += ButtonAddItem_Click;
			// 
			// tableLayoutPanel
			// 
			tableLayoutPanel.AutoScroll = true;
			tableLayoutPanel.ColumnCount = 1;
			tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
			tableLayoutPanel.Dock = DockStyle.Fill;
			tableLayoutPanel.Location = new Point(0, 0);
			tableLayoutPanel.Name = "tableLayoutPanel";
			tableLayoutPanel.RowCount = 1;
			tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
			tableLayoutPanel.Size = new Size(835, 738);
			tableLayoutPanel.TabIndex = 1;
			// 
			// LabWorkCheckItemConfigControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(tableLayoutPanel);
			Controls.Add(panelTools);
			Name = "LabWorkCheckItemConfigControl";
			Size = new Size(871, 738);
			panelTools.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private Panel panelTools;
		private Button buttonDelItem;
		private Button buttonAddItem;
		private TableLayoutPanel tableLayoutPanel;
	}
}
