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
			miDatabase = new ToolStripMenuItem();
			miFileExit = new ToolStripMenuItem();
			popupSupport = new ToolStripMenuItem();
			miClients = new ToolStripMenuItem();
			miSubjects = new ToolStripMenuItem();
			status_bar = new StatusStrip();
			sblblDatabase = new ToolStripStatusLabel();
			dlgIni = new OpenFileDialog();
			gridHours = new DataGridView();
			Column1 = new DataGridViewTextBoxColumn();
			Column2 = new DataGridViewTextBoxColumn();
			Column3 = new DataGridViewTextBoxColumn();
			Column4 = new DataGridViewTextBoxColumn();
			Column6 = new DataGridViewTextBoxColumn();
			Column7 = new DataGridViewTextBoxColumn();
			Column8 = new DataGridViewTextBoxColumn();
			menuMain.SuspendLayout();
			status_bar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)gridHours).BeginInit();
			SuspendLayout();
			// 
			// menuMain
			// 
			menuMain.Items.AddRange(new ToolStripItem[] { popupFile, popupSupport });
			menuMain.Location = new Point(0, 0);
			menuMain.Name = "menuMain";
			menuMain.Size = new Size(970, 24);
			menuMain.TabIndex = 0;
			menuMain.Text = "menuStrip1";
			// 
			// popupFile
			// 
			popupFile.DropDownItems.AddRange(new ToolStripItem[] { miDatabase, miFileExit });
			popupFile.Name = "popupFile";
			popupFile.Size = new Size(44, 20);
			popupFile.Text = "קובץ";
			// 
			// miDatabase
			// 
			miDatabase.Name = "miDatabase";
			miDatabase.Size = new Size(141, 22);
			miDatabase.Text = "מסד נתונים...";
			miDatabase.Click += miDatabase_Click;
			// 
			// miFileExit
			// 
			miFileExit.Name = "miFileExit";
			miFileExit.Size = new Size(141, 22);
			miFileExit.Text = "יציאה";
			miFileExit.Click += miFileExit_Click;
			// 
			// popupSupport
			// 
			popupSupport.DropDownItems.AddRange(new ToolStripItem[] { miClients, miSubjects });
			popupSupport.Name = "popupSupport";
			popupSupport.Size = new Size(65, 20);
			popupSupport.Text = "נתוני עזר";
			// 
			// miClients
			// 
			miClients.Name = "miClients";
			miClients.Size = new Size(180, 22);
			miClients.Text = "לקוחות...";
			miClients.Click += miClients_Click_1;
			// 
			// miSubjects
			// 
			miSubjects.Name = "miSubjects";
			miSubjects.Size = new Size(180, 22);
			miSubjects.Text = "נושאי עבודה...";
			miSubjects.Click += miSubjects_Click;
			// 
			// status_bar
			// 
			status_bar.Items.AddRange(new ToolStripItem[] { sblblDatabase });
			status_bar.Location = new Point(0, 383);
			status_bar.Name = "status_bar";
			status_bar.RightToLeft = RightToLeft.No;
			status_bar.Size = new Size(970, 22);
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
			// gridHours
			// 
			gridHours.AllowUserToAddRows = false;
			gridHours.AllowUserToDeleteRows = false;
			gridHours.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			gridHours.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column6, Column7, Column8 });
			gridHours.EditMode = DataGridViewEditMode.EditProgrammatically;
			gridHours.Location = new Point(206, 38);
			gridHours.MultiSelect = false;
			gridHours.Name = "gridHours";
			gridHours.RowHeadersVisible = false;
			gridHours.Size = new Size(752, 309);
			gridHours.TabIndex = 2;
			// 
			// Column1
			// 
			Column1.HeaderText = "תאריך";
			Column1.Name = "Column1";
			// 
			// Column2
			// 
			Column2.HeaderText = "התחלה";
			Column2.Name = "Column2";
			// 
			// Column3
			// 
			Column3.HeaderText = "סיום";
			Column3.Name = "Column3";
			// 
			// Column4
			// 
			Column4.HeaderText = "שעות";
			Column4.Name = "Column4";
			// 
			// Column6
			// 
			Column6.HeaderText = "אישור";
			Column6.Name = "Column6";
			// 
			// Column7
			// 
			Column7.HeaderText = "תשלום";
			Column7.Name = "Column7";
			// 
			// Column8
			// 
			Column8.HeaderText = "דיווח";
			Column8.Name = "Column8";
			// 
			// main
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(970, 405);
			Controls.Add(gridHours);
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
			((System.ComponentModel.ISupportInitialize)gridHours).EndInit();
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
		private DataGridView gridHours;
		private DataGridViewTextBoxColumn Column1;
		private DataGridViewTextBoxColumn Column2;
		private DataGridViewTextBoxColumn Column3;
		private DataGridViewTextBoxColumn Column4;
		private DataGridViewTextBoxColumn Column6;
		private DataGridViewTextBoxColumn Column7;
		private DataGridViewTextBoxColumn Column8;
		private ToolStripMenuItem popupSupport;
		private ToolStripMenuItem miClients;
		private ToolStripMenuItem miSubjects;
	}
}
