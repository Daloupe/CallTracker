using System.Data;
using System.Windows.Forms;
using CallTracker.DataSets;

namespace CallTracker.Helpers
{
        public static class DatatGridViewExtensions
        {
            public static void SetColumnSortMode(this DataGridView dataGridView, DataGridViewColumnSortMode sortMode)
            {
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    column.SortMode = sortMode;
                }
            }
        }

    public static class DataTableExtensions
    {
        const int m_iNO_MOVE_OCCURED = -1; // number to indicate error

        public static int MoveRowUp(this DataRow row)
        {
            DataTable dtParent = row.Table;
            int iOldRowIndex = dtParent.Rows.IndexOf(row);
            if (iOldRowIndex == 0) return m_iNO_MOVE_OCCURED;
            DataRow newRow = dtParent.NewRow();
            newRow.ItemArray = row.ItemArray;

            if (iOldRowIndex < dtParent.Rows.Count)
            {
                dtParent.Rows.Remove(row);
                dtParent.Rows.InsertAt(newRow, iOldRowIndex + 1);
                return dtParent.Rows.IndexOf(newRow);
            }

            return m_iNO_MOVE_OCCURED;
        }

        public static int MoveRowDown(this DataRow row)
        {
            DataTable dtParent = row.Table;
            int iOldRowIndex = dtParent.Rows.IndexOf(row);

            DataRow newRow = dtParent.NewRow();
            newRow.ItemArray = row.ItemArray;

            if (iOldRowIndex > 0)
            {
                dtParent.Rows.Remove(row);
                dtParent.Rows.InsertAt(newRow, iOldRowIndex - 1);
                return dtParent.Rows.IndexOf(newRow);
            }

            return m_iNO_MOVE_OCCURED;
        }
    }

    public enum SNSDataTableMoveRow
    {
        Up,
        Down
    }
 
    
}
