using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment3
{
    class CanBo
    {
        private String HoTen;

        public String HoTen1
        {
            get { return HoTen; }
            set { HoTen = value; }
        }
        private int PhuCap;

        public int PhuCap1
        {
            get { return PhuCap; }
            set { PhuCap = value; }
        }
        private int HeSoLuong;

        public int HeSoLuong1
        {
            get { return HeSoLuong; }
            set { HeSoLuong = value; }
        }

        public virtual void Nhap()
        {

            while (true)
            {
                try
                {
                    Console.OutputEncoding = Encoding.UTF8;

                    Console.Write("Nhập Họ Tên :");
                    HoTen = Console.ReadLine();

                    Console.Write("Nhập Phụ Cấp :");
                    PhuCap = int.Parse(Console.ReadLine());

                    Console.Write("Nhập Hệ Số Lương :");
                    HeSoLuong = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("Lỗi nhập liệu!, Vui lòng thử lại!");

                }
            }
        }  
              
            
            
                

        public virtual void Xuat()
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Họ Tên :" + HoTen);
            Console.WriteLine("Phụ Cấp :" + PhuCap);
            Console.WriteLine("Hệ Số Lương :" + HeSoLuong);
            Console.WriteLine("Lương :" + TinhLuong());

        }

        public virtual int TinhPhuCap()
        {
            return 0;
        }
        public virtual int TinhLuong()
        {
            return 0;
        }
    }
}
