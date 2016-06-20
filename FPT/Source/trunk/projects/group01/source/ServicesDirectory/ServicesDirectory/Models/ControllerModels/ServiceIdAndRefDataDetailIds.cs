using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicesDirectory.Models.ControllerModels
{
    public class ServiceIdAndRefDataDetailIds
    {
        public IEnumerable<int> ref_data_detail_ids
        { get; set; }

        public int? service_id
        { get; set; }
    }
}