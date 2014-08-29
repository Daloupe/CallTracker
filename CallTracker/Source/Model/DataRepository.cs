using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.ComponentModel;
using System.Data;

using CallTracker.Helpers;
using CallTracker.DataSets;
using CallTracker.Helpers.Types;
using ProtoBuf;
using ProtoBuf.Data;

namespace CallTracker.Model
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // Trigger List /////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class TriggerList<T> : List<T>
    { 
        public delegate void ChangedEventHandler();
        public event ChangedEventHandler Changed;

        public new void Add(T _item)
        {
            base.Add(_item);
            if (Changed != null)
                Changed();
        }

        public new void Remove(T _item)
        {
            base.Remove(_item);
            if (Changed != null)
                Changed();
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // Base Class ///////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    abstract class DataRepository<T>
    {
        protected string Filename;

        public virtual T ReadFile()
        {
            T dataStore;

            if (!File.Exists(Filename))
                File.Create(Filename).Close();
            using (var file = File.OpenRead(Filename))
                dataStore = Serializer.Deserialize<T>(file);

            return dataStore;
        }

        public virtual void SaveFile(T _dataStore)
        {
            T dataStore = _dataStore;

            using (var file = File.Create(Filename))
                Serializer.Serialize<T>(file, dataStore);
        }

        public virtual void DecryptData(T _dataStore)
        {
            T dataStore = _dataStore;

            string key = StringCipher.Encrypt(Environment.UserName, "2point71828");
            //foreach (var login in dataStore.Logins)
            //    login.Password = StringCipher.Decrypt(login.Password, key);
        }

        public virtual void EncryptData(T _dataStore)
        {
            T dataStore = _dataStore;

            //foreach (var login in dataStore.Logins)
            //    login.Password = StringCipher.Encrypt(login.Password, StringCipher.Encrypt(Environment.UserName, "2point71828"));

        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // User Data ////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [ProtoContract]
    internal class UserDataStore : DataRepository<UserDataStore>
    {
        [ProtoMember(1)]
        internal TriggerList<PasteBind> PasteBinds { get; set; }
        [ProtoMember(2)]
        internal BindingList<LoginsModel> Logins { get; set; }
        [ProtoMember(3)]
        internal GridLinksModel GridLinks { get; set; }
        [ProtoMember(4)]
        internal string User { get; set; }

        public UserDataStore()
        {
            Filename = "Data/UserData.bin";

            PasteBinds = new TriggerList<PasteBind>();
            Logins = new BindingList<LoginsModel>();
            GridLinks = new GridLinksModel();
            User = String.Empty;
        }

        public override UserDataStore ReadFile()
        {
            UserDataStore dataStore;

            if (!File.Exists(Filename))
            {
                File.Create(Filename).Close();
            }
            using (var file = File.OpenRead(Filename))
                dataStore = Serializer.Deserialize<UserDataStore>(file);

            DecryptData(dataStore);

            //dataStore.GridLinks.SystemItems = new List<SystemItem>();
            dataStore.GridLinks.PopulateIfEmpty();

            return dataStore;
        }

        public override void SaveFile(UserDataStore _dataStore)
        {
            UserDataStore dataStore = _dataStore;

            EncryptData(dataStore);
            using (var file = File.Create(Filename))
                Serializer.Serialize<UserDataStore>(file, dataStore);
        }

        public override void DecryptData(UserDataStore _dataStore)
        {
            UserDataStore dataStore = _dataStore;

            dataStore.User = StringCipher.Decrypt(dataStore.User, "jumpingfivemammotheightyeight");
            if (dataStore.User != Environment.UserName)
            {
                dataStore.User = Environment.UserName;
                foreach (var login in dataStore.Logins)
                    login.Password = String.Empty;
            }
            else
            {
                string key = StringCipher.Encrypt(Environment.UserName, "2point71828");
                foreach (var login in dataStore.Logins)
                    login.Password = StringCipher.Decrypt(login.Password, key);
            }
        }

        public override void EncryptData(UserDataStore _dataStore)
        {
            UserDataStore dataStore = _dataStore;
            dataStore.User = StringCipher.Encrypt(dataStore.User, "jumpingfivemammotheightyeight");

            foreach (var login in dataStore.Logins)
                login.Password = StringCipher.Encrypt(login.Password, StringCipher.Encrypt(Environment.UserName, "2point71828"));

        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // Contacts /////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [ProtoContract]
    internal class ContactDataStore : DataRepository<ContactDataStore>
    {
        [ProtoMember(1)]
        internal FilterableBindingList<CustomerContact> Contacts { get; set; }

        public ContactDataStore()
        {
            Filename = "Data/Contacts.bin";
            Contacts = new FilterableBindingList<CustomerContact>();
        }

        public void ReadData()
        {
            ContactDataStore dataStore;

            if (!File.Exists(Filename))
            {
                File.Create(Filename).Close();
                Properties.Settings.Default.NextContactsId = 0;
            }
            using (var file = File.OpenRead(Filename))
                dataStore = Serializer.Deserialize<ContactDataStore>(file);

            //if (dataStore.Contacts.Count == 0)
            //    dataStore.Contacts.AddNew();

            Contacts = new FilterableBindingList<CustomerContact>(dataStore.Contacts.ToList());
        }

        public void WriteData()
        {
          
            using (var file = File.Create(Filename))
                Serializer.Serialize(file, this);
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // DailyData /////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [ProtoContract(SkipConstructor = true)]
    internal class DailyDataRepository : DataRepository<DailyDataRepository>
    {
        [ProtoMember(1)]
        internal FilterableBindingList<DailyModel> DailyData { get; set; }

        private const string _filename = "Data/Contacts.bin";
        public DailyDataRepository()
        {
        //    Filename = "Data/Contacts.bin";
            DailyData = new FilterableBindingList<DailyModel>();
        }

        [ProtoBeforeDeserialization]
        private void Initializer()
        {
            DailyData = new FilterableBindingList<DailyModel>();
        }

        public static DailyDataRepository ReadData()
        {
            DailyDataRepository dataStore;

            if (!File.Exists(_filename))
            {
                File.Create(_filename).Close();
                Properties.Settings.Default.NextContactsId = 0;
            }
            using (var file = File.OpenRead(_filename))
                dataStore = Serializer.Deserialize<DailyDataRepository>(file);

            if (dataStore == null)
            {
                dataStore = new DailyDataRepository();
                dataStore.DailyData.AddNew();
            }
            return dataStore;
            //DailyData = new FilterableBindingList<DailyModel>(dataStore.DailyData.ToList());
        }

        public void WriteData()
        {
            using (var file = File.Create(_filename))
                Serializer.Serialize(file, this);
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // Services /////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [ProtoContract]
    internal class ServicesData
    {
        private string Filename;
        [ProtoMember(1)]
        internal ServicesDataSet servicesDataSet { get; set; }


        public ServicesData()
        {
            Filename = "Data/Resources.bin";
            servicesDataSet = new ServicesDataSet();
        }

        public void WriteData()
        {
            DataTable[] dtarray = new DataTable[servicesDataSet.Tables.Count];

            using (Stream stream = File.OpenWrite(Filename))
            using (IDataReader reader = servicesDataSet.CreateDataReader())
            {
                DataSerializer.Serialize(stream, reader);
                stream.SetLength(stream.Position);
            }

        }

        public void ReadData()
        {
            if (!File.Exists(Filename))
            {
                CreateNewServices();
                File.Create(Filename).Close();
                WriteData();
            }
            else
            {
                
                using (Stream stream = File.OpenRead(Filename))
                using (IDataReader reader = DataSerializer.Deserialize(stream))
                {
                    DataTable[] dtarray = new DataTable[servicesDataSet.Tables.Count];
                    servicesDataSet.Tables.CopyTo(dtarray, 0);
                    servicesDataSet.Load(reader, LoadOption.OverwriteChanges, dtarray);
;
                    //servicesDataSet.IFMSTier2IFMSTier3Match.Columns.Remove("Tier2Id");
                    //servicesDataSet.IFMSTier2IFMSTier3Match.Columns.Remove("Tier3Id");
                    //servicesDataSet.IFMSTier3IFMSTier4Match.Columns.Remove("Tier3Id");
                    //servicesDataSet.IFMSTier3IFMSTier4Match.Columns.Remove("Tier4Id");
                }
            }
        }

        public void CreateNewServices()
        {
            //string s = servicesDataSet.Departments[0].ServicesRow.Name.IFMSCode;
            foreach (string name in Enum.GetNames(typeof(ProblemStyle)))
            {
                ServicesDataSet.ProblemStylesRow newRow = servicesDataSet.ProblemStyles.NewProblemStylesRow();
                newRow.IFMSCode = name;
                servicesDataSet.ProblemStyles.AddProblemStylesRow(newRow);
            }

            foreach (string name in Enum.GetNames(typeof(SymptomGroups)))
            {
                ServicesDataSet.SymptomGroupsRow newRow = servicesDataSet.SymptomGroups.NewSymptomGroupsRow();
                newRow.IFMSCode = Enum.Parse(typeof(SymptomGroups), name).ToString();
                newRow.Description = name;
                servicesDataSet.SymptomGroups.AddSymptomGroupsRow(newRow);
            }

            foreach (var item in DataLists.SymptomsList)
            {
                ServicesDataSet.SymptomsRow newRow = servicesDataSet.Symptoms.NewSymptomsRow();
                newRow.IFMSCode = Enum.GetName(typeof(SymptomsEnum), item.Key);
                newRow.ICONNote = item.Value;
                newRow.Description = item.Value;
                servicesDataSet.Symptoms.AddSymptomsRow(newRow);
            }

            foreach (string name in Enum.GetNames(typeof(FaultSeverity)))
            {
                ServicesDataSet.SeverityCodesRow newRow = servicesDataSet.SeverityCodes.NewSeverityCodesRow();
                newRow.IFMSCode = name;
                servicesDataSet.SeverityCodes.AddSeverityCodesRow(newRow);
            }

            foreach (string name in Enum.GetNames(typeof(Outcomes)))
            {
                ServicesDataSet.OutcomesRow newRow = servicesDataSet.Outcomes.NewOutcomesRow();
                newRow.Acronym = name;
                servicesDataSet.Outcomes.AddOutcomesRow(newRow);
            }

            foreach (var item in DataLists.DepartmentsList)
            {
                ServicesDataSet.DepartmentNamesRow newRow = servicesDataSet.DepartmentNames.NewDepartmentNamesRow();
                newRow.NameShort = item.Key;
                newRow.NameLong = item.Value;
                servicesDataSet.DepartmentNames.AddDepartmentNamesRow(newRow);
            }

            foreach (string name in Enum.GetNames(typeof(ServiceTypes)))
            {
                if (name == "NONE")
                    continue;
                ServicesDataSet.ServicesRow newRow = servicesDataSet.Services.NewServicesRow();
                newRow.Name = name;
                if (servicesDataSet.ProblemStyles.FirstOrDefault(x => x.IFMSCode == name) != null)
                    newRow.ProblemStyleId = servicesDataSet.ProblemStyles.FirstOrDefault(x => x.IFMSCode == name).Id;
                else
                    newRow.ProblemStyleId = 0;
                newRow.ProductCode = name;
                //newRow.ProductCodeID = 0;
                //Console.WriteLine("id: {0}, name:{1}", newRow.ServiceID, newRow.Name);
                servicesDataSet.Services.AddServicesRow(newRow);

                foreach (var item in servicesDataSet.DepartmentNames)
                {
                    ServicesDataSet.DepartmentsRow NewDepartment = servicesDataSet.Departments.NewDepartmentsRow();
                    NewDepartment.DepartmentNameId = item.Id;
                    NewDepartment.ServiceId = newRow.Id;
                    NewDepartment.InternalContact = 52500;
                    NewDepartment.ExternalContact = 1800555241;
                    NewDepartment.ContactHours = "Mon-Fri: 8-7 \nSat: 9-5 \nSun: Closed";
                    //Console.WriteLine("id: {0}, name:{1}", NewDepartment.DepartmentID, NewDepartment.Name);
                    servicesDataSet.Departments.AddDepartmentsRow(NewDepartment);
                }
            };
            //ServicesDataSet.StatesRow newState = servicesDataSet.States.NewStatesRow();
            //newState.NameShort = "VIC";
            //servicesDataSet.States

            //servicesDataSet.Services.First(x => x.Name == "LAT").ProductCodeID = 


            //var deptQuery =
            //    (from dept in servicesDataSet.Departments
            //     where dept.Name == "CustomerCare" &&
            //           dept.ServiceID == servicesDataSet.Services.First(x => x.Name == "ONC").ServiceID
            //     select dept).FirstOrDefault();
            //ServicesDataSet.DepartmentsRow smth = (ServicesDataSet.ServicesRow)servicesDataSet.Departments..GetParentRow("FK_Services_Departments");
            //Console.WriteLine(smth.Name);
            //Console.WriteLine("id: {0}, name:{1}, service:{2}", servicesDataSet.Relations[0].RelationName, deptQuery.Name ,servicesDataSet.Services.First(x => x.ServiceID == deptQuery.ServiceID).Name);
        }
    }
}



////////////////////////////////////////////////////////////////////////////////////////////////////////
//// User Data ////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////////////////////

//[ProtoContract]
//internal class UserDataStore : DataRepository<UserDataStore>
//{
//    [ProtoMember(1)]
//    internal TriggerList<PasteBind> PasteBinds { get; set; }
//    [ProtoMember(2)]
//    internal SortableBindingList<CustomerContact> Contacts { get; set; }
//    [ProtoMember(3)]
//    internal BindingList<LoginsModel> Logins { get; set; }
//    [ProtoMember(4)]
//    internal GridLinksModel GridLinks { get; set; }
//    [ProtoMember(5)]
//    internal string User { get; set; }

//    public UserDataStore()
//    {
//        Filename = "Data/Data.bin";

//        PasteBinds = new TriggerList<PasteBind>();
//        Contacts = new SortableBindingList<CustomerContact>();
//        Logins = new BindingList<LoginsModel>();
//        GridLinks = new GridLinksModel();
//        User = String.Empty;
//    }

//    public override UserDataStore ReadFile()
//    {
//        UserDataStore dataStore;

//        if (!File.Exists(Filename))
//        {
//            File.Create(Filename).Close();
//            Properties.Settings.Default.NextContactsId = 0;
//        }
//        using (var file = File.OpenRead(Filename))
//            dataStore = Serializer.Deserialize<UserDataStore>(file);

//        DecryptData(dataStore);

//        //CustomerContact newContact = new CustomerContact();
//        //newContact.Id = dataStore.Contacts.Count;
//        //newContact.Contacts.StartDate = DateTime.Today;
//        //newContact.Contacts.StartTime = DateTime.Now.TimeOfDay;
//        //newContact.Fault.AffectedServices = 1;

//        if (dataStore.Contacts.Count == 0)
//            dataStore.Contacts.AddNew();//new CustomerContact());
//        dataStore.GridLinks.PopulateIfEmpty();

//        return dataStore;
//    }

//    public override void SaveFile(UserDataStore _dataStore)
//    {
//        UserDataStore dataStore = _dataStore;

//        EncryptData(dataStore);
//        using (var file = File.Create(Filename))
//            Serializer.Serialize<UserDataStore>(file, dataStore);
//    }

//    public override void DecryptData(UserDataStore _dataStore) 
//    {
//        UserDataStore dataStore = _dataStore;

//        dataStore.User = StringCipher.Decrypt(dataStore.User, "jumpingfivemammotheightyeight");
//        if (dataStore.User != Environment.UserName)
//        {
//            dataStore.User = Environment.UserName;
//            foreach (var login in dataStore.Logins)
//                login.Password = String.Empty;
//        }
//        else
//        {
//            string key = StringCipher.Encrypt(Environment.UserName, "2point71828");
//            foreach (var login in dataStore.Logins)
//                login.Password = StringCipher.Decrypt(login.Password, key);
//        }
//    }

//    public override void EncryptData(UserDataStore _dataStore)
//    {
//        UserDataStore dataStore = _dataStore;
//        dataStore.User = StringCipher.Encrypt(dataStore.User, "jumpingfivemammotheightyeight");

//        foreach (var login in dataStore.Logins)
//            login.Password = StringCipher.Encrypt(login.Password, StringCipher.Encrypt(Environment.UserName, "2point71828"));

//    }
//}