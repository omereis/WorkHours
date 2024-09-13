using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using OmerEisCommon;
//using TStringIntDict = System.Collections.Generic.Dictionary<int,string>;

namespace WorkHours {
//------------------------------------------------------------------------------
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//------------------------------------------------------------------------------
	public class TClients :  TStringIntListDB {
//------------------------------------------------------------------------------
		public TClients () : base ("tblClients", "client_id", "client_name") {
			m_strTitle = "לקוחות";
		}
	}
//------------------------------------------------------------------------------
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//------------------------------------------------------------------------------
	public class TSubjects :  TStringIntListDB {
//------------------------------------------------------------------------------
		public static readonly string Table     = "tblSubjects";
		public static readonly string FieldID   = "subject_id";
		public static readonly string FieldName = "subject_name";
//------------------------------------------------------------------------------
		public TSubjects () : base (Table, FieldID, FieldName) {
			m_strTitle = "נושאים";
		}
	}
//------------------------------------------------------------------------------
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//------------------------------------------------------------------------------
	public class TOutputs :  TStringIntListDB {
//------------------------------------------------------------------------------
		public TOutputs () : base ("tblOutputs", "output_id", "output_name") {
			m_strTitle = "תפוקות";
		}
	}
/*
/*
	public class TClient : TStringInt {
//------------------------------------------------------------------------------
		public TClient () : base() { }
//------------------------------------------------------------------------------
		public TClient (TClient other) : base(other) { }
//------------------------------------------------------------------------------
		public TClient (TStringInt si) {
			ID   = si.ID;
			Name = si.Name;
		}
	}
*/
}
