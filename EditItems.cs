/****************************************************************************\
|                                EditClients.cs                              |
\****************************************************************************/
using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using OmerEisCommon;
using System;
using System.Collections;
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
	public partial class DlgEditItems : Form {
		private MySqlCommand m_cmd;
		private string m_strErr = "";
		private TStringIntListDB m_listDB = null;
//------------------------------------------------------------------------------
		public DlgEditItems() {
			InitializeComponent();
		}
//------------------------------------------------------------------------------
		public bool Execute(MySqlCommand cmd, TStringIntListDB listDB) {
			bool fEdit;

			if((fEdit = Download(cmd, listDB)) == true) {
				fEdit = ShowDialog() == DialogResult.OK;
				if(fEdit)
					Upload();
			}
			return (fEdit);
		}
		//-------------------`-----------------------------------------------------------
		private bool Download(MySqlCommand cmd, TStringIntListDB listDB) {
			bool fDownload;

			Text = listDB.Title;
			m_cmd = cmd;
			m_listDB = listDB;
			lboxItems.Items.Clear();
			if((fDownload = m_listDB.LoadFromDB(cmd, ref m_strErr)) == true) {
				for(int n = 0; n < m_listDB.Items.Length; n++)
					lboxItems.Items.Add(m_listDB.Items[n]);
			} else
				MessageBox.Show(m_strErr);
			return (fDownload);
		}
//------------------------------------------------------------------------------
		private void Upload() {
			UploadItems();
			int id = 0;

			m_listDB.SaveToDB(m_cmd, ref m_strErr);
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
		private TStringInt UploadLBoxItem() {
			TStringInt si = null;
			if(lboxItems.Items != null) {
				if(lboxItems.SelectedItem != null) {
					si = new TStringInt((TStringInt)lboxItems.SelectedItem);
				}
			}
			return (si);
		}
		//-----------------------------------------------------------------------------
		private void DlgEditClients_FormClosed(object sender, FormClosedEventArgs e) {
			Application.Idle -= OnIdle;
		}
//------------------------------------------------------------------------------
		private void btnNew_Click(object sender, EventArgs e) {
			UpdateCurrent();
			TStringInt si = NewItem();
			if(si != null) {
				DownloadItem(si);
				lboxItems.Items.Add(si);
			}
		}
//------------------------------------------------------------------------------
		private void UpdateCurrent() {
			TStringInt si = UploadFromText();
			if(si != null) {
				int idx = FindClientByID(si.ID);
				if(idx >= 0)
					lboxItems.Items[idx] = new TStringInt(si);
			}
		}
//------------------------------------------------------------------------------
		private void DownloadItem(TStringInt si) {
			if(si != null) {
				txtbxName.Text = si.Name;
				txtbxName.Tag = si;
			} else {
				txtbxName.Text = "";
				txtbxName.Tag = null;
			}
		}
//------------------------------------------------------------------------------
		private TStringInt UploadFromText() {
			TStringInt si = txtbxName.Tag as TStringInt;
			if(si != null)
				si.Name = txtbxName.Text.Trim();
			return (si);
		}
//------------------------------------------------------------------------------
		private int FindClientByID(int id) {
			int n, nFound = -1;

			for(n = 0; (n < lboxItems.Items.Count) && (nFound < 0); n++) {
				TStringInt si;
				try {
					si = (TStringInt) lboxItems.Items[n];
				} catch(Exception e) {
					si = null;
					Console.WriteLine(e.ToString());
				}
				if(si != null)
					if(si.ID == id)
						nFound = n;
			}
			return (nFound);
		}
//------------------------------------------------------------------------------
		private TStringInt NewItem() {
			TStringIntListDB items = UploadItems();
			TStringInt si = m_listDB.CreateNewItem();
			return (si);
		}
//------------------------------------------------------------------------------
		private TStringIntListDB UploadItems() {
			ArrayList al = new ArrayList();
			try {
				for(int n = 0; n < lboxItems.Items.Count; n++) {
					TStringInt si = new TStringInt();
					si.AssignAll ((TStringInt) lboxItems.Items[n]);
					al.Add(new TStringInt(si));
				}
			} catch(Exception e) {
				MessageBox.Show(e.ToString());
			}
			m_listDB.SetItems(al);
			return (m_listDB);
		}
//------------------------------------------------------------------------------
		private void btnUpdate_Click(object sender, EventArgs e) {
			UpdateCurrent();
			TStringInt si = UploadLBoxItem();
			if(si != null) {
				DownloadItem(si);
				txtbxName.Focus();
			}
			txtbxName.ReadOnly = txtbxName.ReadOnly ? false : true;
		}
//------------------------------------------------------------------------------
		private void btnDelete_Click(object sender, EventArgs e) {
			TStringInt siLB = UploadLBoxItem();
			if(siLB != null) {
				string str = String.Format("Delete client {0}?", siLB.Name);
				if(MessageBox.Show(str, "אישור", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
					if(m_listDB.DeleteFromDB(m_cmd, siLB.ID, ref m_strErr)) {
						int idx = FindClientByID(siLB.ID);
						if(idx >= 0)
							lboxItems.Items.RemoveAt(idx);
					} else
						MessageBox.Show(m_strErr);
				}
			}
		}
//------------------------------------------------------------------------------
		private void DlgEditItems_Load(object sender, EventArgs e) {
			Application.Idle += OnIdle;
		}
//------------------------------------------------------------------------------
		private void OnIdle(object sender, EventArgs e) {
		}
//------------------------------------------------------------------------------
		private void DlgEditItems_Load_1(object sender, EventArgs e) {
			Application.Idle += OnIdle;
		}
//------------------------------------------------------------------------------
		private void DlgEditItems_FormClosed(object sender, FormClosedEventArgs e) {
			Application.Idle -= OnIdle;
		}
//------------------------------------------------------------------------------
	}
}
