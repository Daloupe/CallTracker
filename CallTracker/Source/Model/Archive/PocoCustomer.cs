using System;
using System.Reflection;
using System.Collections.Generic;
using System.ComponentModel;

using PropertyChanged;
using ProtoBuf;

namespace CallTracker.Model
{
    /// <summary>
    /// A POCO class is one that does not need any special interfaces or inheritance
    /// In WPF MVVM terms, a POCO class is one that does not Fire PropertyChanged events
    /// </summary>

    class PocoCustomer
    {
        //public string Name { get; set; }
        //public string Username { get; set; }
        //public int DN { get; set; }
        //public int Mobile { get; set; }
        //public int CMBS { get; set; }
        //public int ICON { get; set; }
        //public string Note { get; set; }
        //public ContactAddress Address { get; set; }
        //public CustomerService Service { get; set; }
        //public CustomerFault Fault { get; set; }
        //public List<CustomerContact> Contacts { get; set; }
        
        public PocoCustomer()
        {

        }

    }
    //public class Bindable : INotifyPropertyChanged
    //{
    //    // boiler-plate
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    protected virtual void OnPropertyChanged(string propertyName)
    //    {
    //        PropertyChangedEventHandler handler = PropertyChanged;
    //        if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    //    }
    //    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    //    {
    //        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
    //        field = value;
    //        OnPropertyChanged(propertyName);
    //        return true;
    //    }

    //    // props
    //    private string name;
    //    public string Name
    //    {
    //        get { return name; }
    //        set { SetField(ref name, value, "Name"); }
    //    }
    //}

    // Address ///////////////////////////////////////////////////////////////////////////////////////
    //[ImplementPropertyChanged]
    //public class CustomerAddress
    //{
    //    #pragma warning disable 67
    //    public event PropertyChangedEventHandler PropertyChanged;
    //    #pragma warning restore 67

    //    public string Address
    //    {
    //        get { return Number + " " + Street; }
    //        set { ;}
    //    }

    //    public int Unit { get; set; }
    //    public int Number { get; set; }
    //    public string Street { get; set; }
    //    public AddressType Type { get; set; }
    //    public string Suburb { get; set; }
    //    public AddressState State { get; set; }
    //    public int Postcode { get; set; }
    //    public int PCode { get; set; }

    //}

    //public enum AddressType
    //{
    //    ST, RD, AVE, CCT
    //}

    //public enum AddressState
    //{
    //    VIC, NSW, QLD, SA, TAS, NT, WA, ACT
    //}

    // Service ///////////////////////////////////////////////////////////////////////////////////////
    
    // Fault ///////////////////////////////////////////////////////////////////////////////////////
    

    // Booking ///////////////////////////////////////////////////////////////////////////////////////


    // Contact ///////////////////////////////////////////////////////////////////////////////////////
    
}
