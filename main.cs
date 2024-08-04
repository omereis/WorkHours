/****************************************************************************\
|                                   main.cs                                  |
\****************************************************************************/
using MySql.Data.MySqlClient;


//using MySql.Data;
//using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using OmerEisGlobal;
//-----------------------------------------------------------------------------
namespace WorkHours {
	public partial class main : Form {
		private MySqlConnection m_database;
		private MySqlCommand m_cmd;
		public main() {
			InitializeComponent();
		}
		//------------------------------------------------------------------------------
		private void miFileExit_Click(object sender, EventArgs e) {
			Close();
		}
		//------------------------------------------------------------------------------
		private void main_Load(object sender, EventArgs e) {
			Application.Idle += OnIdle;
			if(m_database == null) {
				string strConn = string.Format("Server='{0}'; database='{1}'; UID='{2}'; password='{3}'", "127.0.0.1", "const_hours", "omer_sqa", "rotem24");
				m_database = new MySqlConnection(strConn);
				try {
					m_database.Open();
					m_cmd = new MySqlCommand();
					m_cmd.Connection = m_database;

					//MessageBox.Show("Connected");
				} catch(Exception ex) {
					MessageBox.Show(ex.Message);
				}
			}
		}
		//-----------------------------------------------------------------------------
		private void OnIdle(object sender, EventArgs e) {
			UpdateStatusBar();
		}
		//-----------------------------------------------------------------------------
		private void UpdateStatusBar() {
			if(IsDatabaseConnected())
				sblblDatabase.Text = m_database.Database + " Connected";
			else
				sblblDatabase.Text = "Database Disconnected";
		}
		//-----------------------------------------------------------------------------
		private bool IsDatabaseConnected() {
			bool fOpen = false;

			if(m_database != null)
				if(m_database.State == System.Data.ConnectionState.Open)
					fOpen = true;
			return (fOpen);
		}
		//------------------------------------------------------------------------------
		private void miDatabase_Click(object sender, EventArgs e) {
			TDBParams db_params = new TDBParams();
			db_params.Database = "const_hours";
			db_params.Server = "127.0.0.1";
			db_params.Username = "omer_sqa";
			db_params.Password = "rotem24";
			//string strConn = string.Format("Server='{0}'; database='{1}'; UID='{2}'; password='{3}'", "127.0.0.1", "const_hours", "omer_sqa", "rotem24");
	
			EditDB dlg = new EditDB();
			dlg.Execute(db_params);
		}
		//------------------------------------------------------------------------------
		private void button1_Click(object sender, EventArgs e) {
			if(dlgIni.ShowDialog() == DialogResult.OK) {
				TIniFile ini = new TIniFile(dlgIni.FileName);
				string[] astr = ini.Sections();
				trv.Nodes.Clear();
				if(astr != null) {
					for(int n = 0; n < astr.Length; n++) {
						trv.Nodes.Add(astr[n]);
					}
				}
			}
		}

		private void button2_Click(object sender, EventArgs e) {
			TreeNode node = trv.SelectedNode;
			TIniFile ini = new TIniFile(dlgIni.FileName);

			lstbx.Items.Clear();
			if (node == null)
				txtbx.Text = "";
			else {
				txtbx.Text = node.Text.Trim();
				string[] astr = ini.Keys(node.Text.Trim());
				for (int n=0 ; n < astr?.Length ; n++)
					lstbx.Items.Add(astr[n]);
			}
		}
		//------------------------------------------------------------------------------
	}
}
