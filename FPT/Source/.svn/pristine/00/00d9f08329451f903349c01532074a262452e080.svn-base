
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLGV
{
    public class GiangVien:CanBo
    {
        string khoa;

        public string Khoa
        {
            get { return khoa; }
            set { khoa = value; }
        }
        enum TrinhDo
        {
            CuNhan,
            ThacSi,
            TienSi,
            None
        }
        TrinhDo trinhdo;

        private TrinhDo Trinhdo
        {
            get { return trinhdo; }
            set { trinhdo = value; }
        }
        int sotietdaytrongthang;

        public int Sotietdaytrongthang
        {
            get { return sotietdaytrongthang; }
            set { sotietdaytrongthang = value; }
        }
        public GiangVien():base ("GiangVien")
        {
            trinhdo = TrinhDo.None;
        }
        
        public void NhapThongTin()
        {
            int chontrinhdo;
            Console.Write("Nhap Ten: ");
            Hoten = Console.ReadLine();
            Console.Write("Nhap Khoa: ");
            khoa = Console.ReadLine();
            do
            {
                Console.Write("Chon trinh do: 1-Cu Nhan, 2-Thac Si, 3-Tien Si ");
                chontrinhdo = int.Parse(Console.ReadLine());
            }
            while (chontrinhdo > 3 || chontrinhdo <= 0);
            
                if (chontrinhdo == 1)
                {
                    trinhdo = TrinhDo.CuNhan;
                    Phucap = 300;
                    Console.WriteLine(trinhdo.ToString());
                    
                }
                else if (chontrinhdo == 2)
                {
                    trinhdo = TrinhDo.ThacSi;
                    Phucap = 500;
                    Console.WriteLine(trinhdo.ToString());
                    
                }
                else if (chontrinhdo == 3)
                {
                    trinhdo = TrinhDo.TienSi;
                    Phucap = 1000;
                    Console.WriteLine(trinhdo.ToString());
                    
                }
                
            
            Console.Write("So tiet day trong thang: ");
            sotietdaytrongthang = int.Parse(Console.ReadLine());
            Console.Write("He so luong: ");
            Hesoluong = float.Parse(Console.ReadLine());

        }
        public override void XuatThongTin()
        {
            Console.WriteLine("Ho Ten\tKhoa\tTrinh do\tSo tiet day\tHe so luong\tPhu cap\tLuong");
            Console.WriteLine("{0}\t{1}\t{2}\t\t{3}\t\t{4}\t\t{5}\t{6}", Hoten, khoa, trinhdo.ToString(), sotietdaytrongthang.ToString(), Hesoluong.ToString(), Phucap.ToString(), Luong().ToString());
        }
        public override float Luong()
        {
            base.luong = base.Hesoluong * 730 + base.Phucap + sotietdaytrongthang * 45;
            return base.luong;
        }
    }
}
