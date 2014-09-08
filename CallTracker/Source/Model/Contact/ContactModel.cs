using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
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
            //Contacts = new ContactStatistics();
            Booking = new BookingModel();
            Events = new EventsModel<CallStats>();

            //PRTemplateList.AddRange(HFCTemplate);
            PRTemplateReplacements = new List<PRTemplateModel>();

            //Contacts.StartDate = DateTime.Today;
            //Contacts.StartTime = DateTime.Now.TimeOfDay;//.TimeOfDay();

            ((INotifyPropertyChanged)Fault).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)Booking).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)Service).PropertyChanged += CustomerContact_PropertyChanged;
        }

        [ProtoBeforeDeserialization]
        private void PreDes()
        {
            NameSplit = new NameModel();
            PRTemplateReplacements = new List<PRTemplateModel>();
        }

        [ProtoAfterDeserialization]
        private void PostDes()
        {
            ((INotifyPropertyChanged)Fault).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)Booking).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)Service).PropertyChanged += CustomerContact_PropertyChanged;
        }

        public CustomerContact(EventsModel<CallStats> events, string note, string symptom, string action, string outcome, ServiceTypes affectedService)
        {
            NameSplit = new NameModel();
            Name = String.Empty;
            Username = String.Empty;
            DN = String.Empty;
            Mobile = String.Empty;
            CMBS = String.Empty;
            ICON = String.Empty;
            Note = String.Empty;
            Fault = new FaultModel(symptom, action, outcome, affectedService);
            Note = note;
            Events = events;
            Address = new ContactAddress();
            Service = new ServiceModel();
            //Contacts = new ContactStatistics();
            Booking = new BookingModel();

            ((INotifyPropertyChanged)Fault).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)Booking).PropertyChanged += CustomerContact_PropertyChanged;
            ((INotifyPropertyChanged)Service).PropertyChanged += CustomerContact_PropertyChanged;
        }

        public void FinishUp()
        {
            if (Events.LastCallEvent.EventType.IsNot(CallEventTypes.CallEnd))
                AddCallEvent(CallEventTypes.CallEnd);
            if (OriginalCall)
                foreach (var key in Service.WasSearched.Keys.ToList())
                    Service.WasSearched[key] = true;
            OriginalCall = false;
        }

        public event PropertyChangedEventHandler NestedChange;
        void CustomerContact_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (NestedChange != null)
                NestedChange(sender, e);
        }

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
        [DoNotNotify]
        public string name;
        [DoNotNotify]
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

        [ProtoMember(20)]
        public ContactAddress Address { get; set; }
        [ProtoMember(21)]
        public ServiceModel Service { get; set; }
        [ProtoMember(22)]
        public FaultModel Fault { get; set; }
        [ProtoMember(23)]
        public BookingModel Booking { get; set; }


        [ProtoMember(30)]
        public bool IDok { get; set; }
        [ProtoMember(31)]
        public bool Important { get; set; }
        [ProtoMember(32)]
        public string Note { get; set; }

        [ProtoMember(40)]
        public bool OriginalCall { get; set; }
        [ProtoMember(41, OverwriteList = true)]
        public EventsModel<CallStats> Events { get; set; }
        //[ProtoMember(42)]
        //public ContactStatistics Contacts { get; set; }





        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Events //////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        internal void AddCallEvent(CallEventTypes newEvent)
        {
            switch (Events.LastCallEvent.EventType)
            {
                case CallEventTypes.RecordCreated:
                    Events.AddCallEvent(newEvent.Is(CallEventTypes.NotReady) ? CallEventTypes.LogIn : newEvent);
                    break;
                case CallEventTypes.Reserved:
                    Events.AddCallEvent(newEvent.Is(CallEventTypes.Talking) ? CallEventTypes.CallStart : newEvent);
                    break;
                case CallEventTypes.CallEnd:
                    if (!newEvent.Has(CallEventTypes.Ready | CallEventTypes.LogOut | CallEventTypes.CallEnd | CallEventTypes.Reserved))
                        Events.AddCallEvent(newEvent.Is(CallEventTypes.Talking) ? CallEventTypes.CallStart : newEvent);
                    break;
                default:
                    Events.AddCallEvent(newEvent.Has(CallEventTypes.Ready | CallEventTypes.LogOut)
                        ? CallEventTypes.CallEnd
                        : newEvent);
                    break;
            }

            EventLogger.LogNewEvent(Id + " " + DN + " > " + Enum.GetName(typeof(CallEventTypes), Events.LastCallEvent.EventType) + " at " + Events.LastCallEvent.Timestamp.ToString("dd/MM/yy hh:mm:ss"));
        }

        internal void AddAppEvent(AppEventTypes newEvent)
        {
            switch (newEvent)
            {
                case AppEventTypes.AutoFill:
                    Events.Statistics.AutoFills += 1;
                    break;
                case AppEventTypes.AutoSearch:
                    Events.Statistics.AutoSearches += 1;
                    break;
                case AppEventTypes.DataPaste:
                    Events.Statistics.DataPastes += 1;
                    break;
                case AppEventTypes.GridlinkSearch:
                    Events.Statistics.GridLinkSearches += 1;
                    break;
                case AppEventTypes.SmartCopy:
                    Events.Statistics.SmartCopies += 1;
                    break;
                case AppEventTypes.SmartPaste:
                    Events.Statistics.SmartPastes += 1;
                    break;
            }
            Events.AddAppEvent(newEvent);
        }

        internal CallStats ComputeStatistics()
        {
            return Events.ComputeStatistics();
        }

        internal EventsModel<CallStats> GetEvents()
        {
            return Events;
        }







        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // PR Templates ////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string PRTemplate
        {
            get { return StripRtf(PRTemplateRtf); }
        }

        private static DateTime _lastPRGenerate;
        private string _prTemplateRtf;
        public string PRTemplateRtf
        {
            get
            {
                var now = DateTime.Now;
                if ((now - _lastPRGenerate).TotalMilliseconds > 25)
                {
                    _prTemplateRtf = PRGenerators.Generate(this, PRTemplateReplacements);
                    _lastPRGenerate = now;
                }

                return _prTemplateRtf;
            }
        }

        protected List<PRTemplateModel> PRTemplateReplacements;// = new List<PRTemplateModel>();
        public void UpdatePrTemplateReplacements(List<PRTemplateModel> replacements)
        {
            PRTemplateReplacements.AddRange(replacements);
            PRTemplateReplacements = PRTemplateReplacements.GroupBy(a => a.Question)
                                                          .Select(b => b.Last())
                                                          .ToList();
        }
        public void ClearPrTemplateReplacements()
        {
            PRTemplateReplacements.Clear();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // ICON Note////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string ICONNote
        {
            get { return StripRtf(ICONNoteRtf); }
        }

        private static DateTime _lastICONGenerate;
        private string _iconNoteRtf;
        public string ICONNoteRtf
        {
            get
            {
                var now = DateTime.Now;
                if ((now - _lastICONGenerate).TotalMilliseconds > 25)
                {
                    _iconNoteRtf = Main.NoteGen.GenerateNoteManually(this);
                    _lastICONGenerate = now;
                }

                return _iconNoteRtf;
            }
        }

        private static string StripRtf(string s)
        {
            var rtfBox = new System.Windows.Forms.RichTextBox { Rtf = s };
            return rtfBox.Text;
        }




        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Getters  ////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //public string ContactDateTime { get { return Contacts.StartDate.Add(Contacts.StartTime).ToString("dd/MM HH:mm"); } }
        //public string ContactDate { get { return Contacts.StartDate.ToString(); } }
        //public string ContactTime { get { return String.Format("{0:00}:{1:00}", Contacts.StartTime.TotalHours, Contacts.StartTime.Minutes); } }

        public string GetAddress
        {
            get { return Address.Address; }
            set {Address.Address = value;}
        } 
        public string GetOutcome
        {
            get {return Fault.Outcome;}
            set {Fault.Outcome = value;}
        }









        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Data ////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
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










        ////////////////////////////////////////////////////////////////////////////////////////////////////
        // Regex Logic /////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public static DNPattern DNPattern = new DNPattern();
        public static ICONPattern ICONPattern = new ICONPattern();
        public static CMBSPattern CMBSPattern = new CMBSPattern();
        public static MobilePattern MobilePattern = new MobilePattern();
        public static UsernamePattern UsernamePattern = new UsernamePattern();

        public void AddToNote(string text)
        {
            if (String.IsNullOrEmpty(Note) || Note.EndsWith("\r\n"))
                Note += text;
            else
                Note += Environment.NewLine + text;
        }

        public bool FindDNMatch(string text)
        {
            var match = DNPattern.Match(text);
            if (match.Success)
            {
                DN = match.Result("0$1");
                Main.FadingToolTip.ShowandFade("DN: " + DN);

                var query = (from a in Main.ServicesStore.servicesDataSet.States
                             where a.Areacode == match.Groups["State"].Value
                             select a).First();
                Address.State = query.NameShort;
                Service.Sip = query.Sip;

                if (Properties.Settings.Default.AutoSearch)
                {
                    if (!Fault.AffectedServices.Has(ServiceTypes.LAT))
                    {
                        if (!Service.WasSearched["SCAMPSDN"])
                            HotkeyController.AutoSearch(
                                "https://scamps.optusnet.com.au/cm.html?q=" + DN,
                                "SCAMPS",
                                "https://scamps.optusnet.com.au",
                                false,
                                "DN");

                        //if (!Service.WasSearched["SCAMPSDN"])
                        //    HotkeyController.AutoSearch(
                        //        "https://www.google.com.au/" + DN,
                        //        "SCAMPS",
                        //        "https://www.google.com.au",
                        //        false,
                        //        "DN");

                        if (!Service.WasSearched["DIMPSDN"])
                            HotkeyController.AutoSearch(
                                "https://dimps.optusnet.com.au/search/servno?servno=" + DN, 
                                "DIMPS", 
                                "https://dimps.optusnet.com.au",
                                true, 
                                "DN");
                    }
                    if (!Service.WasSearched["Nexus"])
                        Service.WasSearched["Nexus"] = HotkeyController.AutoSearch(
                            "https://dimps.optusnet.com.au/search/servno?servno=" + DN,
                            "Nexus", 
                            "https://nexus.optus.com.au");

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
                Mobile = match.Result("0$1");
                Main.FadingToolTip.ShowandFade("Mobile: " + Mobile);

                if (Properties.Settings.Default.AutoSearch)
                {
                    if (!Service.WasSearched["Nexus"])
                    {
                        Service.WasSearched["Nexus"] = HotkeyController.AutoSearch(
                            "http://nexus.optus.com.au/index.php?#service/" + Mobile, 
                            "Nexus",
                            "http://nexus.optus.com.au");
                    }
                }

                return true;
            };
            return false;
        }

        public bool FindICONMatch(string text)
        {
            if (ICONPattern.Match(text).Success)
            {
                ICON = text;

                Main.FadingToolTip.ShowandFade("ICON: " + ICON);

                if (Properties.Settings.Default.AutoSearch)
                {
                    if (!Service.WasSearched["Nexus"])
                    {
                        Service.WasSearched["Nexus"] = HotkeyController.AutoSearch(
                            "http://nexus.optus.com.au/index.php?#account/" + ICON, 
                            "Nexus",
                            "http://nexus.optus.com.au");
                    }
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
                             where a.CMBScode == match.Groups["State"].Value
                             select a).First();
                Address.State = query.NameShort;
                Service.Sip = query.Sip;

                Main.FadingToolTip.ShowandFade("CMBS: " + CMBS);

                if (Properties.Settings.Default.AutoSearch)
                {
                    if (!Service.WasSearched["Nexus"])
                    {
                        Service.WasSearched["Nexus"] = HotkeyController.AutoSearch(
                            "http://nexus.optus.com.au/index.php?#account/" + match.Result("3$1${2}0$3"), 
                            "Nexus",
                            "http://nexus.optus.com.au");
                    }
                }

                return true;
            };
            return false;
        }

        public bool FindUsernameMatch(string text)
        {
            if (UsernamePattern.Match(text).Success)
            {
                Username = text.ToLower();
                Main.FadingToolTip.ShowandFade("Username: " + Username);

                if (!Properties.Settings.Default.AutoSearch) return true;

                if (!Service.WasSearched["SCAMPSUsername"])
                    HotkeyController.AutoSearch(
                        "https://scamps.optusnet.com.au/cm.html?q=" + Username,
                        "SCAMPS",
                        "https://scamps.optusnet.com.au",
                        false,
                        "Username");

                //if (!Service.WasSearched["SCAMPSUsername"])
                //    HotkeyController.AutoSearch(
                //        "https://www.google.com.au/" + Username,
                //        "SCAMPS",
                //        "https://www.google.com.au/",
                //        false,
                //        "Username");

                if (!Service.WasSearched["DIMPSUsername"])
                    HotkeyController.AutoSearch(
                        "https://dimps.optusnet.com.au/search/account?account_no=" + Username,
                        "DIMPS",
                        "https://dimps.optusnet.com.au",
                        true,
                        "Username");

                if (!Service.WasSearched["UNMT"])
                    Service.WasSearched["UNMT"] = HotkeyController.AutoSearch(
                        "https://staff.optusnet.com.au/tools/usernames/users.html?username=" + Username,
                        "OptusNet StaffWeb",
                        "https://staff.optusnet.com.au/tools/usernames", false);

                return true;
            }

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
}
