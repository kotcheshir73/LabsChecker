namespace LabsChecker.Controls
{
	partial class TaskConfigControl
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
			splitContainerFirst = new SplitContainer();
			splitContainerChild = new SplitContainer();
			listBoxRequirements = new ListBox();
			listBoxCheckList = new ListBox();
			((System.ComponentModel.ISupportInitialize)splitContainerFirst).BeginInit();
			splitContainerFirst.Panel1.SuspendLayout();
			splitContainerFirst.Panel2.SuspendLayout();
			splitContainerFirst.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainerChild).BeginInit();
			splitContainerChild.Panel1.SuspendLayout();
			splitContainerChild.SuspendLayout();
			SuspendLayout();
			// 
			// splitContainerFirst
			// 
			splitContainerFirst.Dock = DockStyle.Fill;
			splitContainerFirst.Location = new Point(0, 0);
			splitContainerFirst.Name = "splitContainerFirst";
			splitContainerFirst.Orientation = Orientation.Horizontal;
			// 
			// splitContainerFirst.Panel1
			// 
			splitContainerFirst.Panel1.Controls.Add(listBoxRequirements);
			// 
			// splitContainerFirst.Panel2
			// 
			splitContainerFirst.Panel2.Controls.Add(splitContainerChild);
			splitContainerFirst.Size = new Size(723, 503);
			splitContainerFirst.SplitterDistance = 162;
			splitContainerFirst.TabIndex = 0;
			// 
			// splitContainerChild
			// 
			splitContainerChild.Dock = DockStyle.Fill;
			splitContainerChild.Location = new Point(0, 0);
			splitContainerChild.Name = "splitContainerChild";
			splitContainerChild.Orientation = Orientation.Horizontal;
			// 
			// splitContainerChild.Panel1
			// 
			splitContainerChild.Panel1.Controls.Add(listBoxCheckList);
			splitContainerChild.Size = new Size(723, 337);
			splitContainerChild.SplitterDistance = 171;
			splitContainerChild.TabIndex = 0;
			// 
			// listBoxRequirements
			// 
			listBoxRequirements.Dock = DockStyle.Fill;
			listBoxRequirements.FormattingEnabled = true;
			listBoxRequirements.ItemHeight = 15;
			listBoxRequirements.Location = new Point(0, 0);
			listBoxRequirements.Name = "listBoxRequirements";
			listBoxRequirements.Size = new Size(723, 162);
			listBoxRequirements.TabIndex = 0;
			// 
			// listBoxCheckList
			// 
			listBoxCheckList.Dock = DockStyle.Fill;
			listBoxCheckList.FormattingEnabled = true;
			listBoxCheckList.ItemHeight = 15;
			listBoxCheckList.Location = new Point(0, 0);
			listBoxCheckList.Name = "listBoxCheckList";
			listBoxCheckList.Size = new Size(723, 171);
			listBoxCheckList.TabIndex = 0;
			// 
			// TaskConfigControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(splitContainerFirst);
			Name = "TaskConfigControl";
			Size = new Size(723, 503);
			splitContainerFirst.Panel1.ResumeLayout(false);
			splitContainerFirst.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainerFirst).EndInit();
			splitContainerFirst.ResumeLayout(false);
			splitContainerChild.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainerChild).EndInit();
			splitContainerChild.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainerFirst;
		private SplitContainer splitContainerChild;
		private ListBox listBoxRequirements;
		private ListBox listBoxCheckList;
	}
}
