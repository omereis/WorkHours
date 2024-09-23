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
using System.Text.RegularExpressions;
using System.Collections;
//-----------------------------------------------------------------------------
namespace WorkHours {
	public partial class main : Form {
		private MySqlConnection m_database;
		private MySqlCommand m_cmd;
		private string m_strErr = "";
//-----------------------------------------------------------------------------
		public static readonly int colStartDate = 1;
		public static readonly int colStartTime = 2;
		public static readonly int colEndDate = 3;
		public static readonly int colEndTime = 4;
		public static readonly int colSubjects = 5;
		public static readonly int colOutputs = 6;
		public static readonly int colHours = 7;
//-----------------------------------------------------------------------------
		public main() {
			InitializeComponent();
		}
//-----------------------------------------------------------------------------
		private void miFileExit_Click(object sender, EventArgs e) {
			Close();
		}
//-----------------------------------------------------------------------------
		private void main_Load(object sender, EventArgs e) {
			Application.Idle += OnIdle;
			ConnectToDB();
			if(m_database != null)
				LoadWorkHours();
		}
//-----------------------------------------------------------------------------
		private void ConnectToDB() {
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
				} catch(Exception ex) {
					MessageBox.Show(ex.Message);
				}
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
//-----------------------------------------------------------------------------
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
//-----------------------------------------------------------------------------
		private string GetIniName() {
			string str = Environment.GetCommandLineArgs()[0];//Application.StartupPath;
			string strIni = Path.ChangeExtension(str, ".ini");
			return (strIni);
		}
//-----------------------------------------------------------------------------
		private double CheckInternewtTime() {
			// Create Object Of WebClient
			System.Net.WebClient wc = new System.Net.WebClient();

			//DateTime Variable To Store Download Start Time.
			DateTime dt1 = DateTime.UtcNow;

			//Number Of Bytes Downloaded Are Stored In ‘data’
			byte[] data = wc.DownloadData("http://google.com");

			//DateTime Variable To Store Download End Time.
			DateTime dt2 = DateTime.UtcNow;

			//To Calculate Speed in Kb Divide Value Of data by 1024 And Then by End Time Subtract Start Time To Know Download Per Second.
			return Math.Round((data.Length / 1024) / (dt2 - dt1).TotalSeconds, 2);
		}
//-----------------------------------------------------------------------------
		private void miClients_Click_1(object sender, EventArgs e) {
			DlgEditItems dlg = new DlgEditItems();
			dlg.Execute(m_cmd, new TClients());
		}
//-----------------------------------------------------------------------------
		private void miSubjects_Click(object sender, EventArgs e) {
			DlgEditItems dlg = new DlgEditItems();
			dlg.Execute(m_cmd, new TSubjects());
		}
//-----------------------------------------------------------------------------
		private void miOutputs_Click(object sender, EventArgs e) {
			DlgEditItems dlg = new DlgEditItems();
			dlg.Execute(m_cmd, new TOutputs());
		}
//-----------------------------------------------------------------------------
		private bool EditWorkHours (TWorkHoursInfo wh) {
			DlgEditHours dlg = new DlgEditHours();
			return (dlg.Execute(m_cmd, wh));
		}
//-----------------------------------------------------------------------------
		private void miHoursNew_Click(object sender, EventArgs e) {
			bool f = true;
			TWorkHoursInfo wh = new TWorkHoursInfo();
			if((f = wh.InsertAsNew(m_cmd, ref m_strErr)) == true) {
				AddWorkHours(wh);
				if (EditWorkHours (wh))
				//if(dlg.Execute(m_cmd, wh))
					if((f = wh.UpdateInDB(m_cmd, ref m_strErr)) == true)
						UpdateWorkHours(wh);
			}
			if(!f) {
				MessageBox.Show(m_strErr);
				if(!wh.DeleteFromDB(m_cmd, ref m_strErr))
					MessageBox.Show(m_strErr);
			}
		}
//-----------------------------------------------------------------------------
		private void AddWorkHours(TWorkHoursInfo wh) {
			if(wh != null) {
				int row = FindWhByID(wh.ID);
				if(row < 0)
					row = gridHours.Rows.Add();
				DownloadToRow(wh, row);
			}
		}
//-----------------------------------------------------------------------------
		private void UpdateWorkHours(TWorkHoursInfo wh) {
			if(wh != null) {
				int row = FindWhByID(wh.ID);
				if(row >= 0)
					DownloadToRow(wh, row);
			}
		}

//-----------------------------------------------------------------------------
		private int FindWhByID(int id) {
			int rFound = -1;

			for(int n = 0; (n < gridHours.Rows.Count) && (rFound < 0); n++) {
				if(gridHours.Rows[n].Cells[0].Tag != null) {
					TWorkHoursInfo wh;
					try {
						wh = (TWorkHoursInfo)gridHours.Rows[n].Cells[0].Tag;
						if(wh.ID == id)
							rFound = n;
					} catch {
					}
				}
			}
			return (rFound);
		}
//-----------------------------------------------------------------------------
		private void DownloadToRow(TWorkHoursInfo wh, int row) {
			if((wh != null) && (row >= 0) && (row < gridHours.Rows.Count)) {
				gridHours.Rows[row].Cells[0].Tag = wh;
				gridHours.Rows[row].Cells[colStartDate].Value = TMisc.GetDateString(wh.Start);
				gridHours.Rows[row].Cells[colStartTime].Value = TMisc.GetTimeString(wh.Start);//Value.ToShortTimeString();
				gridHours.Rows[row].Cells[colEndDate].Value = TMisc.GetDateString(wh.End);//.Value.ToShortDateString();
				gridHours.Rows[row].Cells[colEndTime].Value = TMisc.GetTimeString(wh.End);//.Value.ToShortTimeString();
				gridHours.Rows[row].Cells[colSubjects].Value = wh.GetSubjectName();
				gridHours.Rows[row].Cells[colOutputs].Value = wh.GetOutputsNames();
				gridHours.Rows[row].Cells[colHours].Value = wh.GetWorkHours();
			}
		}
//-----------------------------------------------------------------------------
		private void button1_Click(object sender, EventArgs e) {
			LoadWorkHours();
			textBox2.Text = Regex.Replace(textBox1.Text, "'", "''");
		}
//-----------------------------------------------------------------------------
		private void LoadWorkHours() {
			TWorkHoursInfo[] aWorkHours = null;
			if(m_cmd != null) {
				if(TWorkHoursInfo.LoadAll(m_cmd, ref aWorkHours, ref m_strErr))
					DownloadWorkHours(aWorkHours);
				else
					MessageBox.Show(m_strErr);
			}
		}
//-----------------------------------------------------------------------------
		private void DownloadWorkHours(TWorkHoursInfo[] aWorkHours) {
			gridHours.Rows.Clear();
			gridHours.Rows.Add(aWorkHours.Length);
			for(int n = 0; n < aWorkHours.Length; n++)
				DownloadToRow(aWorkHours[n], n);
		}
//-----------------------------------------------------------------------------
		private void main_FormClosed(object sender, FormClosedEventArgs e) {
			if(m_database != null)
				m_database.Close();
		}
//-----------------------------------------------------------------------------
		private int LoadCurrentID () {
			int id = 0;
			TWorkHoursInfo wh = null;

			if (gridHours.CurrentRow != null)
				wh = (TWorkHoursInfo) gridHours.CurrentRow.Cells[0].Tag;
			if (wh != null)
				id = wh.ID;
			return (id);
		}
//-----------------------------------------------------------------------------
		private void miHoursEdit_Click(object sender, EventArgs e) {
			TWorkHoursInfo wh = new TWorkHoursInfo();
			if ((wh.ID = LoadCurrentID ()) > 0) {
				if (wh.LoadByID (m_cmd, ref m_strErr)) {
					if (EditWorkHours (wh))
						DownloadToRow(wh, gridHours.CurrentRow.Index);
				}
			}
		}
//-----------------------------------------------------------------------------
	}
}
