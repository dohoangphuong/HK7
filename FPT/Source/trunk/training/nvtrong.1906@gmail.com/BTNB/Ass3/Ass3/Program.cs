using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Ass3
{
    class Program
    {
        static void Main(string[] args)
        {
            GiangVien gv = new GiangVien();
            //gv.HoTen = "Nguyen Van A";
            //gv.Khoa = "CNPM";
            //gv.SoTietDay = 20;
            //gv.TrinhDoNhanVien = "TienSi";
            //gv.HeSoLuong = 2.34f;

            int luong = gv.TinhLuong();
            int value = 123231233;
            Console.WriteLine("Lương: {0:#,#} VNĐ", value);

            //gv.Xuat();

            //GiangVien gv = new GiangVien();
            //gv.Nhap();
            //gv.Xuat();
            Console.ReadLine();
        }
    }
}
