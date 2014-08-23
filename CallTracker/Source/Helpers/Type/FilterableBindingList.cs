//using System;
//using System.Collections.Generic;
//using System.ComponentModel;

//namespace CallTracker.Helpers.Types
//{

//    /// <summary>
//    /// Specifies how null values compare to other value and to other null values
//    /// </summary>
//    /// <remarks></remarks>
//    public enum NullCompares
//    {
//        NoHandling,
//        NullLessThanAll,
//        NullGreaterThanAll
//    }
//}
//namespace CallTracker.Helpers.Types
//{

//    /// <summary>
//    /// A bindable list that supports Filtering, Sorting etc. 
//    /// Suitable for use with Visual WebGui's Column Filtering DataGridView as the DataSource of a BindingSource
//    /// 
//    /// Code fragment obtained and modified slightly from:
//    /// http://stackoverflow.com/questions/5378293/simplest-way-to-filter-generic-list
//    /// 
//    /// Originated from the book "Data Binding with Windows Forms 2.0" and downloadable from
//    /// http://www.softinsight.com/databindingbook/
//    /// 
//    /// Modifications for serializabilidy by Pall Bjornsson @ Gizmox
//    /// </summary>
//    /// <typeparam name="T"></typeparam>
//    /// <remarks></remarks>
//    [Serializable()]
//    public class FilterableBindingList<T> : BindingList<T>, IBindingListView, IRaiseItemChangedEvents, IDisposable
//    {


//        private bool m_Sorted = false;
//        private bool m_Filtered = false;
//        private string m_FilterString = null;
//        private ListSortDirection m_SortDirection = ListSortDirection.Ascending;
//        private string m_SortPropertyName = string.Empty;
//        private List<ListSortDescriptionSerilizableInfo> m_SortsCollection;
//        private List<T> m_OriginalCollection = new List<T>();

//        private NullCompares m_NullComparisionHandling = NullCompares.NoHandling;
//        public FilterableBindingList()
//            : base()
//        {
//        }
//        public FilterableBindingList(List<T> list)
//            : base(list)
//        {
//        }
//        public FilterableBindingList(NullCompares NullComparisionHandling)
//            : base()
//        {
//            this.m_NullComparisionHandling = NullComparisionHandling;
//        }
//        public FilterableBindingList(List<T> list, NullCompares NullComparisionHandling)
//            : base(list)
//        {
//            this.m_NullComparisionHandling = NullComparisionHandling;
//        }

//        #region "Serializability support"
//        [Serializable()]
//        private class ListSortDescriptionSerilizableInfo
//        {
//            private string _Name;
//            private ListSortDirection _Direction;
//            public ListSortDirection Direction
//            {
//                get { return _Direction; }
//            }
//            public string Name
//            {
//                get { return _Name; }
//            }

//            public ListSortDescriptionSerilizableInfo(string strPropertyName, ListSortDirection enmDirection)
//            {
//                _Name = strPropertyName;
//                _Direction = enmDirection;
//            }
//        }
//        /// <summary>
//        /// Saves ListSortDescritpionCollection to a simple List, as ListSortDescriptionCollection is not serializable
//        /// </summary>
//        /// <param name="objSorts"></param>
//        /// <remarks></remarks>
//        private void SaveSorts(ListSortDescriptionCollection objSorts)
//        {
//            if (objSorts == null)
//            {
//                if (m_SortsCollection != null)
//                {
//                    m_SortsCollection.Clear();
//                }
//            }
//            else
//            {
//                if (m_SortsCollection == null)
//                {
//                    m_SortsCollection = new List<ListSortDescriptionSerilizableInfo>();
//                }
//                else
//                {
//                    m_SortsCollection.Clear();
//                }
//                foreach (ListSortDescription sd in objSorts)
//                {
//                    m_SortsCollection.Add(new ListSortDescriptionSerilizableInfo(sd.PropertyDescriptor.Name, sd.SortDirection));
//                }
//            }
//        }
//        /// <summary>
//        /// Restores (or dynamically builds) ListSortDescriptionCollection off of our saved simple list.
//        /// </summary>
//        /// <returns></returns>
//        /// <remarks></remarks>
//        private ListSortDescriptionCollection RestoreSorts()
//        {
//            if (m_SortsCollection == null)
//            {
//                return new ListSortDescriptionCollection();
//            }
//            List<ListSortDescription> sl = new List<ListSortDescription>();
//            foreach (ListSortDescriptionSerilizableInfo sn in m_SortsCollection)
//            {
//                PropertyDescriptor propDesc = TypeDescriptor.GetProperties(typeof(T))[sn.Name];
//                ListSortDescription sd = new ListSortDescription(propDesc, sn.Direction);
//                sl.Add(sd);
//            }
//            return new ListSortDescriptionCollection(sl.ToArray());
//        }
//        #endregion

