using ServicesDirectory.Models.DatabaseMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicesDirectory.DataAccess
{
    public class ServiceDataAccess
    {
        public List<Service> GetAllServices()
        {
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            return entities.Services.ToList();
        }

        public Service GetServiceById(int serviceId)
        {
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            Service service = (from d in entities.Services where d.ServiceId == serviceId select d).FirstOrDefault();
            return service;
        }

        public bool AddService(Service service)
        {
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            try
            {
                entities.Services.Add(service);
                entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return false;
            }
        }
    }
}