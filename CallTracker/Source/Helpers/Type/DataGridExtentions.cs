using System.Windows.Forms;

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
    
}
