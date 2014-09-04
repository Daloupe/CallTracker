using System.Windows.Forms;

namespace CallTracker.View
{
    public class CustomDataGrid : DataGridView
    {
        public CustomDataGrid()
        {
            //VerticalScrollBar.VisibleChanged += VerticalScrollBar_VisibleChanged;
        }

        //void VerticalScrollBar_VisibleChanged(object sender, EventArgs e)
        //{
        //    if (VerticalScrollBar.Visible)
        //        Columns[Columns.Count - 1].Width -= 20;

        //}
    }
}
