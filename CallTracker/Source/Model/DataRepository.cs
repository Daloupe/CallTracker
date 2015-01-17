using CallTracker.DataSets;
using CallTracker.Helpers;
using CallTracker.Helpers.Types;
using ProtoBuf;
using ProtoBuf.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;

namespace CallTracker.Model
{
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // Trigger List /////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class TriggerList<T> : List<T>
    {
        public delegate void ChangedEventHandler();

        public event ChangedEventHandler Changed;

        public new void Add(T item)
        {
            base.Add(item);
            if (Changed != null)
                Changed();
        }

        public new void Remove(T item)
        {
            base.Remove(item);
            if (Changed != null)
                Changed();
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // Base Class ///////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    internal abstract class DataRepository<T>
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

        public virtual void SaveFile(T dataStore)
        {
            var _dataStore = dataStore;

            using (var file = File.Create(Filename))
                Serializer.Serialize(file, _dataStore);
        }

        public virtual void DecryptData(T dataStore)
        {
            //var _dataStore = dataStore;

            //var key = StringCipher.Encrypt(Environment.UserName, "2point71828");
            ////foreach (var login in dataStore.Logins)
            ////    login.Password = StringCipher.Decrypt(login.Password, key);
        }

        public virtual void EncryptData(T dataStore)
        {
            //T _dataStore = dataStore;

            ////foreach (var login in dataStore.Logins)
            ////    login.Password = StringCipher.Encrypt(login.Password, StringCipher.Encrypt(Environment.UserName, "2point71828"));
        }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //// Binds /////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    [ProtoContract]
    internal class BindsDataStore : DataRepository<BindsDataStore>
    {
        [ProtoMember(1)]
        internal TriggerList<PasteBind> PasteBinds { get; set; }

        [ProtoMember(2)]
        internal GridLinksModel GridLinks { get; set; }

        public BindsDataStore()
        {
            Filename = "Data/Binds.bin";
            PasteBinds = new TriggerList<PasteBind>();
            GridLinks = new GridLinksModel();
        }

        public void ReadData()
        {
            BindsDataStore dataStore;

            if (!File.Exists(Filename))
            {
                File.Create(Filename).Close();
                Properties.Settings.Default.NextContactsId = 0;
            }
            using (var file = File.OpenRead(Filename))
                dataStore = Serializer.Deserialize<BindsDataStore>(file);

            //if (dataStore.Contacts.Count == 0)
            //    dataStore.Contacts.AddNew();

            PasteBinds = dataStore.PasteBinds;
            GridLinks = dataStore.GridLinks;

            GridLinks.PopulateIfEmpty();
        }

        public void WriteData()
        {
            using (var file = File.Create(Filename))
                Serializer.Serialize(file, this);
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // Logins /////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [ProtoContract]
    internal class LoginDataStore : DataRepository<LoginDataStore>
    {
        [ProtoMember(1)]
        internal string User { get; set; }

        [ProtoMember(2)]
        internal BindingList<LoginsModel> Logins { get; set; }

        public LoginDataStore()
        {
            Filename = "Data/Logins.bin";
            User = String.Empty;
            Logins = new BindingList<LoginsModel>();
        }

        public void ReadData()
        {
            LoginDataStore dataStore;

            if (!File.Exists(Filename))
            {
                File.Create(Filename).Close();
            }
            using (var file = File.OpenRead(Filename))
                dataStore = Serializer.Deserialize<LoginDataStore>(file);

            User = dataStore.User;
            Logins = dataStore.Logins;//new BindingList<LoginsModel>(dataStore.Logins.ToList());

            DecryptData();
        }

        public void WriteData()
        {
            EncryptData();
            
            using (var file = File.Create(Filename))
                Serializer.Serialize(file, this);
        }

        public void DecryptData()
        {
            User = StringCipher.Decrypt(User, "jumpingfivemammotheightyeight");
            if (User != Environment.UserName)
            {
                User = Environment.UserName;
                foreach (var login in Logins)
                    login.Password = String.Empty;
            }
            else
            {
                var key = StringCipher.Encrypt(Environment.UserName, "2point71828");
                foreach (var login in Logins)
                    login.Password = StringCipher.Decrypt(login.Password, key);
            }
        }

        public void EncryptData()
        {
            User = StringCipher.Encrypt(User, "jumpingfivemammotheightyeight");

            foreach (var login in Logins)
                login.Password = StringCipher.Encrypt(login.Password, StringCipher.Encrypt(Environment.UserName, "2point71828"));
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

        private const string FILENAME = "Data/Contacts.bin";

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

        public void ReadData()
        {
            DailyDataRepository dataStore;

            if (!File.Exists(FILENAME))
            {
                File.Create(FILENAME).Close();
                Properties.Settings.Default.NextContactsId = 0;
            }
            using (var file = File.OpenRead(FILENAME))
                dataStore = Serializer.Deserialize<DailyDataRepository>(file);

            //if (dataStore == null)
            //{
            //    dataStore = new DailyDataRepository();
            //    dataStore.DailyData.AddNew();
            //}

            if (dataStore.DailyData == null)
                DailyData.AddNew();
            else
                DailyData = dataStore.DailyData;

            //return dataStore;
            //DailyData = new FilterableBindingList<DailyModel>(dataStore.DailyData.ToList());
        }

        public void WriteData()
        {
            using (var file = File.Create(FILENAME))
                Serializer.Serialize(file, this);
        }
    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////
    // Services /////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [ProtoContract]
    internal class ServicesData
    {
        private const string Filename = "Data/Resources.bin";

        [ProtoMember(1)]
        internal ServicesDataSet servicesDataSet { get; set; }

        public ServicesData()
        {
            servicesDataSet = new ServicesDataSet();
        }

        public void WriteData()
        {
            //DataTable[] dtarray = new DataTable[servicesDataSet.Tables.Count];

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
                using (var reader = DataSerializer.Deserialize(stream))
                {
                    var dtarray = new DataTable[servicesDataSet.Tables.Count];
                    servicesDataSet.Tables.CopyTo(dtarray, 0);
                    servicesDataSet.Load(reader, LoadOption.OverwriteChanges, dtarray);
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
            foreach (var name in Enum.GetNames(typeof(ProblemStyle)))
            {
                var newRow = servicesDataSet.ProblemStyles.NewProblemStylesRow();
                newRow.IFMSCode = name;
                servicesDataSet.ProblemStyles.AddProblemStylesRow(newRow);
            }

            foreach (var name in Enum.GetNames(typeof(SymptomGroups)))
            {
                var newRow = servicesDataSet.SymptomGroups.NewSymptomGroupsRow();
                newRow.IFMSCode = Enum.Parse(typeof(SymptomGroups), name).ToString();
                newRow.Description = name;
                servicesDataSet.SymptomGroups.AddSymptomGroupsRow(newRow);
            }

            foreach (var item in DataLists.SymptomsList)
            {
                var newRow = servicesDataSet.Symptoms.NewSymptomsRow();
                newRow.IFMSCode = Enum.GetName(typeof(SymptomsEnum), item.Key);
                newRow.ICONNote = item.Value;
                newRow.Description = item.Value;
                servicesDataSet.Symptoms.AddSymptomsRow(newRow);
            }

            foreach (var name in Enum.GetNames(typeof(FaultSeverity)))
            {
                var newRow = servicesDataSet.SeverityCodes.NewSeverityCodesRow();
                newRow.IFMSCode = name;
                servicesDataSet.SeverityCodes.AddSeverityCodesRow(newRow);
            }

            foreach (var name in Enum.GetNames(typeof(Outcomes)))
            {
                var newRow = servicesDataSet.Outcomes.NewOutcomesRow();
                newRow.Acronym = name;
                servicesDataSet.Outcomes.AddOutcomesRow(newRow);
            }

            foreach (var item in DataLists.DepartmentsList)
            {
                var newRow = servicesDataSet.DepartmentNames.NewDepartmentNamesRow();
                newRow.NameShort = item.Key;
                newRow.NameLong = item.Value;
                servicesDataSet.DepartmentNames.AddDepartmentNamesRow(newRow);
            }

            foreach (var name in Enum.GetNames(typeof(ServiceTypes)))
            {
                if (name == "NONE")
                    continue;
                var newRow = servicesDataSet.Services.NewServicesRow();
                newRow.Name = name;

                var problemStyle = servicesDataSet.ProblemStyles.FirstOrDefault(x => x.IFMSCode == name);
                if (problemStyle != null)
                    newRow.ProblemStyleId = problemStyle.Id;
                else
                    newRow.ProblemStyleId = 0;
                newRow.ProductCode = name;
                //newRow.ProductCodeID = 0;
                //Console.WriteLine("id: {0}, name:{1}", newRow.ServiceID, newRow.Name);
                servicesDataSet.Services.AddServicesRow(newRow);

                foreach (var item in servicesDataSet.DepartmentNames)
                {
                    var newDepartment = servicesDataSet.Departments.NewDepartmentsRow();
                    newDepartment.DepartmentNameId = item.Id;
                    newDepartment.ServiceId = newRow.Id;
                    newDepartment.InternalContact = 52500;
                    newDepartment.ExternalContact = 1800555241;
                    newDepartment.ContactHours = "Mon-Fri: 8-7 \nSat: 9-5 \nSun: Closed";
                    //Console.WriteLine("id: {0}, name:{1}", NewDepartment.DepartmentID, NewDepartment.Name);
                    servicesDataSet.Departments.AddDepartmentsRow(newDepartment);
                }
            }
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