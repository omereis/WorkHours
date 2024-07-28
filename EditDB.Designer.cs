namespace WorkHours {
	partial class EditDB {
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
			btnOK = new Button();
			btnCancel = new Button();
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			txtbxServer = new TextBox();
			txtbxDatabase = new TextBox();
			txtbxUsername = new TextBox();
			txtbxPassword = new TextBox();
			listBox1 = new ListBox();
			label5 = new Label();
			txtbxTitle = new TextBox();
			btnTest = new Button();
			SuspendLayout();
			// 
			// btnOK
			// 
			btnOK.Image = Properties.Resources.ok16;
			btnOK.ImageAlign = ContentAlignment.MiddleLeft;
			btnOK.Location = new Point(106, 220);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 6;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += btnOK_Click;
			// 
			// btnCancel
			// 
			btnCancel.Image = Properties.Resources.Cancel16;
			btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
			btnCancel.Location = new Point(218, 220);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 7;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(87, 63);
			label1.Name = "label1";
			label1.Size = new Size(39, 15);
			label1.TabIndex = 2;
			label1.Text = "Server";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(71, 96);
			label2.Name = "label2";
			label2.Size = new Size(55, 15);
			label2.TabIndex = 3;
			label2.Text = "Database";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(61, 138);
			label3.Name = "label3";
			label3.Size = new Size(65, 15);
			label3.TabIndex = 4;
			label3.Text = "User Name";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(69, 175);
			label4.Name = "label4";
			label4.Size = new Size(57, 15);
			label4.TabIndex = 5;
			label4.Text = "Password";
			// 
			// txtbxServer
			// 
			txtbxServer.Location = new Point(147, 60);
			txtbxServer.Name = "txtbxServer";
			txtbxServer.Size = new Size(100, 23);
			txtbxServer.TabIndex = 1;
			// 
			// txtbxDatabase
			// 
			txtbxDatabase.Location = new Point(147, 93);
			txtbxDatabase.Name = "txtbxDatabase";
			txtbxDatabase.Size = new Size(100, 23);
			txtbxDatabase.TabIndex = 2;
			// 
			// txtbxUsername
			// 
			txtbxUsername.Location = new Point(147, 130);
			txtbxUsername.Name = "txtbxUsername";
			txtbxUsername.Size = new Size(100, 23);
			txtbxUsername.TabIndex = 3;
			// 
			// txtbxPassword
			// 
			txtbxPassword.Location = new Point(147, 167);
			txtbxPassword.Name = "txtbxPassword";
			txtbxPassword.Size = new Size(100, 23);
			txtbxPassword.TabIndex = 4;
			// 
			// listBox1
			// 
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 15;
			listBox1.Location = new Point(32, 41);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(33, 94);
			listBox1.TabIndex = 10;
			listBox1.Visible = false;
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(71, 24);
			label5.Name = "label5";
			label5.Size = new Size(29, 15);
			label5.TabIndex = 11;
			label5.Text = "Title";
			label5.Visible = false;
			// 
			// txtbxTitle
			// 
			txtbxTitle.Location = new Point(147, 21);
			txtbxTitle.Name = "txtbxTitle";
			txtbxTitle.Size = new Size(100, 23);
			txtbxTitle.TabIndex = 0;
			txtbxTitle.Visible = false;
			// 
			// btnTest
			// 
			btnTest.Location = new Point(275, 123);
			btnTest.Name = "btnTest";
			btnTest.Size = new Size(75, 23);
			btnTest.TabIndex = 12;
			btnTest.Text = "Test...";
			btnTest.UseVisualStyleBackColor = true;
			// 
			// EditDB
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(380, 263);
			Controls.Add(btnTest);
			Controls.Add(txtbxTitle);
			Controls.Add(label5);
			Controls.Add(txtbxPassword);
			Controls.Add(txtbxUsername);
			Controls.Add(txtbxDatabase);
			Controls.Add(txtbxServer);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			Controls.Add(listBox1);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "EditDB";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Database Parameters";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnOK;
		private Button btnCancel;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private TextBox txtbxServer;
		private TextBox txtbxDatabase;
		private TextBox txtbxUsername;
		private TextBox txtbxPassword;
		private ListBox listBox1;
		private Label label5;
		private TextBox txtbxTitle;
		private Button btnTest;
	}
}