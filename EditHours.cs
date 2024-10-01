/****************************************************************************\
|                                EditHours.cs                                |
\****************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//-----------------------------------------------------------------------------
using MySql.Data.MySqlClient;
using OmerEisCommon;
//-----------------------------------------------------------------------------
namespace WorkHours {
	public partial class DlgEditHours : Form {
		private MySqlCommand m_cmd = null;
		private string m_strErr;
//-----------------------------------------------------------------------------
		public DlgEditHours() {
			InitializeComponent();
		}
//-----------------------------------------------------------------------------
		public bool Execute(MySqlCommand cmd, TWorkHoursInfo wh) {
			Download(cmd, wh);
			bool fEdit = ShowDialog() == DialogResult.OK;
			if(fEdit)
				Upload(wh);
			return (fEdit);
		}
//-----------------------------------------------------------------------------
		public static bool TimeStringToInt(string strTime, ref int nDest) {
			bool f = false;

			if(strTime != null) {
				string[] astr = strTime.Split(':');
				try {
					nDest = Convert.ToInt16(astr[0]) * 100 + Convert.ToInt16(astr[1]);
					f = true;
				} catch(Exception e) {
					string str = e.Message;
					f = false;
				}
			} else {
				f = true;
				nDest = 0;
			}
			return (f);
		}
//-----------------------------------------------------------------------------
		private void DownloadTime(ComboBox combo, DateTime? date_time) {
			int idxFound = -1, nDiff, nMin = 24 * 100, idxMin = -1;

			if(date_time != null) {
				int nDest = 0, nSrc = date_time.Value.Hour * 100 + date_time.Value.Minute;
				for(int n = 0; (n < combo.Items.Count) && (idxFound < 0); n++) {
					if(TimeStringToInt((string)combo.Items[n], ref nDest)) {
						nDiff = Math.Abs(nSrc - nDest);
						if(nDiff < 5)
							idxFound = n;
						else {
							if(nDiff < nMin) {
								nMin = nDiff;
								idxMin = n;
							}
							nDiff = Math.Min(nDiff, nMin);
						}
					}
				}
				if(idxFound < 0)
					idxFound = idxMin;
			}
			if(idxFound >= 0)
				combo.SelectedIndex = idxFound;
		}
//-----------------------------------------------------------------------------
		private void Download(MySqlCommand cmd, TWorkHoursInfo wh) {
			m_cmd = cmd;
			txtID.Text = wh.ID.ToString();
			DownloadSubject(cmd);
			DownloadOutputs(cmd);
			DownloadTime(comboStart, wh.Start);
			DownloadTime(comboEnd, wh.End);
			DownloadSubject (wh);
			DownloadOutputs (wh);
			txtbxDesc.Text = wh.Desc;
			txtbxLoc.Text = wh.Location;
		}
//-----------------------------------------------------------------------------
		public static DateTime? CombineDateTime(DateTime dt, string strTime) {
			DateTime? dtRes;
			try {
				int nTime = 0;
				dtRes = new DateTime();
				dtRes = dt.Date;
				if(TimeStringToInt(strTime, ref nTime)) {
					int nHours = nTime / 100;
					int nMin = nTime % 100;
					dtRes = dtRes.Value.AddHours(nHours);
					dtRes = dtRes.Value.AddMinutes(nMin);
				}
			} catch {
				dtRes = null;
			}
			return (dtRes);
		}
//-----------------------------------------------------------------------------
		private void Upload(TWorkHoursInfo wh) {
			wh.Clear();
			wh.ID = TMisc.ToIntDef(txtID.Text);
			wh.Start = CombineDateTime(dtpStartDate.Value, (string)comboStart.SelectedItem);
			wh.End = CombineDateTime(dtpEndDate.Value, (string)comboEnd.SelectedItem);
			wh.Desc = txtbxDesc.Text.Trim();
			wh.Location = txtbxLoc.Text.Trim();
			wh.Subject = UploadSubject();
			wh.Outputs = UploadOutputs();
		}
//-----------------------------------------------------------------------------
		private TSubjects UploadSubject() {
			TSubjects subject = new TSubjects();

			if(comboSubjects.SelectedItem != null)
				subject.AddItem((TStringInt)comboSubjects.SelectedItem);
			return (subject);
		}
//-----------------------------------------------------------------------------
		private TOutputs UploadOutputs() {
			TOutputs outputs = new TOutputs();

			for(int n = 0; n < clboxOutputs.CheckedItems.Count; n++)
				outputs.AddItem(clboxOutputs.CheckedItems[n]);
			return (outputs);
		}
//-----------------------------------------------------------------------------
		private void DownloadSubject(MySqlCommand cmd) {
			TSubjects subjects = new TSubjects();

			comboSubjects.Items.Clear();
			if(subjects.LoadFromDB(cmd, ref m_strErr)) {
				for(int n = 0; n < subjects.Items.Length; n++)
					comboSubjects.Items.Add(subjects.Items[n]);
				comboSubjects.SelectedIndex = comboSubjects.Items.Add(new TStringInt());
			} else
				MessageBox.Show(m_strErr);
		}
//-----------------------------------------------------------------------------
		private void DownloadOutputs(MySqlCommand cmd) {
			TOutputs outputs = new TOutputs();

			clboxOutputs.Items.Clear();
			if(outputs.LoadFromDB(cmd, ref m_strErr)) {
				for(int n = 0; n < outputs.Items.Length; n++)
					clboxOutputs.Items.Add(outputs.Items[n]);
			} else
				MessageBox.Show(m_strErr);

		}
//-----------------------------------------------------------------------------
		public static void SelectItem(ComboBox combo, TStringInt siSelect) {
			TStringInt si, siFound = null;

			try {
				for(int n = 0; (n < combo.Items.Count) && (siFound == null); n++) {
					si = (TStringInt)combo.Items[n];
					if(si.Equals(siSelect))
						siFound = si;
					if(siFound != null)
						combo.SelectedItem = siFound;
				}
			} catch { }
		}
//-----------------------------------------------------------------------------
		public static void SelectItems(CheckedListBox clbox, TStringIntListDB lst) {
			TStringInt si;

			for(int n = 0; n < clbox.Items.Count; n++)
				clbox.SetItemChecked(n, false);
			try {
				if(lst != null) {
					for(int n = 0; n < clbox.Items.Count; n++) {
						si = (TStringInt)clbox.Items[n];
						int idx = lst.FindItem(si);
						if(idx > 0)
							clbox.SetItemChecked(n, true);
					}
				}
			} catch { }
		}
//-----------------------------------------------------------------------------
		private void btnOK_Click(object sender, EventArgs e) {
			DialogResult = DialogResult.OK;
		}

		private void button1_Click(object sender, EventArgs e) {
			TWorkHoursInfo wh = new TWorkHoursInfo();
			wh.Clear();

			wh.Start = CombineDateTime(dtpStartDate.Value, (string)comboStart.SelectedItem);
			wh.Start = CombineDateTime(dtpEndDate.Value, (string)comboEnd.SelectedItem);
		}
//-----------------------------------------------------------------------------
		private void DownloadSubject (TWorkHoursInfo wh) {
			if (wh.Subject != null)
				if (wh.Subject.GetItemsCount() > 0) {
					int idx = comboSubjects.Items.IndexOf(wh.Subject.Items[0]);
					if (idx >= 0)
						comboSubjects.SelectedIndex = idx;
				}
		}
//-----------------------------------------------------------------------------
		private void DownloadOutputs (TWorkHoursInfo wh) {
			if (wh.Outputs != null) {
				for (int n=0 ; n < wh.Outputs.GetItemsCount(); n++) {
					int idx = clboxOutputs.Items.IndexOf (wh.Outputs.Items[n]);
					if (idx >= 0)
						clboxOutputs.SetItemChecked (idx, true);
				}
			}
		}
//-----------------------------------------------------------------------------
	}
}
