using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3_opt1
{
    public enum Literacy
    { 
        Bachelor,
        Master,
        Doctor,
    }
    class Teacher: Personnel
    {
        private string _faculty; // khoa

        public string Faculty
        {
            get { return _faculty; }
            set { _faculty = value; }
        }
        private Literacy _literacy; // trinh do, hoc vi

        public Literacy Literacy1
        {
            get { return _literacy;  }
            set { _literacy = value; SetAllowance(); }
        }

        private int _lessonPerMonth; // so tiet/thang

        public int LessonPerMonth
        {
            get { return _lessonPerMonth; }
            set { _lessonPerMonth = value; SetAllowance(); }
        }

        public Teacher()
        {
            _faculty = "";
            _literacy = Literacy.Bachelor;
            _lessonPerMonth = 0;
        }

        public override void SetAllowance() 
        {
            switch (_literacy)
            {
                case Literacy.Bachelor:
                    if (_allowance < 300)
                        _allowance = 300;
                    break;
                case Literacy.Master:
                    if (_allowance < 500)
                        _allowance = 500;
                    break;
                case Literacy.Doctor:
                    if (_allowance < 1000)
                        _allowance = 1000; // is max allowance
                    return;
            }
        }

        public override void SetSalary() 
        {
            try
            {
                Salary = _coefficientSalary * 730 + _allowance + _lessonPerMonth * 45;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override string ShowInformation()
        {
            string result = "";
            string literacy = "";
            switch (_literacy)
            { 
                case Literacy.Bachelor:
                    literacy = "Cu Nhan";
                    break;
                case Literacy.Doctor:
                    literacy = "Tien Si";
                    break;
                case Literacy.Master:
                    literacy = "Thac Si";
                    break;
            }
            result = string.Format("\t{0,-30}\t{1,-20}\t{2,-15}\t{3,-8}\t{4,-8}\t{5,-20}\t{6,-20}",
                _fullName, _faculty, _lessonPerMonth, _coefficientSalary, _allowance, literacy, _salary);

            return result;
        }

    }
}
