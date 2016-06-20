
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLGV
{

    public class NhanVien:CanBo
    {
        string phongban;

        public string Phongban
        {
            get { return phongban; }
            set { phongban = value; }
        }
        int songaycong;

        public int Songaycong
        {
            get { return songaycong; }
            set { songaycong = value; }
        }
       
        enum Chucvu
        {
            TruongPhong,
            PhoPhong,
            NhanVien,
            None
        }
        Chucvu chucvu;

        
        public NhanVien() : base("NhanVien") 
        {
            chucvu = Chucvu.None;
        }

        
        public void NhapThongTin()
        {
            int chontrinhdo;
            Console.Write("Nhap Ten: ");
            Hoten = Console.ReadLine();
            Console.Write("Nhap Phong ban: ");
            phongban = Console.ReadLine();
            Console.Write("Chon Chuc vu: 1-Truong phong, 2-Pho phong, 3-Nhan vien ");
            chontrinhdo = int.Parse(Console.ReadLine());
            while (chontrinhdo <= 3 && chontrinhdo > 0)
            {
                if (chontrinhdo == 1)
                {
                    chucvu = Chucvu.TruongPhong;
                    Phucap = 2000;
                    Console.WriteLine(chucvu.ToString());
                    break;
                }
                else if (chontrinhdo == 2)
                {
                    chucvu = Chucvu.PhoPhong;
                    Phucap = 1000;
                    Console.WriteLine(chucvu.ToString());
                    break;
                }
                else if (chontrinhdo == 3)
                {
                    chucvu = Chucvu.NhanVien;
                    Phucap = 500;
                    Console.WriteLine(chucvu.ToString());
                    break;
                }

            }
            Console.Write("So ngay cong: ");
            songaycong = int.Parse(Console.ReadLine());
            Console.Write("He so luong: ");
            Hesoluong = float.Parse(Console.ReadLine());
        }

        public override void XuatThongTin()
        {
            Console.WriteLine("Ho Ten\tPhong ban\tChuc vu\tSo ngay cong\tHe so luong\tPhu cap\tLuong");
            Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}\t\t{5}\t{6}", Hoten, phongban, chucvu.ToString(), songaycong.ToString(), Hesoluong.ToString(), Phucap.ToString(), Luong().ToString());
        
        }
        public override float Luong()
        {
            base.luong = base.Hesoluong * 730 + base.Phucap + songaycong * 30;
            return base.luong;
        }
    }

}
