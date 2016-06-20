using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServicesDirectory.Models.DatabaseMapper;

namespace ServicesDirectory.DataAccess
{
    public class RefDataDataAccess
    {
        public List<RefDataDetail> GetRefDataDetailsByRefDataName(string refDataName)
        {
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            return (from d in entities.RefDataDetails where d.RefData.RefDataName == refDataName select d).ToList();
        }

        public List<RefDataDetailUI> GetRefDataDetailUIs(string refDataName)
        {
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            var refDataDetails = (from d in entities.RefDataDetails where d.RefData.RefDataName == refDataName select d).ToList();
            List<RefDataDetailUI> refDataDetailUIs = new List<RefDataDetailUI>();
            foreach (var item in refDataDetails)
            {
                refDataDetailUIs.Add(new RefDataDetailUI(item));
            }
            return refDataDetailUIs;
        }

        public List<RefDataDetail> GetRefDataDetails(string[] refDataNames)
        {
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            List<RefDataDetail> result = new List<RefDataDetail>();
            foreach(string refDataName in refDataNames)
            {
                List<RefDataDetail> refDataDetails = (from d in entities.RefDataDetails where d.RefData.RefDataName == refDataName.Replace(" ", "") select d).ToList();
                result.AddRange(refDataDetails);
            }
            return result;
        }

        public List<RefDataDetailUI> GetRefDataDetailUIsWithIsChecked(string refDataName, int serviceId)
        {
            //Get all RefDataDetails that is linked to RefData that has refDataName
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            var refDataDetails = (from d in entities.RefDataDetails where d.RefData.RefDataName == refDataName select d).ToList();
            List<RefDataDetailUI> refDataDetailUIs = new List<RefDataDetailUI>();
            foreach(var item in refDataDetails)
            {
                refDataDetailUIs.Add(new RefDataDetailUI(item));
            }

            //Get all RefDataDetails that is linked to Service that has serviceId:
            var serviceLinkedRefDataDetailIds = (from service_ref in entities.Service_RefDataDetail
                                                 where service_ref.ServiceId == serviceId
                                                 && service_ref.RefDataDetail.RefData.RefDataName == refDataName
                                                 select service_ref.RefDataDetailId).ToList();
            foreach(var item in refDataDetailUIs)
            {
                foreach(var id in serviceLinkedRefDataDetailIds)
                {
                    if(item.RefDataDetailId == id)
                    {
                        item.IsChecked = true;
                        continue;
                    }
                }
            }

            return refDataDetailUIs;
        }


        public void RemoveAllRefDataDetailsLinkedToService(int serviceId)
        {
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            List<Service_RefDataDetail> service_ref = (from d in entities.Service_RefDataDetail where d.ServiceId == serviceId select d).ToList();
            for(int i = 0; i < service_ref.Count(); ++i)
            {
                entities.Service_RefDataDetail.Remove(service_ref[i]);
            }
            entities.SaveChanges();
        }

        public void RemoveRefDataDetailsLinkedToService(int serviceId, int[] refDataDetailIds)
        {
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            List<Service_RefDataDetail> service_ref = (from d in entities.Service_RefDataDetail where d.ServiceId == serviceId && refDataDetailIds.Contains(d.RefDataDetailId) select d).ToList();
            for (int i = 0; i < service_ref.Count(); ++i)
            {
                entities.Service_RefDataDetail.Remove(service_ref[i]);
            }
            entities.SaveChanges();
        }

        public void LinkRefDataDetailsToService(int serviceId, int[] refDataDetailIds)
        {
            ABSDDatabaseEntities entities = new ABSDDatabaseEntities();
            foreach(int refDataDetailId in refDataDetailIds)
            {
                entities.Service_RefDataDetail.Add(new Service_RefDataDetail
                {
                    ServiceId = serviceId,
                    RefDataDetailId = refDataDetailId
                });
            }
            entities.SaveChanges();
        }
    }
}