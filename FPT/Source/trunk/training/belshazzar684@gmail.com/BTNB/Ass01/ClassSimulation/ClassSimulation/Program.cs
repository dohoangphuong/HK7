using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassSimulation
{
    class Program
    {
        #region Global variable
        static int maxStudentNumber = 25;       //Number of student
        static Random rd = new Random();        //Use for random
        static List<int> remainLastNameIndex;   //Store remaining index for random lastname      
        static List<int> remainMiddleNameIndex; //Store remaining index for random lastname 
        static List<int> remainFirstNameIndex;  //Store remaining index for random lastname 

        static string[] LastNames = {"Van", "Anh", "Dung", "Toan", "Vu", "Hieu", "Nhi", "Chi", "Thao", "Tram",
                          "Vuong", "Hung", "Phuong", "Nhat", "Nhan", "Lam", "Tai", "Tung", "Sao", "Thinh", 
                          "Thi", "Trang", "Nguyet", "Hue", "Linh", "Dang", "Luong", "Ngoc", "Thuong", "Khanh",
                          "Trung", "Nha", "Truong", "Thu", "Hanh", "Duyen", "Tien", "Luan", "An", "Huy",
                          "Van", "Minh", "Quan", "Tuan", "Hien", "Lan", "Hoa", "Chau", "Tam", "Yen"};

        static string[] MiddleNames = {"Thanh", "Thi", "Dang", "Minh", "Thai", "Toan", "Quang", "Doan", "Cat", "Song",
                               "Da", "Bach", "Moc", "Diem", "Thu", "Tai", "Khoi", "Thien", "Truong", "Huu", 
                               "Trung", "Hoang", "Phuong", "Son", "An", "Chien", "Kien", "Ky", "Lan", "Van"};

        static string[] FirstNames = {"Le", "Nguyen", "Ho", "Pham", "Ly", "Tran", "Phan", "Ngo", "Dang", "Bui",
                               "Duong", "Vu", "Do", "Dinh", "Hoang"};
        #endregion

        #region Function

        /// <summary> 
        /// Check current date with all dates before it
        /// </summary>
        /// <returns> 
        /// True is current date unique, else false
        /// </returns>
        public static bool IsDateUnique(DateTime[] checkDate, int current)
        {
            try
            {
                if (current == 0)
                {
                    return true;
                }

                for (int i = 0; i < current; i++)
                {
                    if (checkDate[current].Date.Equals(checkDate[i].Date))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary> 
        /// Shuffle a array
        /// </summary>
        /// <returns> 
        /// Shuffle the array randomly
        /// </returns>
        public static void ShuffleScore(double[] array)
        {
            int random;
            for (int i = 0; i < array.Length; i++)
            {
                random = rd.Next(array.Length);
                double temp = array[i];
                array[i] = array[random];
                array[random] = temp;
            }
        }

        /// <summary> 
        /// Generate a random name array
        /// </summary>
        /// <returns> 
        /// Array of 25 unique random names. 
        /// </returns>
        public static List<string> GenerateNames()
        {
            List<string> listStudentNames = new List<string>();
            string tempName;
            for (int i = 0; i < maxStudentNumber; i++)
            {
                do
                {
                    tempName = FirstNames[rd.Next(FirstNames.Length)] + " " +
                            MiddleNames[rd.Next(MiddleNames.Length)] + " " + LastNames[rd.Next(LastNames.Length)];
                }
                while (listStudentNames.Contains(tempName));       //If current name is not unique then recreate the name
                listStudentNames.Add(tempName);
            }
            return listStudentNames;
        }

        /// <summary> 
        /// Generate a random id array
        /// </summary>
        /// <returns> 
        /// Array of 25 unique random id. 
        /// </returns>
        public static List<string> GenerateID()
        {
            List<string> listStudentID = new List<string>();
            string tempID;
            for (int i = 0; i < maxStudentNumber; i++)
            {
                do
                {
                    tempID = "HV" + rd.Next(9999999);
                }
                while (listStudentID.Contains(tempID));       //If current name is not unique then recreate the name
                listStudentID.Add(tempID);
            }
            return listStudentID;
        }

        /// <summary> 
        /// Generate a random birthday array
        /// </summary>
        /// <returns> 
        /// Array of 25 unique random birthday list from 1/2/1991 -> 31/12/1991 
        /// </returns>
        public static DateTime[] GenerateBirthday()
        {
            DateTime[] listStudentBirthDays = new DateTime[maxStudentNumber];
            DateTime start = new DateTime(1991, 1, 1);
            int range = 364;            //364 day         
            for (int i = 0; i < maxStudentNumber; i++)
            {
                do
                {
                    listStudentBirthDays[i] = start.AddDays(rd.Next(range));
                }
                while (!IsDateUnique(listStudentBirthDays, i));       //If current name is not unique then recreate the name
            }
            return listStudentBirthDays;
        }

        /// <summary> 
        /// Generate a random score array
        /// </summary>
        /// <returns> 
        /// Array of 25 random score with have 3 from 8 to 10, 13 from 5 to 7, 6 from 3 to 4, 2 from 1 to 2, 1 0
        /// </returns>
        public static double[] GenerateScore()
        {
            double[] studentScore = new double[maxStudentNumber];
            for (int i = 0; i < maxStudentNumber; i++)
            {
                //3 student from 8 to 10
                if (i < 3)
                {
                    studentScore[i] = Math.Round(rd.NextDouble() * (10 - 8) + 8, 1);
                }
                //13 student from 5 to 7
                if(i >= 3 && i < (13 + 3))
                {
                    studentScore[i] = Math.Round(rd.NextDouble() * (8 - 5) + 5, 1);
                }
                //6 student from 3 to 4
                if (i >= 16 && i < (16 + 6))
                {
                    studentScore[i] = Math.Round(rd.NextDouble() * (5 - 3) + 3, 1);
                }
                //2 student from 1 to 2
                if (i >= 22 && i < (24 + 2))
                {
                    studentScore[i] = Math.Round(rd.NextDouble() * (3 - 1) + 1, 1);
                }
                if (i == 24)
                {
                    studentScore[i] = 0;
                }
            }
            //SHuffle the score randomly
            ShuffleScore(studentScore);
            return studentScore;
        }

        /// <summary> 
        /// Generate a random student array
        /// </summary>
        /// <returns> 
        /// Array of 25 unique student 
        /// </returns>
        public static Student[] GenerateStudent()
        {
            //Generate random values
            Student[] students = new Student[maxStudentNumber];
            List<string> studentNames = GenerateNames();
            List<string> studentIDs = GenerateID();
            DateTime[] studentBirthDays = GenerateBirthday();
            double[] csProgramingScores = GenerateScore();
            double[] requirementAnalyzeScores = GenerateScore();
            double[] softwareDesignScores = GenerateScore();
            double[] codeAndUTScores = GenerateScore();
            double[] fSoftManagementToolScores = GenerateScore();

            //Create student array
            for (int i = 0; i < maxStudentNumber; i++)
            {
                students[i] = new Student(studentNames[i], studentIDs[i], studentBirthDays[i], csProgramingScores[i], 
                                requirementAnalyzeScores[i], softwareDesignScores[i], codeAndUTScores[i], fSoftManagementToolScores[i]);
            }
            return students;
        }

        /// <summary> 
        /// Display the all student in list infomation in the console windows
        /// </summary>
        public static void DisplayStudent(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                students[i].PrintInfomation();
            }
        }
        #endregion

        static void Main(string[] args)
        {
            Student[] students = GenerateStudent();
            DisplayStudent(students);
            Console.ReadLine();
        }
    }
}
