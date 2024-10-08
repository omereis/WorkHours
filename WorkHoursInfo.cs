﻿/****************************************************************************\
|                               WorkHoursInfo.cs                             |
\****************************************************************************/
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using OmerEisCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace WorkHours {
	public class TWorkHoursInfo {
		private int m_id;
		private DateTime? m_dtStart;
		private DateTime? m_dtEnd;
		private string m_strDesc;
		private string m_strLocation;
		private TSubjects m_aSubject;
		private TOutputs m_aOutputs;
//------------------------------------------------------------------------------
		public int ID {get{return(m_id);}set{m_id=value;}}
		public DateTime? Start {get{return(m_dtStart);}set{m_dtStart=value;}}
		public DateTime? End {get{return(m_dtEnd);}set{m_dtEnd=value;}}
		public string Desc {get{return(m_strDesc);}set{m_strDesc=value;}}
		public string Location {get{return(m_strLocation);}set{m_strLocation=value;}}
		public TSubjects Subject {get{return(m_aSubject);}set{m_aSubject=value;}}
		public TOutputs Outputs {get{return(m_aOutputs);}set{m_aOutputs=value;}}
//------------------------------------------------------------------------------
		public TWorkHoursInfo () {
			Clear ();
		}
//------------------------------------------------------------------------------
		public TWorkHoursInfo (TWorkHoursInfo other) {
			AssignAll (other);
		}
//------------------------------------------------------------------------------
		public void Clear () {
			ID      = 0;
			Start   = null;
			End     = null;
			Desc    = "";
			Location = "";
			Subject  = null;
			Outputs = null;
		}
//------------------------------------------------------------------------------
		public void AssignAll (TWorkHoursInfo other) {
			ID      = other.ID;
			Start   = other.Start;
			End     = other.End;
			Desc    = other.Desc;
			Location = other.Location;
			Subject  = other.Subject;
			Outputs = other.Outputs;
		}
//------------------------------------------------------------------------------
		public bool InsertAsNew (MySqlCommand cmd, ref string strErr) {
			int id = ID;
			bool fInsert;
			TWorkHoursInfoDB whdb = new TWorkHoursInfoDB(this);
			fInsert = whdb.InsertAsNew (cmd, ref id, ref strErr);
			if (fInsert)
				AssignAll (whdb);
//				ID = id;
			return (fInsert);
		}
//------------------------------------------------------------------------------
		public bool UpdateInDB (MySqlCommand cmd, ref string strErr) {
			TWorkHoursInfoDB whdb = new TWorkHoursInfoDB(this);
			return (whdb.UpdateInDB (cmd, ref strErr));
		}
//------------------------------------------------------------------------------
		public string GetSubjectName() {
			string strName="";
			if (Subject != null)
				if (Subject.GetItemsCount() > 0)
					strName = Subject.Items[0].Name;
			return (strName);
		}
//------------------------------------------------------------------------------
		public string GetOutputsNames() {
			string strName = "";

			if (Outputs != null) {
				for (int n=0 ; n < Outputs.GetItemsCount() ; n++) {
					if (n > 0)
						strName += ", ";
					strName += Outputs.Items[n].Name;
				}
			}
			return (strName);
		}
//------------------------------------------------------------------------------
		public string GetWorkHours () {
			string strDiff="";

			if ((Start != null) && (End != null)) {
				TimeSpan ts = (End - Start).Value;
				DateTime dt = new DateTime() + ts;
				strDiff = String.Format ("{0:00}:{1:00}", ts.Hours, ts.Minutes);
			}
			return (strDiff);
		}
//------------------------------------------------------------------------------
		public bool DeleteFromDB (MySqlCommand cmd, ref string strErr) {
			TWorkHoursInfoDB whdb = new TWorkHoursInfoDB (this);
			return (whdb.DeleteFromDB (cmd,ref strErr));
		}
//------------------------------------------------------------------------------
		public static bool LoadAll (MySqlCommand cmd, ref TWorkHoursInfo[] aWorkHours, ref string strErr) {
			bool fLoad=false;
			ArrayList al = new ArrayList ();

			if ((fLoad = TWorkHoursInfoDB.LoadAll (cmd, al, ref strErr)) == true) {
				if (al.Count > 0) {
					aWorkHours = new TWorkHoursInfo [al.Count];
					for (int n=0 ; n < al.Count ; n++)
						aWorkHours[n] = (TWorkHoursInfo) al[n];
				}
			}
			return (fLoad);
		}
//------------------------------------------------------------------------------
		public bool LoadByID (MySqlCommand cmd, ref string strErr) {
			bool fLoad=false;
			TWorkHoursInfoDB whdb = new TWorkHoursInfoDB (this);
			if ((fLoad = whdb.LoadByID (cmd, ref strErr)) == true)
				AssignAll (whdb);
			return (fLoad);
		}
//------------------------------------------------------------------------------
		protected void AddOutput (TStringInt si) {
			if (Outputs == null)
				Outputs = new TOutputs();
			if (Outputs.IndexOfID (si.ID) < 0)
				Outputs.AddItem (si);
		}
//------------------------------------------------------------------------------
		public int CompareStart (DateTime? dtOther) {
			return (TMisc.CompareDates (m_dtStart, dtOther));
		}
//------------------------------------------------------------------------------
		public int CompareEnd (DateTime? dtOther) {
			return (TMisc.CompareDates (m_dtEnd, dtOther));
		}
//------------------------------------------------------------------------------
		public int CompareSubject (TSubjects subject) {
			return (String.Compare (SubjectAsText (Subject), SubjectAsText (subject), true));
		}
//------------------------------------------------------------------------------
		public int CompareOutputs (TOutputs outputs) {
			return (String.Compare (OutputsAsText (Outputs), OutputsAsText (outputs), true));
		}
//------------------------------------------------------------------------------
		public static string SubjectAsText (TSubjects subject) {
			string strSubject="";
			if (subject != null)
				strSubject = subject.Items[0].Name;
			return (strSubject);
		}
//------------------------------------------------------------------------------
		public string OutputsAsText (TOutputs outputs) {
			string strOutput="";

			if (outputs != null) {
				for (int n=0 ; n < outputs.Items.Length ; n++) {
					strOutput += outputs.Items[n].Name;
					if (n < outputs.Items.Length - 1)
						strOutput += ", ";
				}
			}
			return (strOutput);
		}
//------------------------------------------------------------------------------
	}
//------------------------------------------------------------------------------
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//------------------------------------------------------------------------------
	internal class TWorkHoursInfoDB : TWorkHoursInfo {
		private static readonly string Table="tblWorkHours";
		private static readonly string View = "vWorkHours";
		private static readonly string ViewWorkOutputs = "vWorkOutputs";
		private static readonly string FieldID = "wh_id";
		private static readonly string FieldStart = "dtStart";
		private static readonly string FieldEnd = "dtEnd";
		private static readonly string FieldDesc = "txtDesc";
		private static readonly string FieldLoc = "txtLoc";
//------------------------------------------------------------------------------
		public TWorkHoursInfoDB() : base() { }
		public TWorkHoursInfoDB (TWorkHoursInfo other) : base (other) { }
		public bool InsertAsNew (MySqlCommand cmd, ref int id, ref string strErr) {
			bool fIns=false;

			try {
				if (TMisc.GetFieldMax (cmd, Table, FieldID, ref id, ref strErr)) {
					cmd.CommandText = String.Format ("insert into {0} ({1}) values ({2});", Table, FieldID, id + 1);
					if (cmd.ExecuteNonQuery () > 0) {
						ID = id + 1;
						fIns = true;
					}
				}
			}
			catch (Exception e) {
				strErr = e.Message;
				fIns = false;
			}
			return (fIns);
		}
//------------------------------------------------------------------------------
		public new bool UpdateInDB (MySqlCommand cmd, ref string strErr) {
			bool fUpdate;

			try {
				cmd.CommandText = String.Format ("update {0} set {1}='{2}',{3}='{4}'," +
												"{5}='{6}',{7}={8},{9}='{10}' " +
												"where {11}={12};",
												Table,
												FieldStart,TMisc.ReadDateTimeField (Start),
												FieldEnd,TMisc.ReadDateTimeField (End),
												FieldDesc,TMisc.GetSqlText (Desc),
												TSubjects.FieldID,TSubjects.GetSqlInt (Subject),
												FieldLoc,TMisc.GetSqlText (Location),
												FieldID,ID);
				cmd.ExecuteNonQuery ();
				fUpdate = true;
			}
			catch (Exception e) {
				strErr = e.Message;
				fUpdate = false;
			}
			return (fUpdate);
		}
//------------------------------------------------------------------------------
		public new bool DeleteFromDB (MySqlCommand cmd, ref string strErr) {
			bool fDel;

			try {
				cmd.CommandText = String.Format ("delete from {0} where {1}={2};",
												Table,
												FieldID,ID);
				cmd.ExecuteNonQuery ();
				fDel = true;
			}
			catch (Exception e) {
				strErr = e.Message;
				fDel = false;
			}
			return (fDel);
		}
//------------------------------------------------------------------------------
/*

*/
//------------------------------------------------------------------------------
		public static bool LoadAll (MySqlCommand cmd, ArrayList al, ref string strErr) {
			bool fLoad;
			MySqlDataReader reader = null;

			try {
				TWorkHoursInfoDB whdb = new TWorkHoursInfoDB (), whdbNew = new TWorkHoursInfoDB ();
				int idPrev = -1;
				fLoad = true;
				cmd.CommandText = String.Format ("select * from {0} order by {1};", View, FieldID);
				reader = cmd.ExecuteReader ();
				while ((reader.Read ()) && (fLoad)) {
					if ((fLoad = whdbNew.LoadIDFromReader (reader, ref strErr)) == true) {
						if (whdbNew.ID != whdb.ID) {
							if (whdb.ID > 0) {
								al.Add (new TWorkHoursInfo (whdb));
								whdb.Clear ();
							}
							whdb.ID = whdbNew.ID;
							whdb.LoadFromReader (reader, ref strErr, false);
						}
						else
							fLoad = whdb.LoadOutput (reader, ref strErr);
					}
				}
				if (whdb.ID > 0)
					al.Add (new TWorkHoursInfo (whdb));
			}
			catch (Exception e) {
				strErr = e.Message;
				fLoad = false;
			}
			finally {
				if (reader != null)
					reader.Close ();
			}
			return (fLoad);
		}
//------------------------------------------------------------------------------
		public bool LoadFromReader (MySqlDataReader reader, ref string strErr, bool fLoadID=true) {
			bool fRead;

			try {
				//Clear ();
				if (fLoadID)
					ID = TMisc.ReadIntField(reader, FieldID);
				Desc = TMisc.ReadTextField (reader, FieldDesc, ref strErr);
				Location = TMisc.ReadTextField (reader, FieldLoc, ref strErr);
				Start = TMisc.ReadDateTimeField (reader, FieldStart);
				End =   TMisc.ReadDateTimeField (reader, FieldEnd);
				if ((fRead = LoadSubject (reader, ref strErr)) == true)
					fRead = LoadOutput (reader, ref strErr);
			}
			catch (Exception e) {
				fRead =false;
				if (strErr.Length == 0)
					strErr = e.Message;
			}
			return (fRead);
		}
//------------------------------------------------------------------------------
		private bool LoadSubject (MySqlDataReader reader, ref string strErr) {
			bool fLoad;
			if (Subject == null)
				Subject = new TSubjects ();
			TStringInt si = new TStringInt();
			if ((fLoad = Subject.LoadFromReader (si, reader, ref strErr)) == true)
				Subject.AddItem (si);
			return (fLoad);
		}
//------------------------------------------------------------------------------
		private bool LoadOutput (MySqlDataReader reader, ref string strErr) {
			bool fLoad;
			if (Outputs == null)
				Outputs= new TOutputs ();
			TStringInt si = new TStringInt();
			if ((fLoad = Outputs.LoadFromReader (si, reader, ref strErr)) == true)
				Outputs.AddItem (si);
			return (fLoad);
		}
//------------------------------------------------------------------------------
		public bool LoadIDFromReader (MySqlDataReader reader, ref string strErr) {
			bool fRead;

			try {
				ID = TMisc.ReadIntField(reader, FieldID);
				fRead = true;
			}
			catch (Exception e) {
				fRead =false;
				if (strErr.Length == 0)
					strErr = e.Message;
			}
			return (fRead);
		}
//------------------------------------------------------------------------------
		public new bool LoadByID (MySqlCommand cmd, ref string strErr) {
			bool fLoad;
			MySqlDataReader reader = null;

			try {
				fLoad = true;
				cmd.CommandText = String.Format ("select * from {0} where {1}={2};", View, FieldID, ID);
				reader = cmd.ExecuteReader ();
				if ((reader.Read ()) && (fLoad)) {
					if ((fLoad = LoadFromReader (reader, ref strErr)) == true) {
						reader.Close ();
						fLoad = LoadOutputs (cmd, ref strErr);
					}
				}
			}
			catch (Exception e) {
				strErr = e.Message;
				fLoad = false;
			}
			finally {
				if (reader != null)
					reader.Close ();
			}
			return (fLoad);
		}
//------------------------------------------------------------------------------
		public bool LoadOutputs (MySqlCommand cmd, ref string strErr) {
			bool fLoad;
			MySqlDataReader reader = null;

			try {
				TOutputs outputs = new TOutputs ();
				TStringInt si = new TStringInt ();
				fLoad = true;
				cmd.CommandText = String.Format ("select * from {0} where {1}={2};", ViewWorkOutputs, FieldID, ID);
				reader = cmd.ExecuteReader ();
				while ((reader.Read ()) && (fLoad)) {
					if (outputs.LoadFromReader (si, reader, ref strErr))
						AddOutput (si);
				}
			}
			catch (Exception e) {
				strErr = e.Message;
				fLoad = false;
			}
			finally {
				if (reader != null)
					reader.Close ();
			}
			return (fLoad);
		}
//------------------------------------------------------------------------------
	}
}
