/****************************************************************************\
|                                   main.cs                                  |
\****************************************************************************/
using MySql.Data.MySqlClient;
/*
 datbase: const_hours
username: omer_sqa
password: rotem24
*/
//using MySql.Data;
//using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using OmerEisGlobal;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Linq;
using OmerEisCommon;
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
				TIniFile ini = new TIniFile(GetIniName());
				string strDB = ini.ReadString("Database", "Production");
				string strConn;
				if(strDB.Length > 0) {
					TDBParams db_params = new TDBParams();
					db_params.FromJson(strDB);
					strConn = db_params.GetConnectionString();
				} else
					//strConn = string.Format("Server='{0}'; database='{1}'; UID='{2}'; password='{3}',CharSet=utf8", "127.0.0.1", "const_hours", "omer_sqa", "rotem24");
					strConn = string.Format("Server='{0}'; database='{1}'; UID='{2}'; password='{3}'", "127.0.0.1", "const_hours", "omer_sqa", "rotem24");
				try {
					m_database = new MySqlConnection(strConn);
				}
				catch(Exception ex) {
					MessageBox.Show(ex.Message);
				}
				try {
					m_database.Open();
					m_cmd = new MySqlCommand();
					m_cmd.Connection = m_database;

					//MessageBox.Show("Connected");
				}
				catch(Exception ex) {
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
			TIniFile ini = new TIniFile(GetIniName());
			bool fParams = false;
			string strJsonConn = ini.ReadString("Database", "Production");
			if(strJsonConn.Length > 0)
				fParams = db_params.FromJson(strJsonConn);
			if(!fParams) {
				db_params.Database = "const_hours";
				db_params.Server = "127.0.0.1";
				db_params.Username = "omer_sqa";
				db_params.Password = "rotem24";
			}
			//string strConn = string.Format("Server='{0}'; database='{1}'; UID='{2}'; password='{3}'", "127.0.0.1", "const_hours", "omer_sqa", "rotem24");

			EditDB dlg = new EditDB();
			if(dlg.Execute(db_params)) {
				ini = new TIniFile(GetIniName());
				ini.WriteString("Database", "Production", db_params.ToJson());// .GetConnectionString());
			}
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
//------------------------------------------------------------------------------
		private void button2_Click(object sender, EventArgs e) {
			TreeNode node = trv.SelectedNode;
			TIniFile ini = new TIniFile(dlgIni.FileName);

			lstbx.Items.Clear();
			if(node == null)
				txtbx.Text = "";
			else {
				txtbx.Text = node.Text.Trim();
				string[] astr = ini.Keys(node.Text.Trim());
				for(int n = 0; n < astr?.Length; n++)
					lstbx.Items.Add(astr[n]);
			}
		}
//------------------------------------------------------------------------------
		private string GetIniName() {
			string str = Environment.GetCommandLineArgs()[0];//Application.StartupPath;
			string strIni = Path.ChangeExtension(str, ".ini");
			return (strIni);
		}
//------------------------------------------------------------------------------
		private void button4_Click(object sender, EventArgs e) {
			TIniFile ini = new TIniFile(GetIniName());
			string strDB = ini.ReadString("Database", "Production");

		}

		private void button5_Click(object sender, EventArgs e) {
			txtbxIni.Text = GetIniName();
		}
//------------------------------------------------------------------------------
		private double CheckInternewtTime() {
			// Create Object Of WebClient
			System.Net.WebClient wc = new System.Net.WebClient();

			//DateTime Variable To Store Download Start Time.
			DateTime dt1 = DateTime.UtcNow;

			//Number Of Bytes Downloaded Are Stored In �data�
			byte[] data = wc.DownloadData("http://google.com");

			//DateTime Variable To Store Download End Time.
			DateTime dt2 = DateTime.UtcNow;

			//To Calculate Speed in Kb Divide Value Of data by 1024 And Then by End Time Subtract Start Time To Know Download Per Second.
			return Math.Round((data.Length / 1024) / (dt2 - dt1).TotalSeconds, 2);
		}
//------------------------------------------------------------------------------
		private void miClients_Click(object sender, EventArgs e) {
			DlgEditClients dlg = new DlgEditClients();
			dlg.Execute(m_cmd);
		}
//------------------------------------------------------------------------------
	}
}
