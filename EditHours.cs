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
//-----------------------------------------------------------------------------
namespace WorkHours {
	public partial class EditHours : Form {
		private MySqlCommand m_cmd=null;
//-----------------------------------------------------------------------------
		public EditHours() {
			InitializeComponent();
		}
//-----------------------------------------------------------------------------
		public bool Execute (MySqlCommand cmd) {
			Download (cmd);
			bool fEdit = ShowDialog () == DialogResult.OK;
			if (fEdit)
				Upload ();
			return (fEdit);
		}
//-----------------------------------------------------------------------------
		private void Download (MySqlCommand cmd) {
			m_cmd = cmd;
		}
//-----------------------------------------------------------------------------
		private void Upload () {
		}
//-----------------------------------------------------------------------------
	}
}
