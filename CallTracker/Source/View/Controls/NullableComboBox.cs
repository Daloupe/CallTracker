using System;
using System.Collections;
using System.Reflection;
using System.Windows.Forms;

namespace BitConstruct.Controls.NullableComboBox
{
	/// <summary>
	/// ComboBox which can show null, even if bound to data;
	/// use SetDataBinding method to use nullable features
	/// </summary>
	public class NullableComboBox : ComboBox
	{
		#region fields

		/// <summary>
		/// DataSource
		/// </summary>
		private IList mDataSource;

		/// <summary>
		/// The object we bind to
		/// </summary>
		private object mObjectToModify;

		/// <summary>
		/// The name of the property of the object we bind to
		/// </summary>
		private string mPropertyName;

		/// <summary>
		/// The property  of the object we bind to
		/// </summary>
		private PropertyInfo mProperty;

		/// <summary>
		/// Name of the proeprty which is shown in the combo box
		/// </summary>
		private string mDisplayMember;

		/// <summary>
		/// Flag if comboBox is in normal or nullable mode
		/// </summary>
		private bool mNullableMode = false;

		#endregion

		#region methods

		/// <summary>
		/// Method to bind data in nullable mode to the combo box
		/// </summary>
		/// <param name="dataSource">DataSource (IList)</param>
		/// <param name="objectToModify">Object we bind to</param>
		/// <param name="propertyName">Name of the property of the object we bind to</param>
		/// <param name="displayMember">Name of the proeprty which is shown in the combo box</param>
		public void SetDataBinding(IList dataSource, object objectToModify, string propertyName, string displayMember)
		{
			// init combo box and delete all databinding stuff
			this.DisplayMember = String.Empty;
			this.Items.Clear();
			this.ValueMember = String.Empty;
			this.Text = String.Empty;

			// init private fields
			this.mDataSource = dataSource;
			this.mObjectToModify = objectToModify;
			this.mPropertyName = propertyName;
			this.mProperty = this.mObjectToModify.GetType().GetProperty(this.mPropertyName);
			this.mDisplayMember = displayMember;
			this.mNullableMode = true;

			// get selected item
			object selectedItem = this.mProperty.GetValue(this.mObjectToModify, null);

			// if not null, bind to it
			if (selectedItem != null)
			{
				this.DataSource = this.mDataSource;
				this.SelectedItem = selectedItem;
			}
				// do nothing and set datasource to null
			else
				this.DataSource = null;
		}

		#endregion

		#region events

		/// <summary>
		/// On drop down event
		/// </summary>
		protected override void OnDropDown(EventArgs e)
		{
			// if no datasource is set, set it
			if (this.mNullableMode && this.mDataSource != null && this.DataSource == null)
				this.DataSource = this.mDataSource;

			base.OnDropDown(e);
		}

		/// <summary>
		/// On data source changed event
		/// </summary>
		protected override void OnDataSourceChanged(EventArgs e)
		{
			// reset display member
			if (this.mNullableMode)
				this.DisplayMember = this.mDisplayMember;

			base.OnDataSourceChanged(e);
		}

		/// <summary>
		/// On selected index changed event
		/// </summary>
		protected override void OnSelectedIndexChanged(EventArgs e)
		{
			// set property to new value
			if (this.mNullableMode && this.mProperty.CanWrite)
				this.mProperty.SetValue(this.mObjectToModify, this.SelectedItem, null);

			base.OnSelectedIndexChanged(e);
		}

		/// <summary>
		/// On key down event
		/// </summary>
		protected override void OnKeyDown(KeyEventArgs e)
		{
			// if DEL or BACK is pressed set property to null and data source to null
			if (this.mNullableMode && (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back))
			{
				// next line is very important: without you may get an OutOfRangeException
				this.DroppedDown = false;
				this.DataSource = null;
			}

			base.OnKeyDown(e);
		}

		#endregion
	}
}