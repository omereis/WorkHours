namespace WorkHours {
	partial class DlgEditHours {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			btnCancel = new Button();
			btnOK = new Button();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			dtpStartDate = new DateTimePicker();
			comboSubjects = new ComboBox();
			dtpEndDate = new DateTimePicker();
			txtbxDesc = new TextBox();
			clboxOutputs = new CheckedListBox();
			comboStart = new ComboBox();
			label1 = new Label();
			comboEnd = new ComboBox();
			label2 = new Label();
			txtID = new TextBox();
			label6 = new Label();
			txtbxLoc = new TextBox();
			button1 = new Button();
			SuspendLayout();
			// 
			// btnCancel
			// 
			btnCancel.Image = Properties.Resources.Cancel16;
			btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
			btnCancel.Location = new Point(164, 384);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 9;
			btnCancel.Text = "ביטול";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			btnOK.Image = Properties.Resources.ok16;
			btnOK.ImageAlign = ContentAlignment.MiddleLeft;
			btnOK.Location = new Point(52, 384);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 8;
			btnOK.Text = "אישור";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += btnOK_Click;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(210, 139);
			label3.Name = "label3";
			label3.Size = new Size(32, 15);
			label3.TabIndex = 12;
			label3.Text = "נושא";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(223, 168);
			label4.Name = "label4";
			label4.Size = new Size(34, 15);
			label4.TabIndex = 13;
			label4.Text = "תאור";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(223, 269);
			label5.Name = "label5";
			label5.Size = new Size(47, 15);
			label5.TabIndex = 14;
			label5.Text = "תפוקות";
			// 
			// dtpStartDate
			// 
			dtpStartDate.Format = DateTimePickerFormat.Short;
			dtpStartDate.Location = new Point(99, 12);
			dtpStartDate.Name = "dtpStartDate";
			dtpStartDate.Size = new Size(98, 23);
			dtpStartDate.TabIndex = 15;
			// 
			// comboSubjects
			// 
			comboSubjects.FormattingEnabled = true;
			comboSubjects.Location = new Point(76, 136);
			comboSubjects.Name = "comboSubjects";
			comboSubjects.Size = new Size(121, 23);
			comboSubjects.TabIndex = 17;
			// 
			// dtpEndDate
			// 
			dtpEndDate.Format = DateTimePickerFormat.Short;
			dtpEndDate.Location = new Point(99, 51);
			dtpEndDate.Name = "dtpEndDate";
			dtpEndDate.Size = new Size(98, 23);
			dtpEndDate.TabIndex = 19;
			// 
			// txtbxDesc
			// 
			txtbxDesc.Location = new Point(12, 165);
			txtbxDesc.Multiline = true;
			txtbxDesc.Name = "txtbxDesc";
			txtbxDesc.Size = new Size(202, 86);
			txtbxDesc.TabIndex = 21;
			// 
			// clboxOutputs
			// 
			clboxOutputs.FormattingEnabled = true;
			clboxOutputs.Location = new Point(12, 269);
			clboxOutputs.Name = "clboxOutputs";
			clboxOutputs.Size = new Size(202, 94);
			clboxOutputs.TabIndex = 22;
			// 
			// comboStart
			// 
			comboStart.DropDownStyle = ComboBoxStyle.DropDownList;
			comboStart.FormattingEnabled = true;
			comboStart.Items.AddRange(new object[] { "01:00", "01:30", "02:00", "02:30", "03:00", "03:30", "04:00", "04:30", "05:00", "5:30", "06:00", "06:30", "07:00", "07:30", "08:00", "08:30", "9:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30", "21:00", "21:30", "22:00", "22:30", "23:00", "23:30", "00:00" });
			comboStart.Location = new Point(12, 12);
			comboStart.Name = "comboStart";
			comboStart.Size = new Size(81, 23);
			comboStart.TabIndex = 24;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(210, 15);
			label1.Name = "label1";
			label1.Size = new Size(47, 15);
			label1.TabIndex = 25;
			label1.Text = "התחלה";
			// 
			// comboEnd
			// 
			comboEnd.DropDownStyle = ComboBoxStyle.DropDownList;
			comboEnd.FormattingEnabled = true;
			comboEnd.Items.AddRange(new object[] { "01:00", "01:30", "02:00", "02:30", "03:00", "03:30", "04:00", "04:30", "05:00", "5:30", "06:00", "06:30", "07:00", "07:30", "08:00", "08:30", "9:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "12:30", "13:00", "13:30", "14:00", "14:30", "15:00", "15:30", "16:00", "16:30", "17:00", "17:30", "18:00", "18:30", "19:00", "19:30", "20:00", "20:30", "21:00", "21:30", "22:00", "22:30", "23:00", "23:30", "00:00" });
			comboEnd.Location = new Point(12, 51);
			comboEnd.Name = "comboEnd";
			comboEnd.Size = new Size(81, 23);
			comboEnd.TabIndex = 26;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(210, 54);
			label2.Name = "label2";
			label2.Size = new Size(29, 15);
			label2.TabIndex = 27;
			label2.Text = "סיום";
			// 
			// txtID
			// 
			txtID.Location = new Point(12, 96);
			txtID.Name = "txtID";
			txtID.ReadOnly = true;
			txtID.RightToLeft = RightToLeft.No;
			txtID.Size = new Size(47, 23);
			txtID.TabIndex = 28;
			txtID.TextAlign = HorizontalAlignment.Center;
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(210, 99);
			label6.Name = "label6";
			label6.Size = new Size(37, 15);
			label6.TabIndex = 29;
			label6.Text = "מיקום";
			// 
			// txtbxLoc
			// 
			txtbxLoc.Location = new Point(97, 96);
			txtbxLoc.Name = "txtbxLoc";
			txtbxLoc.Size = new Size(100, 23);
			txtbxLoc.TabIndex = 30;
			// 
			// button1
			// 
			button1.Location = new Point(230, 308);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 31;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Visible = false;
			button1.Click += button1_Click;
			// 
			// DlgEditHours
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(304, 430);
			Controls.Add(button1);
			Controls.Add(txtbxLoc);
			Controls.Add(label6);
			Controls.Add(txtID);
			Controls.Add(label2);
			Controls.Add(comboEnd);
			Controls.Add(label1);
			Controls.Add(comboStart);
			Controls.Add(dtpStartDate);
			Controls.Add(clboxOutputs);
			Controls.Add(txtbxDesc);
			Controls.Add(dtpEndDate);
			Controls.Add(comboSubjects);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "DlgEditHours";
			RightToLeft = RightToLeft.Yes;
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "עריכת פרטי פעילות";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnCancel;
		private Button btnOK;
		private Label label3;
		private Label label4;
		private Label label5;
		private DateTimePicker dtpStartDate;
		private ComboBox comboSubjects;
		private DateTimePicker dtpEndDate;
		private TextBox txtbxDesc;
		private CheckedListBox clboxOutputs;
		private ComboBox comboStart;
		private Label label1;
		private ComboBox comboEnd;
		private Label label2;
		private TextBox txtID;
		private Label label6;
		private TextBox txtbxLoc;
		private Button button1;
	}
}