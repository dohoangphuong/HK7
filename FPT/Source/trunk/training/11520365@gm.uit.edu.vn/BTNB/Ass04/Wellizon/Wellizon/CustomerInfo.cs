using System;
using System.Collections.Generic;
using System.Text;

namespace Wellizon
{
    class CustomerInfo
    {
        int customerID;

        public int CustomerID
        {
            get { return customerID; }
            set { customerID = value; }
        }
        string custName;

        public string CustName
        {
            get { return custName; }
            set { custName = value; }
        }
        int custAge;

        public int CustAge
        {
            get { return custAge; }
            set { custAge = value; }
        }
        string custAddress;

        public string CustAddress
        {
            get { return custAddress; }
            set { custAddress = value; }
        }
        string custEMail;

        public string CustEMail
        {
            get { return custEMail; }
            set { custEMail = value; }
        }
        string problem;

        public string Problem
        {
            get { return problem; }
            set { problem = value; }
        }
        bool status;

        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        DateTime dateSolved;

        public DateTime DateSolved
        {
            get { return dateSolved; }
            set { dateSolved = value; }
        }
    }
}
