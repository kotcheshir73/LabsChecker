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
			textBoxRequirements = new TextBox();
			splitContainerChild = new SplitContainer();
			textBoxCheckList = new TextBox();
			dataGridViewErrorList = new DataGridView();
			ColumnId = new DataGridViewTextBoxColumn();
			ColumnText = new DataGridViewTextBoxColumn();
			ColumnWeight = new DataGridViewTextBoxColumn();
			ColumnIsStop = new DataGridViewCheckBoxColumn();
			((System.ComponentModel.ISupportInitialize)splitContainerFirst).BeginInit();
			splitContainerFirst.Panel1.SuspendLayout();
			splitContainerFirst.Panel2.SuspendLayout();
			splitContainerFirst.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainerChild).BeginInit();
			splitContainerChild.Panel1.SuspendLayout();
			splitContainerChild.Panel2.SuspendLayout();
			splitContainerChild.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridViewErrorList).BeginInit();
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
			splitContainerFirst.Panel1.Controls.Add(textBoxRequirements);
			// 
			// splitContainerFirst.Panel2
			// 
			splitContainerFirst.Panel2.Controls.Add(splitContainerChild);
			splitContainerFirst.Size = new Size(723, 503);
			splitContainerFirst.SplitterDistance = 162;
			splitContainerFirst.TabIndex = 0;
			// 
			// textBoxRequirements
			// 
			textBoxRequirements.Dock = DockStyle.Fill;
			textBoxRequirements.Location = new Point(0, 0);
			textBoxRequirements.Multiline = true;
			textBoxRequirements.Name = "textBoxRequirements";
			textBoxRequirements.Size = new Size(723, 162);
			textBoxRequirements.TabIndex = 0;
			textBoxRequirements.Leave += TextBoxRequirements_Leave;
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
			splitContainerChild.Panel1.Controls.Add(textBoxCheckList);
			// 
			// splitContainerChild.Panel2
			// 
			splitContainerChild.Panel2.Controls.Add(dataGridViewErrorList);
			splitContainerChild.Size = new Size(723, 337);
			splitContainerChild.SplitterDistance = 171;
			splitContainerChild.TabIndex = 0;
			// 
			// textBoxCheckList
			// 
			textBoxCheckList.Dock = DockStyle.Fill;
			textBoxCheckList.Location = new Point(0, 0);
			textBoxCheckList.Multiline = true;
			textBoxCheckList.Name = "textBoxCheckList";
			textBoxCheckList.Size = new Size(723, 171);
			textBoxCheckList.TabIndex = 0;
			textBoxCheckList.Leave += TextBoxCheckList_Leave;
			// 
			// dataGridViewErrorList
			// 
			dataGridViewErrorList.AllowUserToOrderColumns = true;
			dataGridViewErrorList.AllowUserToResizeColumns = false;
			dataGridViewErrorList.AllowUserToResizeRows = false;
			dataGridViewErrorList.BackgroundColor = SystemColors.ControlLightLight;
			dataGridViewErrorList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewErrorList.Columns.AddRange(new DataGridViewColumn[] { ColumnId, ColumnText, ColumnWeight, ColumnIsStop });
			dataGridViewErrorList.Dock = DockStyle.Fill;
			dataGridViewErrorList.Location = new Point(0, 0);
			dataGridViewErrorList.Name = "dataGridViewErrorList";
			dataGridViewErrorList.RowHeadersVisible = false;
			dataGridViewErrorList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridViewErrorList.Size = new Size(723, 162);
			dataGridViewErrorList.TabIndex = 0;
			dataGridViewErrorList.RowLeave += DataGridViewErrorList_RowLeave;
			dataGridViewErrorList.UserDeletingRow += DataGridViewErrorList_UserDeletingRow;
			// 
			// ColumnId
			// 
			ColumnId.HeaderText = "Id";
			ColumnId.Name = "ColumnId";
			ColumnId.Visible = false;
			// 
			// ColumnText
			// 
			ColumnText.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			ColumnText.HeaderText = "Текст ошибки";
			ColumnText.Name = "ColumnText";
			// 
			// ColumnWeight
			// 
			ColumnWeight.HeaderText = "Вес";
			ColumnWeight.Name = "ColumnWeight";
			// 
			// ColumnIsStop
			// 
			ColumnIsStop.HeaderText = "Останавливающий";
			ColumnIsStop.Name = "ColumnIsStop";
			// 
			// TaskConfigControl
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(splitContainerFirst);
			Name = "TaskConfigControl";
			Size = new Size(723, 503);
			splitContainerFirst.Panel1.ResumeLayout(false);
			splitContainerFirst.Panel1.PerformLayout();
			splitContainerFirst.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainerFirst).EndInit();
			splitContainerFirst.ResumeLayout(false);
			splitContainerChild.Panel1.ResumeLayout(false);
			splitContainerChild.Panel1.PerformLayout();
			splitContainerChild.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainerChild).EndInit();
			splitContainerChild.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridViewErrorList).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private SplitContainer splitContainerFirst;
		private SplitContainer splitContainerChild;
		private TextBox textBoxRequirements;
		private TextBox textBoxCheckList;
		private DataGridView dataGridViewErrorList;
		private DataGridViewTextBoxColumn ColumnId;
		private DataGridViewTextBoxColumn ColumnText;
		private DataGridViewTextBoxColumn ColumnWeight;
		private DataGridViewCheckBoxColumn ColumnIsStop;
	}
}
