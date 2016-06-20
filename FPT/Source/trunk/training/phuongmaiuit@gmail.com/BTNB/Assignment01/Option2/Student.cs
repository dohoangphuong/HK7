using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Option2
{
    
   
    public class Student
    {
        private string fullName;
        private string lastName;
        private string midleName;
        private string firstName;
        private DateTime birthDay;
        private string studentID;
        private double score;
        //private int scoreRA,scoreSD, scoreCSharp,scoreCNU,scoreFMT ;
        public Student()
        {
            fullName = null;
            lastName = null;
            midleName = null;
            firstName = null;
            birthDay = new DateTime(01 / 02 / 1991);
            studentID = null;
            score = 0;
        }
        Random rd = new Random();

        string []LastName = new string [50]{   "Mai","Hai","Phuong","Nghia","Duong",
                                "Hang","Hoang","Hong","Hung","Huong",
                                "Dang","Danh","Duyen","Dien","Diem",
                                "Nhat","Nhan","Nga","Nguyen","Minh",
                                "Ha","Dung","Xuyen","Tuan","Anh",
                                "Hien","Huyen","Phong","Trong","Thang",
                                "Dinh","Thuy","Thanh","Nghi","Trinh",
                                "Tri","Trang","Linh","Long","Lam",
                                "Lien","Lieu","Ly","Kiet","Thuong",
                                "Nhung","Trung","Ha","Yen","Tho"  };

        string [] MidleName = new string[30]{ "Van","Thi","Duong","Dinh","Ha",
                                "Hoang","Minh","Khoa","Dang","Hai",
                                "Phuong","Bo","Thuong","Diec","Hong",
                                "Trung","Anh","Tuan","Thuy","Linh",
                                "Vy","Yen","Lieu","Tu","Thien",
                                "Xuan","Hoai","Kien","Huy","Khoi" };
        string [] FirstName = new string[15]{   "Tran","Nguyen","Pham","Ha","Le",
                                  "Do","Dang","Phan","Ly","Dinh",
                                  "Ho","Hoang","Cao","Bui","Du"};

        public String getLastName(int index)
        {           
            index = rd.Next(LastName.Length);
            lastName = LastName[index];
            return lastName;
        }

        public String getMidleName(int index)
        {           
            index = rd.Next(MidleName.Length);
            midleName = MidleName[index];
            return midleName;
        }

        public String getFirstName(int index)
        {         
            index = rd.Next(FirstName.Length);
            firstName = FirstName[index];   
            return firstName;
        }

        public String getName(int index)
        {
            
                fullName = getFirstName(index) + "\t" + getMidleName(index) + "\t" + getLastName(index);
            
            return fullName;
        }
       
        public DateTime getBirthday()
        {
            birthDay = DateTime.Now;

            

            return birthDay;
        }
        public void getStudentID(int index)
        {
           int[] strArr = new int[7];
           for(index =0;index<7;index++)
           {
               strArr[index] = rd.Next(10);
               Console.Write(strArr[index]);
           }
        }


       
        
    }

    
    
}