//        protected override bool SupportsSearchingCore
//        {
//            get { return true; }
//        }

//        protected override int FindCore(PropertyDescriptor property, object key)
//        {
//            for (int i = 0; i <= Count - 1; i++)
//            {
//                // Simple iteration:
//                T item = this[i];
//                if (property.GetValue(item).Equals(key))
//                {
//                    return i;
//                }
//            }
//            return -1;
//            // Not found
//            // Using List.FindIndex:
//            //Predicate<T> pred = delegate(T item)
//            //{
//            //   if (property.GetValue(item).Equals(key))
//            //      return true;
//            //   else
//            //      return false;
//            //};
//            //List<T> list = Items as List<T>;
//            //if (list == null)
//            //   return -1;
//            //return list.FindIndex(pred);
//        }
//        protected override bool SupportsSortingCore
//        {
//            get { return true; }
//        }
//        protected override bool IsSortedCore
//        {
//            get { return m_Sorted; }
//        }
//        protected override ListSortDirection SortDirectionCore
//        {
//            get { return m_SortDirection; }
//        }
//        protected override PropertyDescriptor SortPropertyCore
//        {
//            get
//            {
//                // Build PropertyDescriptor off of saved propertyname
//                if (string.IsNullOrEmpty(m_SortPropertyName))
//                {
//                    return null;
//                }
//                else
//                {
//                    PropertyDescriptor propDesc = TypeDescriptor.GetProperties(typeof(T))[m_SortPropertyName];
//                    return propDesc;
//                }
//            }
//        }
//        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
//        {
//            m_SortDirection = direction;
//            // Save name of property, as PropertyDescriptor is not serializable
//            m_SortPropertyName = property.Name;
//            SortComparer<T> comparer = new SortComparer<T>(property, direction, m_NullComparisionHandling);
//            ApplySortInternal(comparer);
//        }
//        private void ApplySortInternal(SortComparer<T> comparer)
//        {
//            if (m_OriginalCollection.Count == 0)
//            {
//                m_OriginalCollection.AddRange(this);
//            }
//            List<T> listRef = this.Items as List<T>;
//            if (listRef == null)
//            {
//                return;
//            }
//            listRef.Sort(comparer);
//            m_Sorted = true;
//            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
//        }
//        protected override void RemoveSortCore()
//        {
//            if (!m_Sorted)
//            {
//                return;
//            }
//            Clear();
//            foreach (T item in m_OriginalCollection)
//            {
//                Add(item);
//            }
//            m_OriginalCollection.Clear();
//            m_SortPropertyName = string.Empty;
//            SaveSorts(null);
//            m_Sorted = false;
//        }
//        #region "IBindingListView Members"
//        public void ApplySort(ListSortDescriptionCollection sorts)
//        {
//            m_SortPropertyName = string.Empty;
//            SaveSorts(sorts);
//            SortComparer<T> comparer = new SortComparer<T>(sorts);
//            ApplySortInternal(comparer);
//        }
//        public string Filter
//        {
//            get { return m_FilterString; }
//            set
//            {
//                m_FilterString = value;
//                m_Filtered = true;
//                UpdateFilter();
//            }
//        }
//        public void RemoveFilter()
//        {
//            if (!m_Filtered)
//            {
//                return;
//            }
//            m_FilterString = null;
//            m_Filtered = false;
//            m_Sorted = false;
//            SaveSorts(null);
//            m_SortPropertyName = string.Empty;
//            Clear();
//            foreach (T item in m_OriginalCollection)
//            {
//                Add(item);
//            }
//            m_OriginalCollection.Clear();
//        }
//        public ListSortDescriptionCollection SortDescriptions
//        {
//            // Sort descriptions is dynamically generated from saved serializable information
//            get { return RestoreSorts(); }
//        }
//        public bool SupportsAdvancedSorting
//        {
//            get { return true; }
//        }
//        public bool SupportsFiltering
//        {
//            get { return true; }
//        }
//        #endregion
//        protected virtual void UpdateFilter()
//        {
//            int equalsPos = m_FilterString.IndexOf('=');
//            // Get property name
//            string propName = m_FilterString.Substring(0, equalsPos).Trim();
//            // Get Filter criteria
//            string criteria = m_FilterString.Substring(equalsPos + 1, m_FilterString.Length - equalsPos - 1).Trim();
//            // Protect against no quote values, like booleans
//            if (criteria.Length > 2 && criteria.Contains("\""))
//            {
//                criteria = criteria.Substring(1, criteria.Length - 2);
//            }
//            // string leading and trailing quotes
//            // Get a property descriptor for the filter property
//            PropertyDescriptor propDesc = TypeDescriptor.GetProperties(typeof(T))[propName];
//            if (m_OriginalCollection.Count == 0)
//            {
//                m_OriginalCollection.AddRange(this);
//            }
//            List<T> currentCollection = new List<T>(this);
//            Clear();
//            foreach (T item in currentCollection)
//            {
//                object value = propDesc.GetValue(item);
//                if (value.ToString() == criteria)
//                {
//                    Add(item);
//                }
//            }
//        }
//        #region "IBindingList overrides"
//        public new bool AllowNew
//        {
//            get { return CheckReadOnly(); }
//        }
//        public new bool AllowRemove
//        {
//            get { return CheckReadOnly(); }
//        }
//        private bool CheckReadOnly()
//        {
//            if (m_Sorted || m_Filtered)
//            {
//                return false;
//            }
//            else
//            {
//                return true;
//            }
//        }
//        #endregion


