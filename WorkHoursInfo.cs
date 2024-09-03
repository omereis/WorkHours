using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHours {
	public class TWorkHoursInfo {
		private int id;
		private DateTime? m_dtStart;
		private DateTime? m_dtEnd;
		public TWorkHoursInfo () {
			Clear ();
		}
		public void Clear () {
		m_dtStart = null;
		}
	}
}
