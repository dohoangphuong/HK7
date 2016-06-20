using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Lecturer: Staff
    {
        /// <summary>
        /// the faculty
        /// </summary>
        private Faculty Fac;

        /// <summary>
        /// the degree
        /// </summary>
        private Degree Deg;

        /// <summary>
        /// number of periods
        /// </summary>
        private int intPeriods;

        /// <summary>
        /// input lectureer
        /// </summary>
        public override void Input(object objFacculty, object objDegree)
        {
            Console.Write("\nName: ");
            Name = Console.ReadLine();
            this.Fac = objFacculty as Faculty;
            this.Deg = objDegree as Degree;
            do
            {
                Console.Write("Number of periods: ");
            } while (!Int32.TryParse(Console.ReadLine(), out intPeriods) || intPeriods < 0);
            do
            {
                Console.Write("Salary ratio: ");
            } while (!float.TryParse(Console.ReadLine(), out fltSalaryRatio)
                || fltSalaryRatio < 0.0f || fltSalaryRatio > 100.0f);

            CalculateSalary();
        }

        /// <summary>
        /// output lecturer
        /// </summary>
        public override void Output()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}"
                , Name, Fac.FacultyName, Deg.DegreeName, Deg.Allowance, intPeriods, fltSalaryRatio, fltSalary);
        }

        /// <summary>
        /// calculate the salary
        /// </summary>
        protected override void CalculateSalary()
        {
            fltSalary = fltSalaryRatio*730 + Deg.Allowance + intPeriods*45;
        }
    }
}
