using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCanBo
{
    class Program
    {
        #region Global variable
        private static List<GiangVien> listGiangVien = new List<GiangVien>();
        private static List<NhanVien> listNhanVien = new List<NhanVien>();
        #endregion

        #region Function
        /// <summary> 
        /// Print menu for user choose a funtion
        /// </summary>
        public static void PrintMenu()
        {
            bool isFirstAttempt = true; //To check if user 1st attemp
            int choice = 0;             //To save user choice

            Console.Clear();
            Console.WriteLine("Danh sach chuc nang:");
            Console.WriteLine("1) Nhap danh sach nhan vien moi");
            Console.WriteLine("2) Nhap tiep danh sach nhan vien");
            Console.WriteLine("3) Tim kiem nhan vien theo ten va phong ban");
            Console.WriteLine("4) Xuat danh sach can bo toan truong");
            Console.WriteLine("5) Thoat");
            //Validate user input
            do
            {
                if (isFirstAttempt)
                {
                    isFirstAttempt = false;
                    Console.Write("\nVui long chon 1 chuc nang: ");
                }
                else
                {
                    Console.Write("Vui long chi nhap so trong danh sach chuc nang: ");
                }
                int.TryParse(Console.ReadLine(), out choice);
            }
            while (choice <= 0 || choice > 5);

            //Handle user choice
            switch (choice)
            { 
                case 1:
                    listGiangVien.Clear();
                    listNhanVien.Clear();
                    AddCanBo();
                    break;
                case 2:
                    AddCanBo();
                    break;
                case 3:
                    SearchNhanVien();
                    break;
                case 4:
                    ShowListCanBo();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    PrintMenu();
                    break;
            }
        }   

        /// <summary> 
        /// for user add CanBo to the list
        /// </summary>
        public static void AddCanBo()
        {   
            try
            {
                bool isFirstAttempt = true; //To check if user 1st attemp
                int totalNumber = 0;        //Total number of Canbo
                int choice = 0;             //Save user input

                Console.Clear();
                do
                {
                    if (isFirstAttempt)
                    {
                        isFirstAttempt = false;
                        Console.Write("Nhap so luong can bo ");
                    }
                    else
                    {
                        Console.Write("Vui long chi nhap so lon hon 0: ");
                    }
                    int.TryParse(Console.ReadLine(), out totalNumber);
                }
                while (totalNumber <= 0);

                //Add list CanBo
                for (int i = 0; i < totalNumber; i++)
                {
                    Console.WriteLine("\nNhap can bo thu {0}: ", i + 1);
                    choice = 0;
                    isFirstAttempt = true;
                    do
                    {
                        //If it;s 1st attemp
                        if (isFirstAttempt)
                        {
                            isFirstAttempt = false;
                            Console.WriteLine("Loai can bo: 1) Giang vien\t2) Nhan vien hanh chinh");
                            Console.Write("Chon loai can bo: ");
                        }
                        else
                        {
                            Console.Write("Vui long chi nhap so trong cac lua chon: ");
                        }

                        if (int.TryParse(Console.ReadLine(), out choice))
                        {
                            switch (choice)
                            {
                                case 1:
                                    listGiangVien.Add(new GiangVien());
                                    listGiangVien[listGiangVien.Count - 1].Add();
                                    break;
                                case 2:
                                    listNhanVien.Add(new NhanVien());
                                    listNhanVien[listNhanVien.Count - 1].Add();
                                    break;
                                default:
                                    choice = 0;
                                    break;
                            }
                        }
                    }
                    while (choice == 0);
                }

                Console.WriteLine("Nhap thanh cong! Nhan Enter de tro ve menu chinh");
                Console.ReadLine();
                PrintMenu();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary> 
        /// Display the all CanBo infomation in the console windows
        /// </summary>
        public static void ShowListCanBo()
        {
            Console.Clear();
            if (listGiangVien.Count > 0 || listNhanVien.Count > 0)
            {
                Console.WriteLine("Danh sach giang vien:");
                foreach (GiangVien giangVien in listGiangVien)
                {
                    giangVien.ShowInfomation();
                }

                Console.WriteLine("\nDanh sach nhan vien:");
                foreach (NhanVien nhanVien in listNhanVien)
                {
                    nhanVien.ShowInfomation();
                }
            }
            else
            {
                Console.WriteLine("Khong co can bo nao trong danh sach");
            }
            Console.WriteLine("Nhan Enter de tro ve menu chinh");
            Console.ReadLine();
            PrintMenu();
        }

        /// <summary> 
        /// Sort list CanBo by Luong
        /// </summary>
        public static void SortListCanBo()
        {
            Console.Clear();
            if (listGiangVien.Count > 0 || listNhanVien.Count > 0)
            {
                Console.WriteLine("Danh sach giang vien:");

                foreach (GiangVien giangVien in listGiangVien.OrderBy(x=>x.GetLuong()).ThenBy(x=>x.GetHoTen()))
                {
                    giangVien.ShowInfomation();
                }

                Console.WriteLine("\nDanh sach nhan vien:");
                foreach (NhanVien nhanVien in listNhanVien.OrderBy(x => x.GetLuong()).ThenBy(x => x.GetHoTen()))
                {
                    nhanVien.ShowInfomation();
                }
            }
            else
            {
                Console.WriteLine("Khong co can bo nao trong danh sach");
            }
            Console.WriteLine("Nhan Enter de tro ve menu chinh");
            Console.ReadLine();
            PrintMenu();
        }

        /// <summary> 
        /// Allow user input HoTen and PhongBan to search and display result
        /// </summary>
        public static void SearchNhanVien()
        {
            string hoTen = null;
            string phongBan = null;
            int choice = 0;             //Save user input
            bool isContinued = false;   //To check if user choose to continue
            List<NhanVien> result = new List<NhanVien>();

            Console.Clear();
            do
            {
                //Get user input
                Console.Write("Nhap vao ten nhan vien can tim: ");
                hoTen = Console.ReadLine();
                Console.Write("Nhap vao phong ban can tim: ");
                phongBan = Console.ReadLine();

                //Perform search
                foreach (NhanVien nhanVien in listNhanVien)
                {
                    if (nhanVien.CheckInfo(hoTen, phongBan))
                    {
                        result.Add(nhanVien);
                    }
                }

                //Display result
                if (result.Count > 0)
                {
                    Console.WriteLine("Nhan vien phu hop voi ket qua tim kiem la: ");
                    foreach (NhanVien nv in result)
                    {
                        nv.ShowInfomation();
                    }
                }
                else
                {
                    Console.WriteLine("Khong co ket qua nao phu hop");
                }

                //To check if continue search or go back to main menu
                Console.Write("Ban co muon tiep tuc(1 de tiep tuc): ");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            isContinued = true;
                            break;
                        default:
                            isContinued = false;
                            break;
                    }
                }
                else
                {
                    isContinued = false;
                }
            }
            while (isContinued);

            PrintMenu();
        }
        #endregion

        static void Main(string[] args)
        {
            PrintMenu();
        }
    }
}
