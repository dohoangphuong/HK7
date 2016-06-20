using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class StaffManagement
    {
        /// <summary>
        /// list of departments
        /// </summary>
        private List<Department> Departments;

        /// <summary>
        /// list of faculties
        /// </summary>
        private List<Faculty> Faculties;

        /// <summary>
        /// list of positions
        /// </summary>
        private List<Position> Positions;

        /// <summary>
        /// list of degrees
        /// </summary>
        private List<Degree> Degrees;

        /// <summary>
        /// list of staff
        /// </summary>
        private List<Staff> StaffCollection;
        
        /// <summary>
        /// the constructor class
        /// </summary>
        public StaffManagement()
        {
            Departments = new List<Department>();
            Faculties = new List<Faculty>();
            Positions = new List<Position>();
            Degrees = new List<Degree>();
            StaffCollection = new List<Staff>();
        }

        /// <summary>
        /// create data
        /// </summary>
        private void CreateDepartments()
        {
            Departments.Add(new Department(0, "Department 1"));
            Departments.Add(new Department(1, "Department 2"));
            Departments.Add(new Department(2, "Department 3"));
            Departments.Add(new Department(3, "Department 4"));
            Departments.Add(new Department(4, "Department 5"));
            Departments.Add(new Department(5, "Department 6"));
            Departments.Add(new Department(6, "Department 7"));
            Departments.Add(new Department(7, "Department 8"));
            Departments.Add(new Department(8, "Department 9"));
            Departments.Add(new Department(9, "Department 10"));
        }
        private void CreateFaculties()
        {
            Faculties.Add(new Faculty(0, "Software Engineering"));
            Faculties.Add(new Faculty(1, "Information System"));
            Faculties.Add(new Faculty(2, "Network and Telecommunication"));
            Faculties.Add(new Faculty(3, "Computer Engineering"));
            Faculties.Add(new Faculty(4, "Computer Science"));
            Faculties.Add(new Faculty(5, "Maths"));
            Faculties.Add(new Faculty(6, "English"));
            Faculties.Add(new Faculty(7, "Science and Engineering"));
        }
        private void CreatePositions()
        {
            Positions.Add(new Position(0, "Manager", 2000));
            Positions.Add(new Position(1, "Deputy Manager", 1000));
            Positions.Add(new Position(2, "Employee", 500));
        }
        private void CreateDegrees()
        {
            Degrees.Add(new Degree(0, "Bachelor", 300));
            Degrees.Add(new Degree(1, "Master", 500));
            Degrees.Add(new Degree(2, "PhD", 1000));
        }
        private void CreateData()
        {
            CreateDepartments();
            CreateFaculties();
            CreatePositions();
            CreateDegrees();
        }

        /// <summary>
        /// select faculty, department, degree, position
        /// </summary>
        /// <returns></returns>
        private int SelectFaculty()
        {
            Console.WriteLine("\nLIST OF FACUTIES");
            for (int i = 0; i < Faculties.Count; i++)
                Console.WriteLine("{0}\t{1}", i, Faculties[i].FacultyName);

            int select = 0;
            do
            {
                Console.Write("Please select the faculty: ");
            }while (!Int32.TryParse(Console.ReadLine(), out select) || select < 0 || select >= Faculties.Count);

            return select;
        }
        private int SelectDepartment()
        {
            Console.WriteLine("\nLIST OF DEPARMENTS");
            for (int i = 0; i < Departments.Count; i++)
                Console.WriteLine("{0}\t{1}", i, Departments[i].DepartmentName);

            int select = 0;
            do
            {
                Console.Write("Please select the department: ");
            }while (!Int32.TryParse(Console.ReadLine(), out select) || select < 0 || select >= Departments.Count);

            return select;
        }
        private int SelectDegree()
        {
            Console.WriteLine("\nLIST OF DEGREES");
            for (int i = 0; i < Degrees.Count; i++)
                Console.WriteLine("{0}\t{1}", i, Degrees[i].DegreeName);

            int select = 0;
            do
            {
                Console.Write("Please select the degree: ");
            }while (!Int32.TryParse(Console.ReadLine(), out select) || select < 0 || select >= Degrees.Count);

            return select;
        }
        private int SelectPosition()
        {
            Console.WriteLine("\nLIST OF POSITIONS");
            for (int i = 0; i < Positions.Count; i++)
                Console.WriteLine("{0}\t{1}", i, Positions[i].PositionName);

            int select = 0;
            do
            {
                Console.Write("Please select the position: ");
            }while (!Int32.TryParse(Console.ReadLine(), out select) || select < 0 || select >= Positions.Count);

            return select;
        }

        /// <summary>
        /// input staff
        /// </summary>
        private void InputStaff()
        {
            int select = -1;
            do
            {
                Console.WriteLine("\nPlease select the staff type: \n1. Lecturer, \t2.Clerical Staff");
                if (Int32.TryParse(Console.ReadLine(), out select))
                {
                    if (select != 1 && select != 2)
                        select = -1;
                    else
                    {
                        Staff staff;
                        switch (select)
                        { 
                            case 1:
                                staff = new Lecturer();
                                int fac = SelectFaculty();
                                int deg = SelectDegree();
                                staff.Input((object)Faculties[fac], (object)Degrees[deg]);
                                StaffCollection.Add(staff);
                                break;
                            case 2:
                                staff = new ClericalStaff();
                                int dept = SelectDepartment();
                                int pos = SelectPosition();
                                staff.Input((object)Departments[dept], (object)Positions[pos]);
                                StaffCollection.Add(staff);
                                break;
                        }
                        Console.WriteLine("Input success");
                        Console.ReadLine();
                    }
                }
            }while(select == -1);
        }

        /// <summary>
        /// sort staff
        /// </summary>
        private void SortStaff()
        {
            if (StaffCollection.Count > 0)
            {
                try
                {
                    StaffCollection.Sort();
                    Console.WriteLine("Sort success");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Sort failed");
                }
            }
            else
                Console.WriteLine("There is no staff in the collection");
            Console.ReadLine();
        }

        private void SearchStaff()
        {
            if (StaffCollection.Count > 0)
            {
                int select = -1;
                do
                {
                    for(int i = 0; i < Faculties.Count; i++)
                        Console.WriteLine("{0}\t{1}", i, Faculties[i].FacultyName);
                    for (int i = 0; i < Departments.Count; i++)
                        Console.WriteLine("{0}\t{1}", i+Faculties.Count, Departments[i].DepartmentName);
                    Console.Write("Please select falcuty or department: ");
                }while(!Int32.TryParse(Console.ReadLine(), out select)
                    || select < 0 || select > Faculties.Count + Departments.Count);

                Console.Write("Enter the staff's name: ");
                string name = Console.ReadLine().Trim();
                IEnumerable<Staff> results = null;
                if (select >= 0 && select < Faculties.Count)
                    results = StaffCollection.Where(e => (e.GetType() == typeof(Lecturer)) && e.Name.Contains(name));
                else if (select >= Faculties.Count && select < Faculties.Count + Departments.Count)
                    results = StaffCollection.Where(e => (e.GetType() == typeof(ClericalStaff)) && e.Name.Contains(name));

                if (results == null)
                    Console.WriteLine("\nThere is no staff valid");
                else
                {
                    Console.WriteLine("\nRESULTS:");
                    Console.WriteLine("Name  DeptOrFaculty  PosOrDegree  Allowance  DaysOrPeriods  Ratio  Salary");
                    foreach (var staff in results)
                        staff.Output();
                }
            }
            else
                Console.WriteLine("There is no staff in the collection");
            Console.ReadLine();
        }

        /// <summary>
        /// output staff
        /// </summary>
        private void OutputStaff()
        {
            if (StaffCollection.Count > 0)
            {
                Console.WriteLine("Name  DeptOrFaculty  PosOrDegree  Allowance  DaysOrPeriods  Ratio  Salary");
                foreach (var staff in StaffCollection)
                    staff.Output();
            }
            else
                Console.WriteLine("There is no staff in the collection");
            Console.ReadLine();
        }

        /// <summary>
        /// display menu
        /// </summary>
        private void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Input Staff");
            Console.WriteLine("2. Search Staff");
            Console.WriteLine("3. Sort Staff");
            Console.WriteLine("4. Output Staff");
            Console.WriteLine("0. Exit");
        }

        /// <summary>
        /// run application
        /// </summary>
        public void Run()
        {
            CreateData();
            int func = 0;
            do
            {
                DisplayMenu();
                do
                {
                    Console.Write("You select: ");
                }while (!Int32.TryParse(Console.ReadLine(), out func) || func < 0 || func > 4);

                switch (func)
                { 
                    case 1:
                        InputStaff();
                        break;
                    case 2:
                        SearchStaff();
                        break;
                    case 3:
                        SortStaff();
                        break;
                    case 4:
                        OutputStaff();
                        break;
                    default:
                        break;
                }
            } while (func != 0);
        }
    }
}
