using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass1_opt2
{
    struct GradeSubject
    {
        public float grade;
        public int studentIndex;
    };
    class Program
    {
        /* Get a student's full name random
         * Input: Random, List<string> - list first name, List<string> list middle name, List<string> list last name
         * Output: string - full name
         */
        public static string SetListStudentFullName(Random rd,List<string> firstName, List<string> middleName,
            List<string> lastName)
        {
            string fullName = "";
            string stFirstName = firstName[(rd.Next(0, firstName.Count - 1))];
            string stMiddleName = middleName[(rd.Next(0, middleName.Count - 1))];
            int indexLastName = (rd.Next(0, lastName.Count - 1));
            string stLastName = lastName[indexLastName];
            lastName.RemoveAt(indexLastName);
            fullName = stFirstName.Trim() + " " + stMiddleName.Trim() + " " + stLastName.Trim();
            return fullName;
        }

        /* Get a student's birth day random
         * Input: Random
         * Output: DateTime - birth day
         */
        public static DateTime SetListStudentBirthDay(Random rnd)
        {
            DateTime min = new DateTime(1991, 2, 1);
            DateTime max = new DateTime(1991, 12, 31);
            var range = max - min;
            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));
            return (min + randTimeSpan);
        }

        /* Create a new class with information random
         * Input: int - number of student, List<string> - list first name, List<string> list middle name, 
         *  List<string> list last name, string - class name
         * Output: MyClass 
         */
        public static MyClass CreateClassToClass(int numOfStudent, List<string> firstName, List<string> middleName,
            List<string> lastName, string className)
        {
            Random random = new Random();
            if (numOfStudent > lastName.Count)
                numOfStudent = lastName.Count; // update number of student with max lastname list
            MyClass myClass = new MyClass(className);
            Student[] tmpListStudent = new Student[numOfStudent];

            // create Id list
            List<int> indexId = new List<int>();
            for (int i = 0; i < numOfStudent; i++)
            {
                indexId.Add(i);
            }

            // update id, full name, birth day for each student
            for (int i = 0; i < numOfStudent; i++)
            {
                int rndId = random.Next(0,indexId.Count-1);
                tmpListStudent[i] = new Student();
                tmpListStudent[i].Id = "HV" + String.Format("{0:0000000}", (int)(indexId[rndId]));
                indexId.RemoveAt(rndId);
                tmpListStudent[i].FullName = (SetListStudentFullName(random,firstName, middleName, lastName));
                tmpListStudent[i].BirthDay = SetListStudentBirthDay(random);
            }
            #region update grade and student each subject

            for (int i = 0; i < 5; i++) // 5 subject
            {
                // create list student haven't grade
                List<int> indexGrade = new List<int>();
                GradeSubject[] tmpListGrade = new GradeSubject[numOfStudent];
                for (int j = 0; j < numOfStudent; j++)
                {
                    indexGrade.Add(j);
                }

                #region select grade for each student

                int st = 0; // student
                int k = 0;
                while(k < 3 && indexGrade.Count > 0) // 3 student have grade: 8 -10
                {
                    // select student 
                    int rndIndexStudent = random.Next(0, indexGrade.Count-1);
                    int indexStudent = indexGrade[rndIndexStudent];
                    indexGrade.RemoveAt(rndIndexStudent);

                    // select grade
                    float rndGrade = (float)Math.Round(random.NextDouble() * (10.0f - 8.0f) + 8.0f,1);
                    tmpListGrade[st].studentIndex = indexStudent;
                    tmpListGrade[st].grade = rndGrade;
                    st++;
                    k++;
                }
                k = 0;
                while (k < 13 && indexGrade.Count > 0) // 13 student have grade: 5 - 7
                {
                    // select student 
                    int rndIndexStudent = random.Next(0, indexGrade.Count - 1);
                    int indexStudent = indexGrade[rndIndexStudent];
                    indexGrade.RemoveAt(rndIndexStudent);

                    // select grade
                    float rndGrade = (float)Math.Round(random.NextDouble() * (7.0f - 5.0f) + 5.0f, 1);
                    tmpListGrade[st].studentIndex = indexStudent;
                    tmpListGrade[st].grade = rndGrade;
                    st++;
                    k++;
                }
                k = 0;
                while (k < 6 && indexGrade.Count > 0) // 6 student have grade: 3 - 4
                {
                    // select student 
                    int rndIndexStudent = random.Next(0, indexGrade.Count - 1);
                    int indexStudent = indexGrade[rndIndexStudent];
                    indexGrade.RemoveAt(rndIndexStudent);

                    // select grade
                    float rndGrade = (float)Math.Round(random.NextDouble() * (4.0f - 3.0f) + 3.0f, 1);
                    tmpListGrade[st].studentIndex = indexStudent;
                    tmpListGrade[st].grade = rndGrade;
                    st++;
                    k++;
                }
                k = 0;
                while (k < 2 && indexGrade.Count > 0) // 2 student have grade: 1 - 2
                {
                    // select student 
                    int rndIndexStudent = random.Next(0, indexGrade.Count - 1);
                    int indexStudent = indexGrade[rndIndexStudent];
                    indexGrade.RemoveAt(rndIndexStudent);

                    // select grade
                    float rndGrade = (float)Math.Round(random.NextDouble() * (2.0f - 1.0f) + 1.0f, 1);
                    tmpListGrade[st].studentIndex = indexStudent;
                    tmpListGrade[st].grade = rndGrade;
                    st++;
                    k++;
                }
                while (indexGrade.Count > 0)
                {
                    // select student 
                    int rndIndexStudent = random.Next(0, indexGrade.Count - 1);
                    int indexStudent = indexGrade[rndIndexStudent];
                    indexGrade.RemoveAt(rndIndexStudent);

                    // select grade
                    float rndGrade = 0.0f;
                    tmpListGrade[st].studentIndex = indexStudent;
                    tmpListGrade[st].grade = rndGrade;
                    st++;
                }

                #endregion

                #region update grade for subject

                if (i == 0) // Code and Unit Test
                {
                    for (k = 0; k < tmpListGrade.Length; k++)
                    {
                        tmpListStudent[tmpListGrade[k].studentIndex].GradeCNUT = tmpListGrade[k].grade;
                    }
                }
                else if (i == 1) // C# Programming
                {
                    for (k = 0; k < tmpListGrade.Length; k++)
                    {
                        tmpListStudent[tmpListGrade[k].studentIndex].GradeCSP = tmpListGrade[k].grade;
                    }
                }
                else if (i == 2) // FSoft Management Tool
                {
                    for (k = 0; k < tmpListGrade.Length; k++)
                    {
                        tmpListStudent[tmpListGrade[k].studentIndex].GradeFSMT = tmpListGrade[k].grade;
                    }
                }
                else if (i == 3) // Requirement analyze
                {
                    for (k = 0; k < tmpListGrade.Length; k++)
                    {
                        tmpListStudent[tmpListGrade[k].studentIndex].GradeRA = tmpListGrade[k].grade;
                    }
                }
                else if (i == 4)
                {
                    for (k = 0; k < tmpListGrade.Length; k++) // Software design
                    {
                        tmpListStudent[tmpListGrade[k].studentIndex].GradeSD = tmpListGrade[k].grade;
                    }
                }

                #endregion
            }
            #endregion

            // add student to class
            for (int i = 0; i < tmpListStudent.Length; i++)
            {
                myClass.AddStudent(tmpListStudent[i]);
            }
            return myClass;
        }

        static void Main(string[] args)
        {
            try
            {
                Console.SetWindowSize(140, 58);
                List<string> firstName = new List<string>(){ "Phung", "Nguyen","Tran","Le","Pham","Hoang","Do",
                "Phan","Dinh","Ngo","Ly","Ma","Cao","Lai","Phi"};
                List<string> middleName = new List<string>(){"Duy","Van","Thi","Chi","Ai","Van","Cam","Phuong","Trung","Phat",
                "Ngoc","Nhuan","Khac","Cong","Thanh","Duong","Long","Thuc","Kim","Thao",
                "Hong","Mai","Phuc","Dieu","Bich","Thach","Bao","Tuan","Kiet","The"};
                List<string> lastName = new List<string>(){"Luong","Loc","Phuc","Tho","Nhan","Nghia","Le","Tri","Tin","Tam",
                "Hong","Dao","Mai","Cuc","Hue","Lan","Sen","Phuong","Do Quyen","Moc Lan",
                "Ty","Suu","Dan","Mao","Ti","Ngo","Thin","Mui","Than","Dau","Tuat","Hoi",
                "Minh","Thanh","Dieu","Phu","Giap","Dong","Loan","Khang",
                "Trung","Quyen","Hoan","Linh","Loi","Canh","Anh","Bi","Dung","Dai"};
                MyClass myClass = CreateClassToClass(25, firstName, middleName, lastName, "GST_NET_2015");
                Console.WriteLine(myClass.ShowListStudent());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to continue exit...");
            Console.ReadKey();
        
        }
    }
}
