/****************************************************************************\
|                                EditClients.cs                              |
\****************************************************************************/
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using OmerEisCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkHours {
	public partial class DlgEditClients : Form {
		private MySqlCommand m_cmd;
		string m_strErr = "";
		//------------------------------------------------------------------------------
		public DlgEditClients() {
		InitializeComponent();
		}
//------------------------------------------------------------------------------
		public bool Execute(MySqlCommand cmd) {
			bool fEdit;
			
			if ((fEdit = Download(cmd)) == true) {
				fEdit = ShowDialog() == DialogResult.OK;
				if(fEdit)
					Upload();
			}
			return (fEdit);
		}
//------------------------------------------------------------------------------
		private bool Download(MySqlCommand cmd) {
			bool fDownload;
			m_cmd = cmd;
			TClients clients = new TClients();
			lboxClients.Items.Clear();
			if ((fDownload = clients.LoadFromDB(cmd, ref m_strErr)) == true) {
				for(int n = 0; n < clients.Items.Length ; n++)
					lboxClients.Items.Add(clients.Items[n]);
			}
			else
				MessageBox.Show(m_strErr);
			return (fDownload);
		}
//------------------------------------------------------------------------------
		private void Upload() {
			TClients clients = UploadClients();
			int id=0;

			if (clients != null)
				clients.SaveToDB (m_cmd, ref m_strErr);
/*
				for (int n = 0; n < clients.Items.Length ; n++) {
					TClient client = (TClient) clients.Items[n];
					if (client != null) {
						if (client.ID > 0) {
							if (!client.UpdateInDB (m_cmd, ref m_strErr))
								MessageBox.Show (m_strErr);
						}
						else {
							if (client.InsertAsNew (m_cmd, ref id,ref m_strErr))
								client.ID = id;
							else
								MessageBox.Show (m_strErr);
						}
					}
				}
*/
/*
				if (clientList != null)
				foreach (var kvp in clientList)
					TClient client = (TClient) kvp;
				nMinID = Math.Min(nMinID, kvp.Key);
				for (int n = 0; n < clientList.Items.Count ; n++) {
					TClient client = clientList.Items[n];
				}
			}
*/
		}
//------------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}
//------------------------------------------------------------------------------
		private void DlgEditClients_Load(object sender, EventArgs e) {
			Application.Idle += OnIdle;
		}
//-----------------------------------------------------------------------------
		private void OnIdle(object sender, EventArgs e) {
		//
		}
//-----------------------------------------------------------------------------
		private void DlgEditClients_FormClosed(object sender, FormClosedEventArgs e) {
			Application.Idle -= OnIdle;
		}
//------------------------------------------------------------------------------
		private void btnNew_Click(object sender, EventArgs e) {
			UpdateCurrent();
			TClient client = NewClient();
			if(client != null) {
				DownloadClient(client);
				lboxClients.Items.Add(client);
			}
		}
//------------------------------------------------------------------------------
		private void UpdateCurrent() {
			TClient client = UploadFromText();
			if(client != null) {
				int idx = FindClientByID(client.ID);
				if(idx >= 0)
					lboxClients.Items[idx] = new TClient(client);
			}
		}
//------------------------------------------------------------------------------
		private void DownloadClient(TClient client) {
			if(client != null) {
				txtbxName.Text = client.Name;
				txtbxName.Tag = client;
			} else {
				txtbxName.Text = "";
				txtbxName.Tag = null;
			}
		}
//------------------------------------------------------------------------------
		private TClient UploadFromText() {
			TClient client = txtbxName.Tag as TClient;
			if(client != null)
				client.Name = txtbxName.Text.Trim();
			return (client);
		}
//------------------------------------------------------------------------------
		private int FindClientByID(int id) {
			int n, nFound = -1;

			for(n = 0; (n < lboxClients.Items.Count) && (nFound < 0); n++) {
				TClient client;
				try {
					client = (TClient)lboxClients.Items[n];
				}
				catch(Exception e) {
					client = null;
					Console.WriteLine(e.ToString());
				}
				if(client != null)
					if(client.ID == id)
						nFound = n;
			}
			return (nFound);
		}
//------------------------------------------------------------------------------
		private TClient NewClient() {
		//TClient client = new TClient();
			TClients clientList = UploadClients();
			TClient client = TClient.CreateNewClient(clientList);
			return (client);
		}
//------------------------------------------------------------------------------
		private TClients UploadClients() {
			TClients clients = new TClients();
			clients.Items = new TClient[lboxClients.Items.Count];
			for(int n = 0; n < lboxClients.Items.Count; n++) {
				clients.Items[n] = (TClient) lboxClients.Items[n];
			}
			return (clients);
		}
//------------------------------------------------------------------------------
		private void btnUpdate_Click(object sender, EventArgs e) {
			UpdateCurrent();
		}
//------------------------------------------------------------------------------
	}
}
