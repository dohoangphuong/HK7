using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicesDirectory.Models.DatabaseMapper;

namespace ServicesDirectory.DataAccess
{
    public class ContactDataAccess
    {
        public List<Contact> GetAllContacts()
        {
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            return entities.Contacts.ToList();
        }
    }
}