﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Castle.Core.Internal;
using PropertyChanged;
using ProtoBuf;
using Utilities.RegularExpressions;

using CallTracker.View;
using CallTracker.Helpers;

namespace CallTracker.Model
{
    [ProtoContract(SkipConstructor = true)]
    [ImplementPropertyChanged]
    public class CustomerContact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static DNPattern DNPattern = new DNPattern();
        public static ICONPattern ICONPattern = new ICONPattern();
        public static CMBSPattern CMBSPattern = new CMBSPattern();
        public static MobilePattern MobilePattern = new MobilePattern();
        public static UsernameUpperPattern UNUpperPattern = new UsernameUpperPattern();
        public static UsernameLowerPattern UNLowerPattern = new UsernameLowerPattern();

        public static List<DataBindType> PropertyStrings = new List<DataBindType>()
            {
                new DataBindType("Name", "Name"),
                new DataBindType("Username","Username"),
                new DataBindType("DN","DN"),
                new DataBindType("Mobile","Mobile"),
                new DataBindType("CMBS","CMBS"),
                new DataBindType("ICON", "ICON"),
                new DataBindType("Note", "Note"),
                new DataBindType("ICONNote", "ICONNote"),
                new DataBindType("Address", "Address"),
                new DataBindType("PR", "Fault.PR"),
                new DataBindType("NPR", "Fault.NPR"),
                new DataBindType("Node","Service.Node"),
                new DataBindType("AVC","Service.AVC"),
                new DataBindType("CVC","Service.CVC"),
                new DataBindType("CSA","Service.CSA"),
                new DataBindType("NNI","Service.NNI"),
                new DataBindType("GSI","Service.GSI"),
                new DataBindType("Equipment","Service.Equipment"),
            };

        
        public CustomerContact()
        {
            Id = Properties.Settings.Default.NextContactsId;
            Properties.Settings.Default.NextContactsId = Id + 1;

            OriginalCall = true;

            NameSplit = new NameModel();
            Name = String.Empty;
            Username = String.Empty;
            DN = String.Empty;
            Mobile = String.Empty;
            CMBS = String.Empty;
            ICON = String.Empty;
            Note = String.Empty;
            IDok = false;

            Address = new ContactAddress();
            Service = new ServiceModel();
            Fault = new FaultModel();
            Contacts = new ContactStatistics();
            Booking = new BookingModel();

            //PRTemplateList.AddRange(HFCTemplate);

            Contacts.StartDate = DateTime.Today;
            Contacts.StartTime = DateTime.Now.TimeOfDay;//.TimeOfDay();

            ((INotifyPropertyChanged)Fault).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)NameSplit).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)Booking).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)Service).PropertyChanged += CustomerContact_PropertyChanged;
        }
        //[ProtoBeforeDeserialization]
        //private void Foo()
        //{
        //    Dict.Clear();
        //}

        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NameSplit.Full = name;
            }
        }
        public string name { get; set; }
        public NameModel NameSplit { get; set; }
        [ProtoMember(3)]
        public string Username { get; set; }
        [ProtoMember(4)]
        public string DN { get; set; }
        [ProtoMember(5)]
        public string Mobile { get; set; }
        [ProtoMember(6)]
        public string CMBS { get; set; }
        [ProtoMember(7)]
        public string ICON { get; set; }
        [ProtoMember(8)]
        public string Note { get; set; }
        [ProtoMember(9)]
        public ContactAddress Address { get; set; }
        [ProtoMember(10)]
        public ServiceModel Service { get; set; }
        [ProtoMember(11)]
        public FaultModel Fault { get; set; }
        [ProtoMember(12)]
        public ContactStatistics Contacts { get; set; }
        public string ContactDateTime { get { return Contacts.StartDate.Add(Contacts.StartTime).ToString("dd/MM HH:mm"); } }
        public string ContactDate { get { return Contacts.StartDate.ToString(); } }
        public string ContactTime { get { return String.Format("{0:00}:{1:00}", Contacts.StartTime.TotalHours, Contacts.StartTime.Minutes); } }
        [ProtoMember(13)]
        public BookingModel Booking { get; set; }
        [ProtoMember(14)]
        public bool IDok { get; set; }
        [ProtoMember(15)]
        public bool Important { get; set; }
        [ProtoMember(16)]
        public EventsModel<CallStats> Statistics { get; set; }
        [ProtoMember(20)]
        public bool OriginalCall { get; set; }

        public void FinishUp()
        {
            if (OriginalCall)
                foreach (var key in Service.WasSearched.Keys.ToList())
                    Service.WasSearched[key] = true;
            OriginalCall = false;
        }

        protected List<PRTemplateModel> PRTemplateReplacements = new List<PRTemplateModel>();
        public void UpdatePrTemplateReplacements(List<PRTemplateModel> replacements)
        {
            foreach (var model in replacements)
            {
                var query = PRTemplateReplacements.FirstOrDefault(x => x.Question == model.Question);
                if (query != null)
                {
                    var idx = PRTemplateReplacements.IndexOf(query);
                    PRTemplateReplacements[idx] = model;
                }
                else
                    PRTemplateReplacements.Add(model);
            }
        }

        public string PRTemplate
        {
            get
            {
                return PRGenerators.Generate(this, PRTemplateReplacements);
            }
        }

        public string ICONNote { get { return Main.NoteGen.GenerateNoteManually(this); } set { ; } }
        public string GetAddress
        {
            get
            {
                return Address.Address;
            }
            set
            {
                Address.Address = value;
            }
        } 
        public string GetOutcome
        {
            get 
            {
                return Fault.Outcome;
            }
            set
            {
                Fault.Outcome = value;
            }
        }

        //public ContactArchiveModel ArchiveContact()
        //{
            
        //}

        public event PropertyChangedEventHandler NestedChange;


        void CustomerContact_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(NestedChange != null)
                NestedChange(sender, e);
        }

        //public static object GetProperty(object target, string property)
        //{
        //    if (String.IsNullOrEmpty(property)) return null;

        //    Type currentType = target.GetType();
        //    object value = target;

        //    foreach (string propertyName in property.Split('.'))
        //    {
        //        PropertyInfo prop = currentType.GetProperty(propertyName);
        //        if (prop != null)
        //        {
        //            value = prop.GetValue(value, null);
        //            currentType = prop.PropertyType;
        //        }
        //    }
        //    return value;
        //}

        //public static void SetProperty(object target, string property, string value)
        //{
        //    if (String.IsNullOrEmpty(property)) return;

        //    Type currentType = target.GetType();
        //    PropertyInfo currentObject = null;
        //    object nestedObject = target;

        //    string[] propSplit = property.Split('.');

        //    for (int i = 0; i < propSplit.Length; i++)
        //    {
        //        currentObject = currentType.GetProperty(propSplit[i]);
        //        if (currentObject != null)
        //            currentType = currentObject.PropertyType;
        //        if (i < propSplit.Length - 1)
        //            nestedObject = currentObject.GetValue(nestedObject, null);
        //    }

        //    if (currentObject != null)
        //        currentObject.SetValue(nestedObject, value, null);
        //}

        public bool FindDNMatch(string text)
        {
            var match = DNPattern.Match(text);
            if (match.Success)
            {
                DN = match.Result("0$1$2$3");
                var query = (from a in Main.ServicesStore.servicesDataSet.States
                             where a.Areacode == match.Groups[1].Value
                             select a).First();
                Address.State = query.NameShort;
                Service.Sip = query.Sip;

                Main.FadingToolTip.ShowandFade("DN: " + DN);

                if (!Properties.Settings.Default.AutoSearch) return true;

                if (!Service.WasSearched["Nexus"])
                {
                    HotkeyController.SilentSearch("https://dimps.optusnet.com.au/search/servno?servno=" + DN, "Nexus", "nexus.optus.com.au");
                    Service.WasSearched["Nexus"] = true;
                }
                if (!Service.WasSearched["SCAMPS"])
                {
                    HotkeyController.SilentSearch("https://scamps.optusnet.com.au/cm.html?q=" + DN, "SCAMPS", "scamps.optusnet.com.au");
                    Service.WasSearched["SCAMPS"] = true;
                }
                if (!Service.WasSearched["DIMPS"])
                {
                    HotkeyController.SilentSearch("https://dimps.optusnet.com.au/search/servno?servno=" + DN, "DIMPS", "dimps.optusnet.com.au");
                    Service.WasSearched["DIMPS"] = true;
                }

                return true;
            };
            return false;
        }

        public bool FindMobileMatch(string text)
        {
            var match = MobilePattern.Match(text);
            if (match.Success)
            {
                Mobile = match.Result("0$1$2");
                Main.FadingToolTip.ShowandFade("Mobile: " + Mobile);

                if (!Properties.Settings.Default.AutoSearch) return true;

                if (!Service.WasSearched["Nexus"])
                {
                    HotkeyController.SilentSearch("http://nexus.optus.com.au/index.php?#service/" + Mobile, "Nexus", "nexus.optus.com.au");
                    Service.WasSearched["Nexus"] = true;
                }

                return true;
            };
            return false;
        }

        public bool FindICONMatch(string text)
        {
            var match = ICONPattern.Match(text);
            if (match.Success)
            {
                ICON = text;

                Main.FadingToolTip.ShowandFade("ICON: " + ICON);

                if (!Properties.Settings.Default.AutoSearch) return true;

                if (!Service.WasSearched["Nexus"])
                {
                    HotkeyController.SilentSearch("http://nexus.optus.com.au/index.php?#account/" + ICON, "Nexus", "nexus.optus.com.au");
                    Service.WasSearched["Nexus"] = true;
                }

                return true;
            };
            return false;
        }

        public bool FindCMBSMatch(string text)
        {
            var match = CMBSPattern.Match(text);
            if (match.Success)
            {
                CMBS = match.Result("3$1$2 $3");
                var query = (from a in Main.ServicesStore.servicesDataSet.States
                             where a.CMBScode == match.Groups[1].Value
                             select a).First();
                Address.State = query.NameShort;
                Service.Sip = query.Sip;

                Main.FadingToolTip.ShowandFade("CMBS: " + CMBS);

                if (!Properties.Settings.Default.AutoSearch) return true;

                if (!Service.WasSearched["Nexus"])
                {
                    HotkeyController.SilentSearch("http://nexus.optus.com.au/index.php?#account/" + match.Result("3$1${2}0$3"), "Nexus", "nexus.optus.com.au");
                    Service.WasSearched["Nexus"] = true;
                }

                return true;
            };
            return false;
        }

        public bool FindUsernameMatch(string text)
        {
            var match = UNLowerPattern.Match(text);
            if (match.Success)
            {
                Username = text;
                Main.FadingToolTip.ShowandFade("Username: " + Username);

                if (!Properties.Settings.Default.AutoSearch) return true;

                if (!Service.WasSearched["DIMPS"])
                {
                    HotkeyController.SilentSearch("https://dimps.optusnet.com.au/search/account?account_no=" + Username, "DIMPS", "dimps.optusnet.com.au");
                    Service.WasSearched["DIMPS"] = true;
                }

                if (!Service.WasSearched["SCAMPS"])
                {
                    HotkeyController.SilentSearch("https://scamps.optusnet.com.au/cm.html?q=" + Username, "SCAMPS", "scamps.optusnet.com.au");
                    Service.WasSearched["SCAMPS"] = true;
                }

                if (!Service.WasSearched["UNMT"])
                {
                    HotkeyController.SilentSearch("https://staff.optusnet.com.au/tools/usernames/users.html?username=" + Username, "Staff", "staff.optusnet.com.au/tools/usernames");
                    Service.WasSearched["UNMT"] = true;
                }

                return true;
            };

            match = UNUpperPattern.Match(text);
            if (match.Success)
            {
                Username = text.ToLower();
                Main.FadingToolTip.ShowandFade("Username: " + Username);

                if (!Properties.Settings.Default.AutoSearch) return true;

                if (!Service.WasSearched["DIMPS"])
                {
                    HotkeyController.SilentSearch("https://dimps.optusnet.com.au/search/account?account_no=" + Username.ToLower(), "DIMPS", "dimps.optusnet.com.au");
                    Service.WasSearched["DIMPS"] = true;
                }
                if (!Service.WasSearched["SCAMPS"])
                {
                    HotkeyController.SilentSearch("https://scamps.optusnet.com.au/cm.html?q=" + Username.ToLower(), "SCAMPS", "scamps.optusnet.com.au");
                    Service.WasSearched["SCAMPS"] = true;
                }
                    
                return true;
            };

            return false;
        }


        public bool FindNameMatch(string text)
        {
            var match = NameModel.Pattern.Match(text);
            if (match.Success)
            {
                Name = text;

                Main.FadingToolTip.ShowandFade("Name: " + Name);
                return true;
            };
            return false;
        }
    }



    //[ImplementPropertyChanged]
    //public class ContactsList : List<CustomerContact>
    //{
    //    public ContactsList() : base()
    //    {
    //        //this.Add(new CustomerContact(0));
    //        //InsertItem(0, new CustomerContact(0) { Name = "Dick", DN = "0294813387", ICON = "40", Address = new ContactAddress { Number = "6", Street = "ho street", Type = "st" } });
    //        //Add(new CustomerContact(1) { Name = "Harry", DN = "0294813388", ICON = "60", Address = new ContactAddress { Number = "7", Street = "lo street" } });
    //    }
    //}
}
