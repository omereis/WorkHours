/******************************************************************************\
|                                  EditDB.cs                                   |
\******************************************************************************/
using WorkHours;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OmerEisGlobal;
using MySql.Data.MySqlClient;

namespace WorkHours {
	public partial class EditDB : Form {
		public EditDB() {
			InitializeComponent();
		}
		//------------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
		//------------------------------------------------------------------------------
		public bool Execute(TDBParams db_params) {
			Download(db_params);
			bool f = (ShowDialog() == DialogResult.OK);
			if(f)
				Upload(db_params);
			return (f);
		}
		//------------------------------------------------------------------------------
		private void Download(TDBParams db_params) {
			txtbxServer.Text = db_params.Server;
			txtbxDatabase.Text = db_params.Database;
			txtbxUsername.Text = db_params.Username;
			txtbxPassword.Text = db_params.Password;
		}
		//------------------------------------------------------------------------------
		private void Upload(TDBParams db_params) {
			db_params.Server = txtbxServer.Text;
			db_params.Database = txtbxDatabase.Text;
			db_params.Username = txtbxUsername.Text;
			db_params.Password = txtbxPassword.Text;
		}
		//------------------------------------------------------------------------------
		private void btnTest_Click(object sender, EventArgs e) {
			TDBParams db_params = new TDBParams();
			Upload(db_params);
			MySqlConnection database = null;
			Cursor c = Cursor.Current;
			try {
				Cursor.Current = Cursors.WaitCursor;
				database = new MySqlConnection(db_params.GetConnectionString());
				database.Open();
				MessageBox.Show("Database open");
				database.Close();
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}
			finally {
				Cursor.Current = c;
			}
		}
//------------------------------------------------------------------------------
		private void button2_Click(object sender, EventArgs e) {
			Download(new TDBParams());
		}
//------------------------------------------------------------------------------
		private void button1_Click(object sender, EventArgs e) {
			TDBParams db_params = new TDBParams();
			if(db_params.FromJson(txtJson.Text))
				Download(db_params);
		}
//------------------------------------------------------------------------------
		private void button3_Click(object sender, EventArgs e) {
			TDBParams db_params = new TDBParams();
			Upload(db_params);
			txtJson.Text = db_params.ToJson();
		}
//------------------------------------------------------------------------------
	}
}
