using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class ClericalStaff: Staff
    {
        /// <summary>
        /// department
        /// </summary>
        private Department Dept;

        /// <summary>
        /// position
        /// </summary>
        private Position Pos;

        /// <summary>
        /// working days
        /// </summary>
        private int intWorkingDays;

        /// <summary>
        /// input method
        /// </summary>
        public override void Input(object objDepartment, object objPosition)
        {
            Console.Write("\nName: ");
            Name = Console.ReadLine();
            this.Dept = objDepartment as Department;
            this.Pos = objPosition as Position;
            do
            {
                Console.Write("Working days: ");
            } while (!Int32.TryParse(Console.ReadLine(), out intWorkingDays)
                || intWorkingDays < 0);
            do
            {
                Console.Write("Salary ratio: ");
            } while (!float.TryParse(Console.ReadLine(), out fltSalaryRatio)
                || fltSalaryRatio < 0.0f || fltSalaryRatio > 100.0f);

            CalculateSalary();
        }

        /// <summary>
        /// output method
        /// </summary>
        public override void Output()
        {
            Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}"
                , Name, Dept.DepartmentName, Pos.PositionName, Pos.Allowance, intWorkingDays, fltSalaryRatio, fltSalary);
        }

        /// <summary>
        /// calculate salary
        /// </summary>
        protected override void CalculateSalary()
        {
            fltSalary = fltSalaryRatio*730 + Pos.Allowance + intWorkingDays*30;
        }
    }
}