//        // Necessary to override and call RemoveItem in order to remove PropertyChanged event handlers
//        protected override void ClearItems()
//        {
//            UnregisterAllItemEventHandlers();
//            base.ClearItems();
//        }
//        protected override void InsertItem(int index, T item)
//        {
//            foreach (PropertyDescriptor propDesc in TypeDescriptor.GetProperties(item))
//            {
//                if (propDesc.SupportsChangeEvents)
//                {
//                    propDesc.AddValueChanged(item, OnItemChanged);
//                }
//            }
//            base.InsertItem(index, item);
//        }
//        protected override void RemoveItem(int index)
//        {
//            T item = Items[index];
//            PropertyDescriptorCollection propDescs = TypeDescriptor.GetProperties(item);
//            foreach (PropertyDescriptor propDesc in propDescs)
//            {
//                if (propDesc.SupportsChangeEvents)
//                {
//                    propDesc.RemoveValueChanged(item, OnItemChanged);
//                }
//            }
//            base.RemoveItem(index);
//        }
//        #region "IRaiseItemChangedEvents Members"
//        public bool RaisesItemChangedEvents
//        {
//            get { return true; }
//        }

//        private void UnregisterAllItemEventHandlers()
//        {
//            PropertyDescriptorCollection objProperties = TypeDescriptor.GetProperties(typeof(T));
//            foreach (T Item in this)
//            {
//                foreach (PropertyDescriptor propDesc in objProperties)
//                {
//                    if (propDesc.SupportsChangeEvents)
//                    {
//                        propDesc.RemoveValueChanged(Item, OnItemChanged);
//                    }
//                }
//            }
//        }
//        private void OnItemChanged(object sender, EventArgs args)
//        {
//            int index = Items.IndexOf((T)sender);
//            OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
//        }

//        #endregion

//        #region " IDisposable Support "
//        // This code added by Visual Basic to correctly implement the disposable pattern.
//        public void Dispose()
//        {
//            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }

//        // To detect redundant calls
//        private bool disposedValue = false;

//        // IDisposable
//        protected virtual void Dispose(bool disposing)
//        {
//            if (!this.disposedValue)
//            {
//                if (disposing)
//                {
//                    // TODO: free other state (managed objects).
//                    UnregisterAllItemEventHandlers();
//                    this.Clear();
//                    this.m_SortPropertyName = null;
//                    this.m_SortsCollection = null;
//                    this.m_OriginalCollection = null;
//                }

