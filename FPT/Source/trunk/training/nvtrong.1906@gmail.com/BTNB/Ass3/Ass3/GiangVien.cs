using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3
{
    public enum TrinhDo
    {
        CuNhan,
        ThacSi,
        TienSi
    }

    class GiangVien : NhanVien
    {
        private static readonly int[] PHU_CAP = { 300, 500, 1000 };

        public string Khoa { get; set; }

        private TrinhDo trinhDo;

        public string TrinhDoNhanVien
        {
            get
            {
                return this.trinhDo.ToString();
            }
            set
            {
                switch (value)
                {
                    case "CuNhan":
                        this.trinhDo = TrinhDo.CuNhan;
                        this.PhuCap = PHU_CAP[(int)this.trinhDo];
                        break;
                    case "ThacSi":
                        this.trinhDo = TrinhDo.ThacSi;
                        this.PhuCap = PHU_CAP[(int)this.trinhDo];
                        break;
                    case "TienSi":
                        this.trinhDo = TrinhDo.TienSi;
                        this.PhuCap = PHU_CAP[(int)this.trinhDo];
                        break;
                    default:
                        this.trinhDo = TrinhDo.CuNhan;
                        this.PhuCap = PHU_CAP[(int)this.trinhDo];
                        break;
                }
            }
        }

        public int SoTietDay { get; set; }

        public GiangVien()
        {
        }

        override
        public int TinhLuong()
        {
            int luong = 0;

            luong = (int)(this.HeSoLuong * 730 * this.PhuCap * this.SoTietDay * 45);

            return luong;
        }

        override
        public void Xuat()
        {
            Console.Write("{0} {1} {2}", this.HoTen.PadLeft(10, ' ').ToString(), this.Khoa.PadLeft(7, ' '),this.TrinhDoNhanVien.ToString().PadLeft(7, ' '));
            Console.Write("Luong: {0:#,# } VND ", this.TinhLuong().ToString().PadLeft(15, ' '));
        }

        override
        public void Nhap()
        {
            Console.WriteLine("Vui long nhap Thong Tin Giang Vien");
            Console.Write("Ho va Ten: "); this.HoTen = Console.ReadLine();
            Console.Write("Khoa: "); this.Khoa = Console.ReadLine();

            bool flag = true; ;
            do
            {
                Console.WriteLine("TrinhDo: 1. Cu Nhan; 2. Thac Si; 3.Tien Si - Chon mot trong 3");
                try
                {
                    int choose = int.Parse(Console.ReadLine());
                    switch(choose)
                    {
                        case 1:
                            this.trinhDo = TrinhDo.CuNhan;
                            flag = false;
                            break;
                        case 2:
                            this.trinhDo = TrinhDo.ThacSi;
                            flag = false;
                            break;
                        case 3:
                            this.trinhDo = TrinhDo.TienSi;
                            flag = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (flag);

            this.SoTietDay = CatchException.ReadInt("So Tiet Day: ");
            this.HeSoLuong = CatchException.ReadInt("Hệ số lương: ");
        }
    }
}
