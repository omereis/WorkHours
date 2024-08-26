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
		public static string GetNewName(TClient client) {
			int n = Math.Abs (client.ID);
			string str = "Client " + n.ToString();
			return (str);
		}
//------------------------------------------------------------------------------
		public static TClient CreateNewClient (TClients clients) {
			TClient client = new TClient ();
			client.ID = TClient.GetMinID (clients.Items);
			if (client.ID == 0)
				client.ID = -1;
			client.Name = GetNewName(client);
			return (client);
		}
	}
}
