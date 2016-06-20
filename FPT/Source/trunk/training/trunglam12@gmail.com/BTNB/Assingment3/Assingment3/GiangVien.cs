using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment3
{
    class GiangVien : CanBo
    {
        private String Khoa;

        public String Khoa1
        {
            get { return Khoa; }
            set { Khoa = value; }
        }
        private String TrinhDo;

        public String TrinhDo1
        {
            get { return TrinhDo; }
            set { TrinhDo = value; }
        }
        private int SoTietDayTrongThang;

        public int SoTietDayTrongThang1
        {
            get { return SoTietDayTrongThang; }
            set { SoTietDayTrongThang = value; }
        }

        public override int TinhPhuCap()
        {
            if (TrinhDo == "Cử Nhân") return PhuCap1=300;
            else if (TrinhDo == "Thạc Sĩ") return PhuCap1 = 500;
            else if (TrinhDo == "Tiến Sĩ") return PhuCap1 = 1000;

            return PhuCap1 =0;
        }

        public override int TinhLuong()
        {
            return HeSoLuong1 * 730 + PhuCap1 + SoTietDayTrongThang * 45;
        }

        public override void Nhap()
        {
            try
            {
                base.Nhap();

                Console.OutputEncoding = Encoding.UTF8;

                Console.Write("Nhập Khoa :");
                Khoa = Console.ReadLine();

                Console.Write("Nhập Số Tiết Dạy: ");
                SoTietDayTrongThang = int.Parse(Console.ReadLine());

                Console.WriteLine("Chọn Trình độ !");
                Console.WriteLine("Phím 1 nếu là Cử Nhân");
                Console.WriteLine("Phím 2 nếu là Thạc Sĩ");
                Console.WriteLine("Phím 3 nếu là Tiến Sĩ");
               int chon = int.Parse(Console.ReadLine());

                switch (chon)
                {
                    case 1:
                        {
                            TrinhDo = "Cử Nhân";
                            break;
                        }
                    case 2:
                        {
                            TrinhDo = "Thạc Sĩ";
                            break;
                        }
                    case 3:
                        {
                            TrinhDo = "Tiến Sĩ";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Hãy nhập đúng định dạng!");
                            break;
                        }
                }

            }
            catch(FormatException ex)
            {
                Console.WriteLine("Lỗi Nhập Liệu!"+ex.Message +"Hãy Nhập Lại!");
                this.Nhap();         
            }

        }
        

        public override void Xuat()
        {
            base.Xuat();
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Khoa :" + Khoa);
            Console.WriteLine("Trình Độ : " + TrinhDo);
            Console.WriteLine("Số Tiết Dạy Trong Tháng :" + SoTietDayTrongThang);
        }
    }
}
