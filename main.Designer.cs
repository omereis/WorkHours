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
			menuMain.SuspendLayout();
			status_bar.SuspendLayout();
			SuspendLayout();
			// 
			// menuMain
			// 
			menuMain.Items.AddRange(new ToolStripItem[] { popupFile });
			menuMain.Location = new Point(0, 0);
			menuMain.Name = "menuMain";
			menuMain.Size = new Size(655, 24);
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
			miFileExit.Size = new Size(180, 22);
			miFileExit.Text = "יציאה";
			miFileExit.Click += miFileExit_Click;
			// 
			// miDatabase
			// 
			miDatabase.Name = "miDatabase";
			miDatabase.Size = new Size(180, 22);
			miDatabase.Text = "מסד נתונים...";
			miDatabase.Click += miDatabase_Click;
			// 
			// status_bar
			// 
			status_bar.Items.AddRange(new ToolStripItem[] { sblblDatabase });
			status_bar.Location = new Point(0, 428);
			status_bar.Name = "status_bar";
			status_bar.Size = new Size(655, 22);
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
			dlgIni.Filter = "ini files (*.ini)|*.txt|All files (*.*)|*.*";
			// 
			// button1
			// 
			button1.Location = new Point(142, 99);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 2;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// trv
			// 
			trv.Location = new Point(266, 49);
			trv.Name = "trv";
			trv.Size = new Size(197, 181);
			trv.TabIndex = 3;
			// 
			// main
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(655, 450);
			Controls.Add(trv);
			Controls.Add(button1);
			Controls.Add(status_bar);
			Controls.Add(menuMain);
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
	}
}
