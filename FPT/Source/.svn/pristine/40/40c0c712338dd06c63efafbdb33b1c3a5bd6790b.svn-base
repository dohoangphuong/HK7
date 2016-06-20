using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLGV
{
    class Program
    {
        static List<CanBo> list = new List<CanBo>();
        static void Main(string[] args)
        {
            int luachon;
            bool exit=false;
            while (!exit)
            {
                do
                {
                    Console.WriteLine("1.Nhap can bo.");
                    Console.WriteLine("2.Tim kiem.");
                    Console.WriteLine("3.Xuat danh sach.");
                    Console.WriteLine("4.Xoa danh sach.");
                    Console.WriteLine("5.Exit: ");
                    Console.WriteLine("Lua chon: ");
                    luachon = int.Parse(Console.ReadLine());
                } while (luachon < 1 || luachon > 5);
                switch (luachon)
                {
                    case 1:
                        CreateNewEmp();
                        break;
                    case 2:
                        TimKiem();
                        break;
                    case 3:
                        SapXepTheoLuong();
                        foreach (CanBo i in list)
                        {
                            i.XuatThongTin();
                        }
                        break;
                    case 4:
                        list.Clear();
                        Console.WriteLine("Da xoa danh sach.");
                        break;
                    case 5:
                        exit = true;
                        Console.WriteLine("Nhan enter de thoat.");
                        list.Clear();
                        break;
                    default:
                        break;
                }
                
            }
            Console.ReadLine();
            
        }
        
        public static void CreateNewEmp()
        {
            int chon = 0;
            do
            {
                Console.WriteLine("Chon loai nhan vien(1-Giang vien, 2-Nhan vien): ");
                chon = int.Parse(Console.ReadLine());
            } while (chon < 1 || chon > 2);
            switch (chon)
            {
                case 1:
                    GiangVien gv = new GiangVien();
                    gv.NhapThongTin();
                    list.Add(gv);
                    
                    break;
                case 2:
                    NhanVien nv = new NhanVien();
                    nv.NhapThongTin();
                    list.Add(nv);
                    break;
            }
            

        }
        public static void XuatSoLuong()
        {
            Console.WriteLine("So luong can bo: "+list.Count().ToString());
        }
        public static void Swap(CanBo first, CanBo second)
        {
            CanBo temp = first;
            first = second;
            second = temp;
        }
        public static void SapXepTheoLuong()
        {
            for (int i = 0; i < list.Count() - 1; i++)
            {
                for (int j = i + 1; j < list.Count(); j++)
                {
                    if (list[i].Luong() > list[j].Luong())
                    {
                        Swap(list[i], list[j]);
                    }
                }
            }
        }
        public static void TimKiem()
        {
           
            int x=0;
            do
            {
                Console.WriteLine("Tim kiem theo: 1-ten, 2-phong ban: ");
                x = int.Parse(Console.ReadLine());
            }
            while (x < 1 || x > 2);
            
            switch (x)
            {
                case 1:
                    string _ten = "";
                    NhanVien nvcantim = null;
                    int soluong = 0;
                    Console.WriteLine("Nhap ten nhan vien: ");
                    _ten = Console.ReadLine();
                    
                    foreach (NhanVien i in list)
                    {
                        if (i.Hoten == _ten)
                        {
                            nvcantim = i;
                            soluong++;
                        }
                    }
                    if (soluong != 0)
                    {
                        Console.WriteLine("Da tim thay nhan vien co ten: " + _ten);
                        nvcantim.XuatThongTin();
                    }
                    else
                    {
                        Console.WriteLine("Khong tim thay! Vui long thu lai sau.");
                    }
                    break;
                case 2:
                    List<NhanVien> listnv = new List<NhanVien>();
                    int soluongnvtrongphong = 0;
                    string _phongban;
                    Console.WriteLine("Nhap phong ban: ");
                    _phongban = Console.ReadLine();
                    
                    foreach (NhanVien i in list)
                    {
                        if (i.Phongban==_phongban)
                        {
                            soluongnvtrongphong++;
                            listnv.Add(i);
                        }
                    }

                    if (soluongnvtrongphong != 0)
                    {
                        Console.WriteLine("Da tim thay nhan vien o phong ban: " + _phongban);
                        foreach (NhanVien i in listnv)
                        {
                            i.XuatThongTin();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Khong tim thay! Vui long thu lai sau.");
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
