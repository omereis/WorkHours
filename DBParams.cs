/*****************************************************************************#\
|                               DBParams.cs                                    |
\******************************************************************************/


using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OmerEisGlobal;

namespace WorkHours {
	public class TDBParams {
		private string m_strServer;
		private string m_strDatabase;
		private string m_strUsername;
		private string m_strPassword;
		TIniFile m_ini;

		public string Server {get{return (m_strServer);}set{m_strServer=value;}}
		public string Database {get{return (m_strDatabase);}set{m_strDatabase=value;}}
		public string Username {get{return (m_strUsername);}set{m_strUsername=value;}}
		public string Password {get{return (m_strPassword);}set{m_strPassword=value;}}
//------------------------------------------------------------------------------
		public TDBParams() {
			Clear();
		}
//------------------------------------------------------------------------------
		public TDBParams(TDBParams other) {
			AssignAll (other);
		}
//------------------------------------------------------------------------------
		public void Clear() {
		}
//------------------------------------------------------------------------------
		public void AssignAll (TDBParams other) {
		}
//------------------------------------------------------------------------------
	}
}
