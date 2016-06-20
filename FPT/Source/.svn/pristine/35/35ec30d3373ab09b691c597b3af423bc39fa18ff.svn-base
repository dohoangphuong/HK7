using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3_opt1
{
    class Personnel
    {
        protected string _fullName; // ten

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        protected int _allowance; // phu cap

        public int Allowance
        {
            get { return _allowance; }
            private set { _allowance = value; }
        }
        protected int _coefficientSalary; // he so luong

        public int CoefficientSalary
        {
            get { return _coefficientSalary; }
            set { _coefficientSalary = value; }
        }
        protected int _salary; // tien luong

        public int Salary
        {
            get { return _salary; }
            protected set { _salary = value; }
        }

        public Personnel()
        {
            _fullName = "";
            _allowance = 0;
            _coefficientSalary = 0;
            _salary = 0;
        }

        public virtual void SetAllowance() { }

        public virtual void SetSalary() { }

        public virtual string ShowInformation() { return ""; }

        public bool CheckFullName(string fullNameToCheck)
        {
            if (_fullName.Trim().ToLower() == fullNameToCheck.Trim().ToLower())
                return true;
            return false;
        }

        public virtual bool StaffSearch(string fullName, string department)
        {
            return false;
        }

    }
}
