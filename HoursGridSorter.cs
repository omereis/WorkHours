using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkHours
{
    public class THoursGridSorterHelper {
		private int m_nCol;
		private DataGridView m_grid;
		THoursGridSorter m_sorter;
		public THoursGridSorterHelper (DataGridView grid) {
			m_nCol = 0;
			m_grid = grid;
			m_sorter = new THoursGridSorter (grid);
		}
		public void SortGrid () {
			SortGrid (m_nCol);
		}
		public void SortGrid (int nCol=-1){
			if (nCol < 0)
				nCol = m_nCol;
			else
				m_nCol = nCol;
			m_sorter.SetSortColumn (nCol);
			m_grid.Sort (m_sorter);
		}
    }
//-----------------------------------------------------------------------------
	/*
	 * Source: https://stackoverflow.com/questions/435177/c-custom-sort-of-datagridview
	*/
	public class THoursGridSorter : IComparer {
		private DataGridView m_grid;
		private TypeCode m_type_code;
		private int m_nColumn;
		private SortOrder OrderOfSort;
		public THoursGridSorter (DataGridView grid) {
			m_grid = grid;
			m_type_code = Type.GetTypeCode(Type.GetType("System.String"));
			m_nColumn = 0;
			OrderOfSort = SortOrder.None;
		}
//-----------------------------------------------------------------------------
		public void SetSortColumn (int nCol) {
			if (m_nColumn == nCol)
				OrderOfSort = OrderOfSort == SortOrder.Descending ? SortOrder.Ascending : SortOrder.Descending;
			m_nColumn = nCol;
			if (OrderOfSort == SortOrder.None)
				OrderOfSort = SortOrder.Ascending;
			m_type_code = GetTypeByColumn (m_nColumn);
		}
//-----------------------------------------------------------------------------
		public int SortColumn {get {return (m_nColumn);}}
//-----------------------------------------------------------------------------
		private TypeCode GetTypeByColumn (int nColumn) {
			TypeCode type = TypeCode.String;
			if (nColumn == main.colLocation)
				type = TypeCode.String;
			else if (m_nColumn == main.colStartDate)
				type = TypeCode.DateTime;
			else if (m_nColumn == main.colStartTime)
				type = TypeCode.DateTime;
			else if (m_nColumn == main.colEndDate)
				type = TypeCode.DateTime;
			else if (m_nColumn == main.colEndTime)
				type = TypeCode.DateTime;
			else if (m_nColumn == main.colSubjects)
				type = TypeCode.String;
			else if (m_nColumn == main.colOutputs)
				type = TypeCode.String;
			else if (m_nColumn == main.colHours)
				type = TypeCode.DateTime;
			else
				type = TypeCode.String;
			return (type);
		}
//-----------------------------------------------------------------------------
		public int Compare(object x, object y) {
			int result;
			DataGridViewRow dgvX, dgvY;

			dgvX = (DataGridViewRow)x;
			dgvY = (DataGridViewRow)y;
			TWorkHoursInfo whx, why;
			whx = (TWorkHoursInfo) dgvX.Tag;
			why = (TWorkHoursInfo) dgvY.Tag;
			if ((whx == null) && (why == null))
				result = 0;
			else if ((whx == null) && (why != null))
				result = 1;
			else if ((whx != null) && (why == null))
				result = -1;
            else {
				if (SortColumn == main.colLocation)
					result = String.Compare (whx.Location, why.Location, StringComparison.OrdinalIgnoreCase);
			else if (m_nColumn == main.colStartDate)
				result = whx.CompareStart (why.Start);
			else if (m_nColumn == main.colStartTime)
				result = whx.CompareStart (why.Start);
			else if (m_nColumn == main.colEndDate)
				result = whx.CompareEnd (why.End);
			else if (m_nColumn == main.colEndTime)
				result = whx.CompareEnd (why.End);
			else if (m_nColumn == main.colSubjects)
				result = whx.CompareSubject (why.Subject);
			else if (m_nColumn == main.colOutputs)
				result = whx.CompareOutputs (why.Outputs);
			else if (m_nColumn == main.colHours)
				result = 0;
			else
				result = 0;
			}
			return (result);
		}
//-----------------------------------------------------------------------------
	}
}
