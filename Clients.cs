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
		}
	}
//------------------------------------------------------------------------------
//++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
//------------------------------------------------------------------------------
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
}
