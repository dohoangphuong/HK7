using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    abstract class Staff: IComparable<Staff>
    {
        /// <summary>
        /// staff's name
        /// </summary>
        private string strName;
        public string Name
        {
            get { return strName; }
            set { strName = value; }
        }

        /// <summary>
        /// staff's salary ratio
        /// </summary>
        protected float fltSalaryRatio;

        /// <summary>
        /// staff's salary
        /// </summary>
        protected float fltSalary;

        /// <summary>
        /// input method
        /// </summary>
        /// <param name="objDeptOrFac"></param>
        /// <param name="objPosOrDeg"></param>
        public abstract void Input(object objDeptOrFac, object objPosOrDeg);

        /// <summary>
        /// ouput method
        /// </summary>
        public abstract void Output();

        /// <summary>
        /// calculate staff's salary
        /// </summary>
        protected abstract void CalculateSalary();

        /// <summary>
        /// implement CompareTo() method from interface IComparable
        /// </summary>
        /// <param name="another"></param>
        /// <returns></returns>
        public int CompareTo(Staff another)
        {
            if (this.fltSalary < another.fltSalary)
                return -1;
            else if (this.fltSalary > another.fltSalary)
                return 1;
            else
                return this.strName.CompareTo(another.strName);
        }
    }
}
