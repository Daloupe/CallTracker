using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;

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

    [ProtoContract]
    internal class UserDataStore : DataRepository<UserDataStore>
    {
        [ProtoMember(1)]
        internal TriggerList<PasteBind> PasteBinds { get; set; }
        [ProtoMember(2)]
        internal BindingList<CustomerContact> Contacts { get; set; }
        [ProtoMember(3)]
        internal BindingList<LoginsModel> Logins { get; set; }
        [ProtoMember(4)]
        internal GridLinksModel GridLinks { get; set; }

        public UserDataStore()
        {
            Filename = "Data.bin";

            PasteBinds = new TriggerList<PasteBind>();
            Contacts = new BindingList<CustomerContact>();
            Logins = new BindingList<LoginsModel>();
            GridLinks = new GridLinksModel();
        }

        public override UserDataStore ReadFile()
        {
            UserDataStore dataStore;

            if (!File.Exists(Filename))
                File.Create(Filename).Close();
            using (var file = File.OpenRead(Filename))
                dataStore = Serializer.Deserialize<UserDataStore>(file);

            DecryptData(dataStore);

            CustomerContact newContact = new CustomerContact();
            newContact.Id = dataStore.Contacts.Count;
            newContact.Contacts.StartDate = DateTime.Today;
            newContact.Contacts.StartTime = DateTime.Now.TimeOfDay;
            //newContact.Fault.AffectedServices = 1;

            dataStore.Contacts.Add(newContact);
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

            string key = StringCipher.Encrypt(Environment.UserName, "2point71828");
            foreach (var login in dataStore.Logins)
                login.Password = StringCipher.Decrypt(login.Password, key);
        }

        public override void EncryptData(UserDataStore _dataStore)
        {
            UserDataStore dataStore = _dataStore;

            foreach (var login in dataStore.Logins)
                login.Password = StringCipher.Encrypt(login.Password, StringCipher.Encrypt(Environment.UserName, "2point71828"));

        }
    }

    [ProtoContract]
    internal class ResourceData : DataRepository<ResourceData>
    {
        [ProtoMember(1)]
        internal BindingList<RateplanModel> LATRatePlans { get; set; }

        public ResourceData()
        {
            Filename = "Resources.bin";
            LATRatePlans = new BindingList<RateplanModel>();
        }

    }
}
