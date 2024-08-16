namespace WorkHours {
	partial class main {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			menuMain = new MenuStrip();
			popupFile = new ToolStripMenuItem();
			miFileExit = new ToolStripMenuItem();
			miDatabase = new ToolStripMenuItem();
			status_bar = new StatusStrip();
			sblblDatabase = new ToolStripStatusLabel();
			dlgIni = new OpenFileDialog();
			button1 = new Button();
			trv = new TreeView();
			button2 = new Button();
			txtbx = new TextBox();
			lstbx = new ListBox();
			button3 = new Button();
			button4 = new Button();
			txtbxIni = new TextBox();
			button5 = new Button();
			menuMain.SuspendLayout();
			status_bar.SuspendLayout();
			SuspendLayout();
			// 
			// menuMain
			// 
			menuMain.Items.AddRange(new ToolStripItem[] { popupFile });
			menuMain.Location = new Point(0, 0);
			menuMain.Name = "menuMain";
			menuMain.Size = new Size(680, 24);
			menuMain.TabIndex = 0;
			menuMain.Text = "menuStrip1";
			// 
			// popupFile
			// 
			popupFile.DropDownItems.AddRange(new ToolStripItem[] { miFileExit, miDatabase });
			popupFile.Name = "popupFile";
			popupFile.Size = new Size(44, 20);
			popupFile.Text = "קובץ";
			// 
			// miFileExit
			// 
			miFileExit.Name = "miFileExit";
			miFileExit.Size = new Size(141, 22);
			miFileExit.Text = "יציאה";
			miFileExit.Click += miFileExit_Click;
			// 
			// miDatabase
			// 
			miDatabase.Name = "miDatabase";
			miDatabase.Size = new Size(141, 22);
			miDatabase.Text = "מסד נתונים...";
			miDatabase.Click += miDatabase_Click;
			// 
			// status_bar
			// 
			status_bar.Items.AddRange(new ToolStripItem[] { sblblDatabase });
			status_bar.Location = new Point(0, 383);
			status_bar.Name = "status_bar";
			status_bar.Size = new Size(680, 22);
			status_bar.TabIndex = 1;
			status_bar.Text = "statusStrip1";
			// 
			// sblblDatabase
			// 
			sblblDatabase.Name = "sblblDatabase";
			sblblDatabase.Size = new Size(118, 17);
			sblblDatabase.Text = "toolStripStatusLabel1";
			// 
			// dlgIni
			// 
			dlgIni.DefaultExt = "*.ini";
			dlgIni.Filter = "ini files (*.ini)|*.ini|All files (*.*)|*.*";
			// 
			// button1
			// 
			button1.Location = new Point(92, 74);
			button1.Name = "button1";
			button1.Size = new Size(111, 23);
			button1.TabIndex = 2;
			button1.Text = "Sections from File";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// trv
			// 
			trv.Location = new Point(264, 24);
			trv.Name = "trv";
			trv.Size = new Size(197, 181);
			trv.TabIndex = 3;
			// 
			// button2
			// 
			button2.Location = new Point(106, 245);
			button2.Name = "button2";
			button2.Size = new Size(75, 23);
			button2.TabIndex = 4;
			button2.Text = "button2";
			button2.UseVisualStyleBackColor = true;
			button2.Click += button2_Click;
			// 
			// txtbx
			// 
			txtbx.Location = new Point(142, 207);
			txtbx.Name = "txtbx";
			txtbx.RightToLeft = RightToLeft.No;
			txtbx.Size = new Size(100, 23);
			txtbx.TabIndex = 5;
			// 
			// lstbx
			// 
			lstbx.FormattingEnabled = true;
			lstbx.ItemHeight = 15;
			lstbx.Location = new Point(264, 220);
			lstbx.Name = "lstbx";
			lstbx.RightToLeft = RightToLeft.No;
			lstbx.Size = new Size(197, 94);
			lstbx.TabIndex = 6;
			// 
			// button3
			// 
			button3.Location = new Point(502, 82);
			button3.Name = "button3";
			button3.Size = new Size(104, 23);
			button3.TabIndex = 7;
			button3.Text = "read database";
			button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			button4.Location = new Point(502, 120);
			button4.Name = "button4";
			button4.Size = new Size(104, 23);
			button4.TabIndex = 8;
			button4.Text = "save database";
			button4.UseVisualStyleBackColor = true;
			button4.Click += button4_Click;
			// 
			// txtbxIni
			// 
			txtbxIni.Location = new Point(11, 345);
			txtbxIni.Name = "txtbxIni";
			txtbxIni.Size = new Size(595, 23);
			txtbxIni.TabIndex = 9;
			// 
			// button5
			// 
			button5.Location = new Point(69, 316);
			button5.Name = "button5";
			button5.Size = new Size(75, 23);
			button5.TabIndex = 10;
			button5.Text = "ini";
			button5.UseVisualStyleBackColor = true;
			button5.Click += button5_Click;
			// 
			// main
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(680, 405);
			Controls.Add(button5);
			Controls.Add(button1);
			Controls.Add(txtbxIni);
			Controls.Add(status_bar);
			Controls.Add(trv);
			Controls.Add(menuMain);
			Controls.Add(button4);
			Controls.Add(lstbx);
			Controls.Add(button2);
			Controls.Add(txtbx);
			Controls.Add(button3);
			MainMenuStrip = menuMain;
			Name = "main";
			RightToLeft = RightToLeft.Yes;
			Text = "ניהול שעות עבודה";
			Load += main_Load;
			menuMain.ResumeLayout(false);
			menuMain.PerformLayout();
			status_bar.ResumeLayout(false);
			status_bar.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private MenuStrip menuMain;
		private ToolStripMenuItem popupFile;
		private ToolStripMenuItem miFileExit;
		private ToolStripMenuItem miDatabase;
		private StatusStrip status_bar;
		private ToolStripStatusLabel sblblDatabase;
		private OpenFileDialog dlgIni;
		private Button button1;
		private TreeView trv;
		private Button button2;
		private TextBox txtbx;
		private ListBox lstbx;
		private Button button3;
		private Button button4;
		private TextBox txtbxIni;
		private Button button5;
	}
}
