using System;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using System.Collections.ObjectModel;
using System.Linq;

namespace AgendaXF.Classes
{
    public class Database : SQLiteConnection
    {
        ObservableCollection<Contact> ContactsTable;

        public Database(string db) : base(db)
		{
            CreateTables();
        }

        void CreateTables()
        {
            CreateTable<Contact>();
            ContactsTable = new ObservableCollection<Contact>(this.Table<Contact>().ToList());
        }

        public bool RegisterContact(Contact data, bool insert)
        {
            try
            {
                if (insert)
                    this.Insert(data);
                else
                {
                    this.Update(data);
                }

                return true;
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }

        public ObservableCollection<Contact> GetContacts()
        {
            return new ObservableCollection<Contact>(this.Table<Contact>().ToList());
        }

        public Contact GetContact(int id)
        {
            return (id == 0) ? new Contact() : Table<Contact>().Where(t => t.Id == id).First();
        }
    }
}