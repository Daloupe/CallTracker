using System;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using CallTracker.DataSets;
using CallTracker.Helpers;

    //[DefaultProperty("Items")]
    //[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    //public class ToolStripMenuLabelItem : ToolStripMenuItem
    //{
    //    public ToolStripMenuLabelItem()
    //    {
    //    }

    //}
    public class ToolStripButtonWithContextMenu : ToolStripButton
    {
        ContextMenuStrip _contextMenuStrip;

        public ContextMenuStrip ContextMenuStrip
        {
            get { return _contextMenuStrip; }
            set { _contextMenuStrip = value; }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (_contextMenuStrip != null)
                    _contextMenuStrip.Show(Parent.PointToScreen(e.Location));
            }
        }
    }

    [DefaultProperty("Items")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class ContextualToolStripMenuItem : ToolStripMenuItem
    {
        public bool dirty = false;
        public ToolStripItem[] staticDropDownItems;
        private UpdateMenuObject updateObject;
        public UpdateMenuObject UpdateObject
        {
            get { return updateObject; }
            set 
            { 
                updateObject = value;
                if (updateObject != null)
                {
                    staticDropDownItems = new ToolStripItem[this.DropDownItems.Count];
                    this.DropDownItems.CopyTo(staticDropDownItems, 0);
                    updateObject.Parent = this;
                }
            }
        }

        public virtual void UpdateMenu(string _service) 
        {
            if (dirty == true && UpdateObject != null)
            {
                DropDownItems.Clear();
                DropDownItems.AddRange(staticDropDownItems);
                UpdateObject.Go(_service);
                dirty = false;
            }
        }

        public ContextualToolStripMenuItem()
        {

        }
    
    }

    public abstract class UpdateMenuObject
    {
        public ServicesDataSet ds;
        public ContextualToolStripMenuItem Parent;

        public UpdateMenuObject(ServicesDataSet _ds)
        {
            ds = _ds;
        }
        public virtual void Go(string _service)
        {

        }

        public static void newItem_Click(object sender, EventArgs e)
        {
            HotkeyController.CreateNewIE(((ToolStripMenuItem)sender).Tag.ToString());
        }
    }

    public class TransfersMenuItem : UpdateMenuObject
    {
        public TransfersMenuItem(ServicesDataSet _ds) : base(_ds)
        {
            ds.Departments.RowChanged += Departments_RowChanged;
        }

        void Departments_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
        {
            Parent.dirty = true;
        }

        public override void Go(string _service)
        {
            var queries = from a in ds.Departments
                          where a.ServicesRow.ProblemStylesRow.Description == _service
                          select new
                          {
                              a.InternalContact,
                              a.ExternalContact,
                              a.ContactHours,
                              a.DepartmentNamesRow.NameShort
                          };

            foreach (var query in queries)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Internal: ");
                sb.AppendLine(query.InternalContact.ToString());
                sb.Append("External: ");
                sb.AppendLine(query.ExternalContact.ToString());
                sb.AppendLine(query.ContactHours);

                string menu = StringHelpers.JoinCamelCase(query.NameShort) + "ToolStripMenuItem";

                foreach (ToolStripMenuItem item in Parent.DropDownItems.OfType<ToolStripMenuItem>())
                    if (item.Name == menu)
                    {
                        item.ToolTipText = sb.ToString();
                        item.Tag = query.InternalContact.ToString();
                    }
            }
        }
    }

    public class BookmarksMenuItem : UpdateMenuObject
    {
        public BookmarksMenuItem(ServicesDataSet _ds)
            : base(_ds)
        {
            ds.Bookmarks.RowChanged += Bookmarks_RowChanged;
        }

        void Bookmarks_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
        {
            Parent.dirty = true;
        }

        public override void Go(string _service)
        {
            //if (ds.Bookmarks.Count == 1 && ds.Bookmarks[0].ProblemStylesRow == null) return;
            var queries = (from a in ds.Bookmarks
                          where a.ProblemStylesRow.Description == _service
                          select a).ToList();

            foreach (var query in queries)
            {
                var newItem = new ToolStripMenuItem();
                newItem.Text = query.Name;
                newItem.Tag = query.Url;
                newItem.Click += newItem_Click;
                Parent.DropDownItems.Insert(0,newItem);
            }
        }

    }

    public class SystemsMenuItem : UpdateMenuObject
    {
        public SystemsMenuItem(ServicesDataSet _ds)
            : base(_ds)
        {
            ds.SystemLinks.RowChanged += SystemLinks_RowChanged;
        }

        void SystemLinks_RowChanged(object sender, System.Data.DataRowChangeEventArgs e)
        {
            Parent.dirty = true;
        }

        public override void Go(string _service)
        {
            var queries = from a in ds.SystemLinks
                          where a.ProblemStylesRow.Description == _service
                          select a;

            foreach (var query in queries)
            {
                ToolStripMenuItem newItem = new ToolStripMenuItem();
                newItem.Text = query.Name;
                newItem.Tag = query.Url;
                newItem.Click += newItem_Click;
                Parent.DropDownItems.Insert(0, newItem);
            }
        }
    }

    [DefaultProperty("Items")]
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class ToolStripTimerItem : ToolStripItem
    {
        public Timer MyTimer;
        public ToolStripTimerItem()
        {
            MyTimer = new Timer(this.Container);
        }
    }