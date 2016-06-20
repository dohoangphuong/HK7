using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3_opt1
{
    class Program
    {

        /* Create input menu
        * Input: 
        * Output: 
        */
        private static void MenuInput(List<Personnel> allPersonnal)
        {
            bool exit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\tNHAP THONG TIN CAN BO NHAN VIEN");
                Console.WriteLine("1. Them Giang Vien.");
                Console.WriteLine("2. Them Nhan Vien.");
                Console.WriteLine("0. Thoat.");
                Console.Write("Chon: ");
                int select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1: // clear current bee list and create new it
                        Console.Clear();
                        try
                        {
                            int coefficientSalary = 0;
                            Teacher teacher = new Teacher();
                            Console.Write("\n-----------------Nhap Thong Tin Giang Vien-----------------");
                            Console.Write("\n\tHo Ten: ");
                            teacher.FullName = Console.ReadLine().Trim();
                            Console.Write("\n-----------------------------------------------------------");
                            Console.Write("\n\tHe So Luong: ");
                            while (!int.TryParse(Console.ReadLine(), out coefficientSalary))
                            {
                                Console.Write("\n\tNhap sai He so luong. Vui long nhap lai.");
                                Console.Write("\n\tHe So Luong: ");
                            }
                            teacher.CoefficientSalary = coefficientSalary;
                            Console.Write("\n-----------------------------------------------------------");
                            Console.Write("\n\tKhoa: ");
                            teacher.Faculty = Console.ReadLine().Trim();
                            Console.Write("\n-----------------------------------------------------------");
                            Console.Write("\n\tTrinh Do Hoc Van: ");
                            Console.Write("\n\t\tT1. Cu Nhan.");
                            Console.Write("\n\t\tT2. Thac Si.");
                            Console.Write("\n\t\tT3. Tien Si.");
                            Console.Write("\n\t\tNhan 1 de chon T1, 2 de chon T2, nhan bat ky de chon T3:");
                            int selectLiteracy;
                            if (int.TryParse(Console.ReadLine(), out selectLiteracy))
                            {
                                if (selectLiteracy == 1)
                                    teacher.Literacy1 = Literacy.Bachelor;
                                else if (selectLiteracy == 2)
                                    teacher.Literacy1 = Literacy.Master;
                                else
                                    teacher.Literacy1 = Literacy.Doctor;
                            }
                            else
                                teacher.Literacy1 = Literacy.Doctor;
                            Console.Write("\n-----------------------------------------------------------");
                            int lesson;
                            Console.Write("\n\tSo Tiet Day Trong Thang: ");
                            while (!int.TryParse(Console.ReadLine(), out lesson))
                            {
                                Console.Write("\n\tNhap sai So tiet day tong thang. Vui long nhap lai.");
                                Console.Write("\n\tSo Tiet Day Trong Thang: ");
                            }
                            teacher.LessonPerMonth = lesson;
                            teacher.SetSalary();
                            allPersonnal.Add(teacher);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2: // Damage all bee in bee list with percentage of health as random 0 - 80
                        Console.Clear();
                        try
                        {
                            int coefficientSalary = 0;
                            Staff staff = new Staff();
                            Console.Write("\n-------------------Nhap Thong Tin Nhan Vien----------------");
                            Console.Write("\n\tHo Ten: ");
                            staff.FullName = Console.ReadLine().Trim();
                            Console.Write("\n-----------------------------------------------------------");
                            Console.Write("\n\tHe So Luong: ");
                            while (!int.TryParse(Console.ReadLine(), out coefficientSalary))
                            {
                                Console.Write("\n\tNhap sai He so luong. Vui long nhap lai.");
                                Console.Write("\n\tHe So Luong: ");
                            }
                            staff.CoefficientSalary = coefficientSalary;
                            Console.Write("\n-----------------------------------------------------------");
                            Console.Write("\n\tPhong Ban: ");
                            staff.Department = Console.ReadLine().Trim();
                            Console.Write("\n-----------------------------------------------------------");
                            Console.Write("\n\tChuc Vu: ");
                            Console.Write("\n\t\tC1. Nhan Vien.");
                            Console.Write("\n\t\tC2. Pho Phong.");
                            Console.Write("\n\t\tC3. Truong Phong.");
                            Console.Write("\n\t\tNhan 1 de chon C1, 2 de chon C2, nhan bat ky de chon C3:");
                            int selectLiteracy;
                            if (int.TryParse(Console.ReadLine(), out selectLiteracy))
                            {
                                if (selectLiteracy == 1)
                                    staff.Post = PostDepartment.EmployeeDepartment;
                                else if (selectLiteracy == 2)
                                    staff.Post = PostDepartment.DeputyDepartment;
                                else
                                    staff.Post = PostDepartment.ChiefDepartment;
                            }
                            else
                                staff.Post = PostDepartment.ChiefDepartment;
                            Console.Write("\n-----------------------------------------------------------");
                            int day;
                            Console.Write("\n\tSo Ngay Lam Trong Thang: ");
                            while (!int.TryParse(Console.ReadLine(), out day))
                            {
                                Console.Write("\n\tNhap sai So Ngay Lam Trong Thang. Vui long nhap lai.");
                                Console.Write("\n\tSo Ngay Lam Trong Thang: ");
                            }
                            staff.Workday = day;
                            staff.SetSalary();
                            allPersonnal.Add(staff);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 0: // exit
                        Console.Clear();
                        return;
                    default: // press key error
                        Console.Clear();
                        Console.WriteLine("Lua chon khong chinh xac. Nhan phim bat ky de quay lai.");
                        Console.ReadKey();
                        break;
                }
                // question exit app
                Console.Write("\r\n\tDe quay lai Menu nhap thong tin nhan phim 1, nhan phim bat ky khac 1 de thoat: ");
                int selectReturn = 0;
                if (!int.TryParse(Console.ReadLine(),out selectReturn) || selectReturn != 1)
                    exit = true;
            }
            while (!exit);

        }

        /* Create main menu
        * Input: 
        * Output: 
        */
        private static void Menu()
        {
            List<Personnel> allPersonnel = new List<Personnel>();
            bool exit = false;
            do
            {
                int select;
                Console.Clear();
                Console.WriteLine("\t\tMENU CHINH");
                Console.WriteLine("1. Nhap thong tin can bo nhan vien.");
                Console.WriteLine("2. Tim kiem thong tin nhan vien.");
                Console.WriteLine("3. In thong tin can bo nhan vien.");
                Console.WriteLine("0. Thoat.");
                Console.Write("Chon: ");
                if (!int.TryParse(Console.ReadLine(), out select))
                    select = -1;
                switch (select)
                {
                    case 1: 
                        Console.Clear();
                        try
                        {
                            MenuInput(allPersonnel);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2: 
                        Console.Clear();
                        try
                        {
                            string fullName = "";
                            string department = "";
                            Console.Write("\n-----------------Tim Kiem Nhan Vien-------------------------");
                            Console.Write("\nNhap thong tin Nhan vien can tim kiem:");
                            Console.Write("\n\tHo Ten: ");
                            fullName = Console.ReadLine().Trim();
                            Console.Write("\n------------------------------------------------------------");
                            Console.Write("\n\tPhong Ban: ");
                            department = Console.ReadLine().Trim();
                            Console.Write("\n------------------------------------------------------------");
                            Console.Clear();
                            Console.Write("\n------------------Tim Kiem Nhan Vien------------------------");
                            List<Personnel> resultList = new List<Personnel>();
                            for (int i = 0; i < allPersonnel.Count; i++)
                            {
                                if (allPersonnel[i].StaffSearch(fullName, department))
                                    resultList.Add(allPersonnel[i]);
                            }
                            Console.Write("\nBan da tim kiem Nhan vien voi Ten '" + fullName + "' thuoc Phong Ban '" + department + "'.");
                            Console.WriteLine("\n Ket qua: Tim duoc "+resultList.Count+" nhan vien thich hop:");
                            Console.WriteLine("\t{0,-3}\t{1,-30}\t{2,-20}\t{3,-15}\t{4,-8}\t{5,-8}\t{6,-20}\t{7,-20}", "Num",
                                "Ho Ten", "Phong Ban", "SoNgay", "HSLuong", "Phu Cap", "Chuc Vu", "Luong");
                            for (int i = 0; i < resultList.Count; i++)
                            {
                                Console.WriteLine("\t"+(i+1)+resultList[i].ShowInformation());
                            }
                            Console.Write("\n------------------------------------------------------------");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3: // show information of all bee in bee list
                        Console.Clear();
                        try
                        {
                            Console.Write("\n---------------Danh Sach Can Bo Nhan Vien--------------------");
                            Console.WriteLine("\n Danh sach co " + allPersonnel.Count + " can bo nhan vien:");
                            Console.WriteLine("\t{0,-3}\t{1,-30}\t{2,-20}\t{3,-15}\t{4,-8}\t{5,-8}\t{6,-20}\t{7,-20}", "Num",
                                "Ho Ten", "Khoa/Phong Ban", "SoTiet/SoNgay", "HSLuong", "Phu Cap", "Trinh Do/Chuc Vu", "Luong");
                            for (int i = 0; i < allPersonnel.Count; i++)
                            {
                                Console.WriteLine("\t" + (i + 1) + allPersonnel[i].ShowInformation());
                            }
                            Console.Write("\n------------------------------------------------------------");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 0: // exit
                        Console.Clear();
                        return;
                        break;
                    default: // press key error
                        Console.Clear();
                        Console.WriteLine("Lua chon khong chinh xac. Nhan phim bat ky de quay lai.");
                        Console.ReadKey();
                        break;
                }
                // question exit app
                Console.Write("\r\n\tDe quay lai Menu Chinh nhan phim 1, nhan phim bat ky khac 1 de thoat: ");
                int selectReturn = 0;
                if (!int.TryParse(Console.ReadLine(), out selectReturn) || selectReturn != 1)
                    exit = true;
            }
            while (!exit);

        }

        static void Main(string[] args)
        {
            Console.SetWindowSize(160, 58);
            Menu();
            Console.Clear();
            Console.Write("Nhan phim bat ky de thoat...");
            Console.ReadKey();

        }
    }
}
