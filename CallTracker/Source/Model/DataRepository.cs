using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

//using CallTracker.Model;
using CallTracker.Helpers;

using ProtoBuf;

namespace CallTracker.Model
{
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

    [ProtoContract]
    internal class DataRepository
    {
        [ProtoMember(1)]
        internal TriggerList<PasteBind> PasteBinds { get; set; }
        [ProtoMember(2)]
        internal List<CustomerContact> Contacts { get; set; }
        [ProtoMember(3)]
        internal List<LoginsModel> Logins { get; set; }
        [ProtoMember(4)]
        internal GridLinksModel GridLinks { get; set; }

        //public List<T> Remove

        public DataRepository()
        {
            PasteBinds = new TriggerList<PasteBind>();
            Contacts = new List<CustomerContact>();
            Logins = new List<LoginsModel>();
            GridLinks = new GridLinksModel();
        }

        public static DataRepository ReadFile()
        {
            DataRepository dataStore;

            if (!File.Exists("Data.bin"))
                File.Create("Data.bin").Close();    
            using (var file = File.OpenRead("Data.bin"))
                dataStore = Serializer.Deserialize<DataRepository>(file);
            
            DecryptData(dataStore);
            
            CustomerContact newContact = new CustomerContact();
            newContact.Id = dataStore.Contacts.Count;
            newContact.Contacts.StartDate = DateTime.Today;
            newContact.Contacts.StartTime = DateTime.Now.TimeOfDay;

            dataStore.Contacts.Add(newContact);
            dataStore.GridLinks.PopulateIfEmpty();

            return dataStore;
        }

        public static void SaveFile(DataRepository _dataStore)
        {
            DataRepository dataStore = _dataStore;

            EncryptData(dataStore);
            using (var file = File.Create("Data.bin"))
                Serializer.Serialize<DataRepository>(file, dataStore);
        }

        private static void DecryptData(DataRepository _dataStore)
        {
            DataRepository dataStore = _dataStore;

            string key = StringCipher.Encrypt(Environment.UserName, "2point71828");
            foreach (var login in dataStore.Logins)
                login.Password = StringCipher.Decrypt(login.Password, key);
        }

        private static void EncryptData(DataRepository _dataStore)
        {
            DataRepository dataStore = _dataStore;

            foreach (var login in dataStore.Logins)
                login.Password = StringCipher.Encrypt(login.Password, StringCipher.Encrypt(Environment.UserName, "2point71828"));

        }
    }
}