//                // TODO: free your own state (unmanaged objects).
//                // TODO: set large fields to null.
//            }
//            this.disposedValue = true;
//        }
//        #endregion

//    }
//}
//namespace CallTracker.Helpers.Types
//{

//    class SortComparer<T> : IComparer<T>
//    {
//        private ListSortDescriptionCollection m_SortCollection = null;
//        private PropertyDescriptor m_PropDesc = null;
//        private ListSortDirection m_Direction = ListSortDirection.Ascending;

//        private NullCompares m_NullComparisionHandling = NullCompares.NoHandling;
//        public SortComparer(PropertyDescriptor propDesc, ListSortDirection direction)
//        {
//            m_PropDesc = propDesc;
//            m_Direction = direction;
//        }
//        public SortComparer(ListSortDescriptionCollection sortCollection)
//        {
//            m_SortCollection = sortCollection;
//        }
//        public SortComparer(PropertyDescriptor propDesc, ListSortDirection direction, NullCompares NullComparisionHandling)
//        {
//            m_PropDesc = propDesc;
//            m_Direction = direction;
//            m_NullComparisionHandling = NullComparisionHandling;
//        }
//        public SortComparer(ListSortDescriptionCollection sortCollection, NullCompares NullComparisionHandling)
//        {
//            m_SortCollection = sortCollection;
//            m_NullComparisionHandling = NullComparisionHandling;
//        }
//        #region "IComparer<T> Members"
//        public int Compare(T x, T y)
//        {
//            if (m_PropDesc != null)
//            {
//                // Simple sort 
//                object xValue = m_PropDesc.GetValue(x);
//                object yValue = m_PropDesc.GetValue(y);
//                return CompareValues(xValue, yValue, m_Direction);
//            }
//            else
//            {
//                if (m_SortCollection != null && m_SortCollection.Count > 0)
//                {
//                    return RecursiveCompareInternal(x, y, 0);
//                }
//                else
//                {
//                    return 0;
//                }
//            }
//        }
//        #endregion
//        private int CompareValues(object xValue, object yValue, ListSortDirection direction)
//        {
//            int retValue = 0;
//            if (m_NullComparisionHandling != NullCompares.NoHandling && xValue == null && yValue == null)
//            {
//                retValue = 0;
//            }
//            else if (m_NullComparisionHandling == NullCompares.NullGreaterThanAll && xValue == null)
//            {
//                retValue = 1;
//            }
//            else if (m_NullComparisionHandling == NullCompares.NullLessThanAll && xValue == null)
//            {
//                retValue = -1;
//            }
//            else if (m_NullComparisionHandling == NullCompares.NullGreaterThanAll && yValue == null)
//            {
//                retValue = 1;
//            }
//            else if (m_NullComparisionHandling == NullCompares.NullLessThanAll && yValue == null)
//            {
//                retValue = -1;
//            }
//            else if (xValue is IComparable)
//            {
//                // Can ask the x value
//                retValue = ((IComparable)xValue).CompareTo(yValue);
//            }
//            else
//            {
//                if (yValue is IComparable)
//                {
//                    //Can ask the y value
//                    retValue = ((IComparable)yValue).CompareTo(xValue);
//                }
//                else
//                {
//                    if (!xValue.Equals(yValue))
//                    {
//                        // not comparable, compare String representations
//                        retValue = xValue.ToString().CompareTo(yValue.ToString());
//                    }
//                }
//            }
//            if (direction == ListSortDirection.Ascending)
//            {
//                return retValue;
//            }
//            else
//            {
//                return retValue * -1;
//            }
//        }
//        private int RecursiveCompareInternal(T x, T y, int index)
//        {
//            if (index >= m_SortCollection.Count)
//            {
//                return 0;
//            }
//            // termination condition
//            ListSortDescription listSortDesc = m_SortCollection[index];
//            object xValue = listSortDesc.PropertyDescriptor.GetValue(x);
//            object yValue = listSortDesc.PropertyDescriptor.GetValue(y);
//            int retValue = CompareValues(xValue, yValue, listSortDesc.SortDirection);
//            if (retValue == 0)
//            {
//                return RecursiveCompareInternal(x, y, System.Threading.Interlocked.Increment(ref index));
//            }
//            else
//            {
//                return retValue;
//            }
//        }
//    }
//}
