using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment3
{
    class NhanVienHanhChinh : CanBo
    {
        private String PhongBan;

        public String PhongBan1
        {
            get { return PhongBan; }
            set { PhongBan = value; }
        }
        private String ChucVu;

        public String ChucVu1
        {
            get { return ChucVu; }
            set { ChucVu = value; }
        }
        private int SoNgayCong;

        public int SoNgayCong1
        {
            get { return SoNgayCong; }
            set { SoNgayCong = value; }
        }

        public override int TinhPhuCap()
        {
            if (ChucVu == "Trưởng Phòng") return PhuCap1 = 2000;
            else if (ChucVu == "Phó Phòng") return PhuCap1 = 1000;
            else if (ChucVu == "Nhân Viên") return PhuCap1 = 500;

            return PhuCap1 = 0;
        }

        public override int TinhLuong()
        {
            return HeSoLuong1 * 730 + PhuCap1 + SoNgayCong * 30;
        }

        public override void Nhap()
        {
            try
            {
                int chon = 0;
                base.Nhap();

                Console.OutputEncoding = Encoding.UTF8;

                Console.Write("Nhập Phòng Ban:");
                PhongBan = Console.ReadLine();

                Console.Write("Nhập Số Ngày Công: ");
                SoNgayCong = int.Parse(Console.ReadLine());

                Console.WriteLine("************************************");
                Console.WriteLine("Chọn  Chức Vụ !");
                Console.WriteLine("Phím 1 nếu là Trưởng Phòng");
                Console.WriteLine("Phím 2 nếu là Phó Phòng");
                Console.WriteLine("Phím 3 nếu là Nhân Viên");
                Console.WriteLine("************************************");

                chon = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (chon)
                {
                    case 1:
                        {
                            ChucVu = "Trưởng Phòng";
                            break;
                        }
                    case 2:
                        {
                            ChucVu = "Phó Phòng";
                            break;
                        }
                    case 3:
                        {
                            ChucVu = "Nhân Viên";
                            break;
                        }
                    default:
                        Console.WriteLine("Hãy nhập đúng định dạng!");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Lỗi xảy ra. Hãy thử lại!!");
                this.Nhap();
              
            }
        }

        public override void Xuat()
        {
            base.Xuat();

            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Phòng Ban :" + PhongBan);
            Console.WriteLine("Chức Vụ : " + ChucVu);
            Console.WriteLine("Số Ngày Công :" + SoNgayCong);
        }
    }
}
