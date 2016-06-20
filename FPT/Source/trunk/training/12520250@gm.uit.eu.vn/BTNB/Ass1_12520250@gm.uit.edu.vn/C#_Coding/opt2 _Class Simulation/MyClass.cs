using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1_opt2
{
    class MyClass
    {
        private string _className; // class's name
        private List<Student> _listStudent; //  list student in class

        public MyClass(string className)
        {
            _listStudent = new List<Student>();
            _className = className;
        }

        /* Add a student to class
         * Input: Student
         * Output: bool - true: if insert success else throw an exception
         */
        public bool AddStudent(Student student)
        {
            _listStudent.Add(student);
            return true;
        }

        /* Get a student in class by index
         * Input: int - index
         * Output: Student - if index is corectly, else throw an exception
         */
        public Student GetStudent(int index)
        {
            if (index > -1 && index < _listStudent.Count)
                return _listStudent[index];
            throw new Exception("Index is incorectly. Now, Class have " + _listStudent.Count 
                + " student -> Index must be from 0 to " + (_listStudent.Count - 1));
        }

        /* Get a student in class by id
         * Input: string - id
         * Output: Student - if id is corectly, else throw an exception
         */
        public Student GetStudent(string id)
        {
            for (int i = 0; i < _listStudent.Count; i++)
            {
                if (_listStudent[i].Id == id.Trim())
                    return _listStudent[i];
            }
            throw new Exception("Student's ID is incorectly.");
        }

        /* Get sum student in class
         * Input: 
         * Output: int
         */
        public int SumStudent()
        {
            return _listStudent.Count;
        }

        /* Show all student in class
         * Input: 
         * Output: string
         */
        public string ShowListStudent()
        {
            // creat header
            string result = "List student's information in class "+_className;
            result += "\r\n";
            string header = string.Format("{0,-10}\t{1,-25}\t{2,-12}\t{3,-5}\t{4,-5}\t{5,-5}\t{6,-5}\t{7,-5}\t{8,-5}\t{9,-11}",
                "ID","Full Name","Birth Day","RA","SD","CP",
                "CNUT","FSMT","AVG","Grading");
            result += header+"\r\n";

            // add a student's information as line
            foreach (Student student in _listStudent)
            {
                result += student.ShowStudent();
                result += "\r\n";
            }
            return result;
        }
    }
}
