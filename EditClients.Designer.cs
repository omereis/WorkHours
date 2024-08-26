namespace WorkHours {
	partial class DlgEditClients {
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
		lboxClients = new ListBox();
		label1 = new Label();
		btnCancel = new Button();
		btnOK = new Button();
		txtbxName = new TextBox();
		btnNew = new Button();
		btnUpdate = new Button();
		btnDelete = new Button();
		SuspendLayout();
		// 
		// lboxClients
		// 
		lboxClients.FormattingEnabled = true;
		lboxClients.ItemHeight = 15;
		lboxClients.Location = new Point(84, 29);
		lboxClients.Name = "lboxClients";
		lboxClients.Size = new Size(183, 109);
		lboxClients.TabIndex = 0;
		// 
		// label1
		// 
		label1.AutoSize = true;
		label1.Location = new Point(243, 154);
		label1.Name = "label1";
		label1.Size = new Size(24, 15);
		label1.TabIndex = 1;
		label1.Text = "שם";
		// 
		// btnCancel
		// 
		btnCancel.Image = Properties.Resources.Cancel16;
		btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
		btnCancel.Location = new Point(156, 264);
		btnCancel.Name = "btnCancel";
		btnCancel.Size = new Size(75, 23);
		btnCancel.TabIndex = 9;
		btnCancel.Text = " ביטול";
		btnCancel.UseVisualStyleBackColor = true;
		// 
		// btnOK
		// 
		btnOK.Image = Properties.Resources.ok16;
		btnOK.ImageAlign = ContentAlignment.MiddleLeft;
		btnOK.Location = new Point(44, 264);
		btnOK.Name = "btnOK";
		btnOK.Size = new Size(75, 23);
		btnOK.TabIndex = 8;
		btnOK.Text = "אישור";
		btnOK.UseVisualStyleBackColor = true;
		btnOK.Click += btnOK_Click;
		// 
		// txtbxName
		// 
		txtbxName.Location = new Point(84, 172);
		txtbxName.Name = "txtbxName";
		txtbxName.Size = new Size(183, 23);
		txtbxName.TabIndex = 10;
		// 
		// btnNew
		// 
		btnNew.Location = new Point(220, 205);
		btnNew.Name = "btnNew";
		btnNew.Size = new Size(75, 23);
		btnNew.TabIndex = 11;
		btnNew.Text = "חדש";
		btnNew.UseVisualStyleBackColor = true;
		btnNew.Click += btnNew_Click;
		// 
		// btnUpdate
		// 
		btnUpdate.Location = new Point(127, 205);
		btnUpdate.Name = "btnUpdate";
		btnUpdate.Size = new Size(75, 23);
		btnUpdate.TabIndex = 12;
		btnUpdate.Text = "עידכון";
		btnUpdate.UseVisualStyleBackColor = true;
		btnUpdate.Click += btnUpdate_Click;
		// 
		// btnDelete
		// 
		btnDelete.Location = new Point(44, 205);
		btnDelete.Name = "btnDelete";
		btnDelete.Size = new Size(75, 23);
		btnDelete.TabIndex = 13;
		btnDelete.Text = "מחיקה...";
		btnDelete.UseVisualStyleBackColor = true;
		// 
		// DlgEditClients
		// 
		AcceptButton = btnOK;
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		CancelButton = btnCancel;
		ClientSize = new Size(304, 315);
		Controls.Add(btnDelete);
		Controls.Add(btnUpdate);
		Controls.Add(btnNew);
		Controls.Add(txtbxName);
		Controls.Add(btnCancel);
		Controls.Add(btnOK);
		Controls.Add(label1);
		Controls.Add(lboxClients);
		MaximizeBox = false;
		MinimizeBox = false;
		Name = "DlgEditClients";
		RightToLeft = RightToLeft.Yes;
		StartPosition = FormStartPosition.CenterScreen;
		Text = "לקוחות";
		FormClosed += DlgEditClients_FormClosed;
		Load += DlgEditClients_Load;
		ResumeLayout(false);
		PerformLayout();
		}

		#endregion

		private ListBox lboxClients;
		private Label label1;
		private Button btnCancel;
		private Button btnOK;
		private TextBox txtbxName;
		private Button btnNew;
		private Button btnUpdate;
		private Button btnDelete;
	}
}