using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicesDirectory.Models.DatabaseMapper;

namespace ServicesDirectory.DataAccess
{
    public class ReferralMethodDataAccess
    {
        public List<ReferralMethod> GetAllReferralMethods()
        {
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            return entities.ReferralMethods.ToList();
        }
    }
}