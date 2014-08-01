using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms.Design;
using System.Windows.Forms;
using System.Drawing.Design;

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
    private UpdateMenuObject updateObject;
    public UpdateMenuObject UpdateObject
    {
        get { return updateObject; }
        set 
        { 
            updateObject = value;
            if(updateObject != null)
                updateObject.Parent = this;
        }
    }

    public virtual void UpdateMenu(string _service) 
    {
        if (dirty == true && UpdateObject != null)
        {
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
                      where a.ServicesRow.Name == _service
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