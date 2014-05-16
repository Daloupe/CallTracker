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
    [ProtoContract]
    internal class DataRepository
    {
        [ProtoMember(1)]
        internal List<PasteBind> PasteBinds { get; set; }
        [ProtoMember(2)]
        internal List<CustomerContact> Contacts { get; set; }
        [ProtoMember(3)]
        internal List<LoginsModel> Logins { get; set; }
        [ProtoMember(4)]
        internal GridLinksModel GridLinks { get; set; }

        public DataRepository()
        {
            PasteBinds = new List<PasteBind>();
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
            dataStore.Contacts.Add(new CustomerContact() { Id = dataStore.Contacts.Count });
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
