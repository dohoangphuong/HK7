using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicesDirectory.Models.DatabaseMapper;

namespace ServicesDirectory.DataAccess
{
    public class ServiceTypeDataAccess
    {
        public List<ServiceType> GetAllServiceTypes()
        {
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            return entities.ServiceTypes.ToList();
        }
    }
}