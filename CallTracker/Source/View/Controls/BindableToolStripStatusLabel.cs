using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace CallTracker.View
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.StatusStrip)]
    public class BindableToolStripStatusLabel : ToolStripStatusLabel, IBindableComponent
    {
        private BindingContext _context = null;
        public BindingContext BindingContext
        {
            get
            {
                if (null == _context)
                {
                    _context = new BindingContext();
                }
                return _context;
            }
            set { _context = value; }
        }
        private ControlBindingsCollection _bindings;
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (null == _bindings)
                {
                    _bindings = new ControlBindingsCollection(this);
                }
                return _bindings;
            }
            set { _bindings = value; }
        }
    }
}
