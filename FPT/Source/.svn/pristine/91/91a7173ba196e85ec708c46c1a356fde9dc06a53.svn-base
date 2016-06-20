using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3_opt1
{
    public enum PostDepartment
    {
        ChiefDepartment,
        DeputyDepartment,
        EmployeeDepartment,
    }

    class Staff : Personnel
    {
        private string _department;

        public string Department
        {
            get { return _department; }
            set { _department = value; }
        }
        private PostDepartment _post;

        public PostDepartment Post
        {
            get { return _post; }
            set { _post = value; SetAllowance(); }
        }
        private int _workday;

        public int Workday
        {
            get { return _workday; }
            set { _workday = value; SetAllowance(); }
        }

        public override void SetAllowance()
        {
            switch (_post)
            {
                case PostDepartment.EmployeeDepartment:
                    if (_allowance < 500)
                        _allowance = 500;
                    break;
                case PostDepartment.DeputyDepartment:
                    if (_allowance < 1000)
                        _allowance = 1000;
                    break;
                case PostDepartment.ChiefDepartment:
                    if (_allowance < 2000)
                        _allowance = 2000; // is max allowance
                    return;
            }
        }

        public override void SetSalary()
        {
            try
            {
                Salary = _coefficientSalary * 730 + _allowance + _workday * 30;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override bool StaffSearch(string fullName, string department)
        {
            try
            {
                if (_fullName.Trim().ToLower() != fullName.Trim().ToLower())
                    return false;
                if (_department.Trim().ToLower() != department.Trim().ToLower())
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string ShowInformation()
        {
            string result = "";
            string post = "";
            switch (_post)
            {
                case PostDepartment.EmployeeDepartment:
                    post = "Nhan Vien";
                    break;
                case PostDepartment.DeputyDepartment:
                    post = "Pho Phong";
                    break;
                case PostDepartment.ChiefDepartment:
                    post = "Truong Phong";
                    break;
            }
            result = string.Format("\t{0,-30}\t{1,-20}\t{2,-15}\t{3,-8}\t{4,-8}\t{5,-20}\t{6,-20}",
                _fullName, _department, _workday, _coefficientSalary, _allowance, post, _salary);

            return result;
        }

    }
}
