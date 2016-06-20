using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1_opt2
{
    class Student
    {
        private string _Id; // Id

        public string Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        private string _fullName; //  full name

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        private DateTime _birthDay;

        public DateTime BirthDay // birth day
        {
            get { return _birthDay; }
            set { _birthDay = value; }
        }
        private float _gradeRA; // Requirement analyze

        public float GradeRA
        {
            get { return _gradeRA; }
            set { _gradeRA = value; }
        }
        private float _gradeSD; // Software design

        public float GradeSD
        {
            get { return _gradeSD; }
            set { _gradeSD = value; }
        }
        private float _gradeCSP; // C# Programming

        public float GradeCSP
        {
            get { return _gradeCSP; }
            set { _gradeCSP = value; }
        }
        private float _gradeCNUT; // Code and Unit Test

        public float GradeCNUT
        {
            get { return _gradeCNUT; }
            set { _gradeCNUT = value; }
        }
        private float _gradeFSMT; // FSoft Management Tool

        public float GradeFSMT
        {
            get { return _gradeFSMT; }
            set { _gradeFSMT = value; }
        }

        public Student()
        {
            _gradeCNUT = 0.0f;
            _gradeCSP = 0.0f;
            _gradeFSMT = 0.0f;
            _gradeRA = 0.0f;
            _gradeSD = 0.0f;
            _Id = "";
            _fullName = "";
            _birthDay = new DateTime(1900,1,1); // set default value is unsuittable 
        }

        /* Calculator average grade of a student
         * Input: float
         * Output: 
         */
        public float AvgGrade()
        {
            return ((_gradeCNUT + _gradeCSP + _gradeFSMT + _gradeRA + _gradeSD) / 5);
        }

        /* Show information of a student as a string
         * Input: 
         * Output: string
         */
        public string ShowStudent()
        {
            try
            {
                // check id
                if (_Id == "" || _Id == null)
                    throw new Exception("Student's ID is incorectly!");
                // check full name
                if (_fullName == "" || _fullName == null)
                    throw new Exception("Student's full name is incorectly!");
                // check birth day
                if (_birthDay.Year < 1991)
                    throw new Exception("Student's birth day is incorectly!");

                // calculator average grade with format: 0.0f
                float avgGrade = (float)Math.Round(AvgGrade(),1);

                // get grading: Kem, Yeu, Trung Binh, Kha, Gioi
                string grading = "";
                if (_gradeCNUT <= 3.0f || _gradeCSP <= 3.0f|| _gradeFSMT <= 3.0f || _gradeRA <= 3.0f || _gradeSD <= 3.0f || avgGrade <= 3.0f)
                    grading = "Kem";
                else if (avgGrade <= 4.9f && avgGrade >= 3.1f)
                    grading = "Yeu";
                else if (avgGrade <= 6.4f && avgGrade >= 5.0f)
                    grading = "Trung Binh";
                else if (avgGrade <= 7.9f && avgGrade >= 6.5f)
                    grading = "Kha";
                else if (avgGrade >= 8.0f)
                    grading = "Gioi";

                // set format result as a string
                string result = string.Format("{0,-10}\t{1,-25}\t{2,-12}\t{3,-5}\t{4,-5}\t{5,-5}\t{6,-5}\t{7,-5}\t{8,-5}\t{9,-11}",
                     _Id.Trim(), _fullName.Trim(), _birthDay.ToString("dd/MM/yyy"), _gradeRA.ToString("0.0"), _gradeSD.ToString("0.0"),
                     _gradeCSP.ToString("0.0"), _gradeCNUT.ToString("0.0"), _gradeFSMT.ToString("0.0"),
                     avgGrade.ToString("0.0"), grading);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
