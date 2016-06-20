using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS2.Models
{
    public class CourseStudentsModel
    {
        public virtual Course Course { get; set; }
        public virtual IList<Student> Students { get; set; }
        public bool[] CheckStudents { get; set; }

        public CourseStudentsModel(Course course, IList<Student> students)
        {
            Course = course;
            Students = students;
            CheckStudents = new bool[students.Count];
        }

        public CourseStudentsModel()
        { }
    }
}