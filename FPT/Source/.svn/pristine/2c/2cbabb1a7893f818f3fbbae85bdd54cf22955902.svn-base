using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicesDirectory.Models.DatabaseMapper;

namespace ServicesDirectory.DataAccess
{
    public class ServiceSubTypeDataAccess
    {
        public List<ServiceSubType> GetAllServiceSubTypes()
        {
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            return entities.ServiceSubTypes.ToList();
        }
    }
}