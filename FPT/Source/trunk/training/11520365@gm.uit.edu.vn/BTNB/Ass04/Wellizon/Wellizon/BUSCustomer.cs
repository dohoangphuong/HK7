using System;
using System.Data;

namespace Wellizon
{
    class BUSCustomer
    {
        DAOCustomer dao_cust = new DAOCustomer();
        public DataTable getData()
        {
            return dao_cust.getData();
        }
        public int Insert(CustomerInfo custInfo)
        {
            return dao_cust.Insert(custInfo);
        }
        public int Update(CustomerInfo custInfo)
        {
            return dao_cust.Update(custInfo);
        }
        public int Insert(int custID)
        {
            return dao_cust.Delete(custID);
        }
    }
}
