namespace WorkHours {
	partial class EditHours {
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
			SuspendLayout();
			// 
			// btnCancel
			// 
			btnCancel.Image = Properties.Resources.Cancel16;
			btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
			btnCancel.Location = new Point(356, 398);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 9;
			btnCancel.Text = "Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			btnOK.Image = Properties.Resources.ok16;
			btnOK.ImageAlign = ContentAlignment.MiddleLeft;
			btnOK.Location = new Point(244, 398);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(75, 23);
			btnOK.TabIndex = 8;
			btnOK.Text = "OK";
			btnOK.UseVisualStyleBackColor = true;
			// 
			// EditHours
			// 
			AcceptButton = btnOK;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(800, 450);
			Controls.Add(btnCancel);
			Controls.Add(btnOK);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "EditHours";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "EditHours";
			ResumeLayout(false);
		}

		#endregion

		private Button btnCancel;
		private Button btnOK;
	}
}