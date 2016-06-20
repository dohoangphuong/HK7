using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ass01
{
    public class NhanVien : CongNhanVienChuc
    {

        protected int soNgayCong;

        protected string phongBan;

        protected ChucVu chucVu;

        public string PhongBan
        {
            get { return phongBan; }
            set 
            {
                if (value != null || value != "")
                {
                    phongBan = value;
                }
                else
                {
                    phongBan = "Chưa nhập";
                }
            }
        }

        public int SoNgayCong
        {
            get { return soNgayCong; }
            set
            {
                if (value >= 0)
                {
                    soNgayCong = value;
                }
                else
                {
                    soNgayCong = 0;
                }
            }
        }
        public ChucVu ChucVuNhanVien
        {
            get { return chucVu; }
            set
            {
                chucVu = value;
                phuCap = (int) chucVu;
            }
        }

        public NhanVien()
        {
            HoTen = "";
            HeSoLuong = 2;
            ChucVuNhanVien = ChucVu.NhanVien;
            soNgayCong = 0;
            PhongBan = "";
        }

        public NhanVien(string hoTen, float heSoLuong, ChucVu chucVu, int soNgayCong, string phongBan)
        {
            HoTen = hoTen;
            HeSoLuong = heSoLuong;
            ChucVuNhanVien = chucVu;
            SoNgayCong = soNgayCong;
            PhongBan = phongBan;
            TinhLuong();
        }

        public override void TinhLuong()
        {
            luong =  heSoLuong*730 + phuCap + soNgayCong * 30;
        }

        public override void NhapThongTin()
        {
            base.NhapThongTin();

            Console.WriteLine("Nhap ten phong ban: ");
            PhongBan = Console.ReadLine();
            Console.WriteLine("Chon chuc vu: ");

            int i = 0;
            foreach (PropertyInfo property in typeof(ChucVu).GetProperties())
            {
                Console.WriteLine(i + ". " + property.Name);
            }

            string strTemp = "";

            int intTemp = 0;

            strTemp = Console.ReadLine();

            if (int.TryParse(strTemp, out intTemp))
            {
                switch (intTemp)
                {
                    case 1:
                        ChucVuNhanVien = ChucVu.TruongPhong;
                        break;
                    case 2:
                        ChucVuNhanVien = ChucVu.PhoPhong;
                        break;
                    default:
                        ChucVuNhanVien = ChucVu.NhanVien;
                        break;
                }
            }
            else
            {
                ChucVuNhanVien = ChucVu.NhanVien;
            }

            Console.WriteLine("Nhap so mgay cong: ");

            strTemp = Console.ReadLine();

            if (int.TryParse(strTemp, out intTemp))
            {
                SoNgayCong = intTemp;
            }
            else
            {
                SoNgayCong = 0;
            }

            TinhLuong();

        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();

            Console.WriteLine("Phong ban: " + PhongBan);
            Console.WriteLine("Trinh do: " + ChucVuNhanVien.ToString());
            Console.WriteLine(string.Format("So ngay cong: {0:N0}", SoNgayCong));
            Console.WriteLine(string.Format("Phu cap: {0:N0}", PhuCap));
            Console.WriteLine(string.Format("Luong: {0:N}", Luong));
        }

    }
}
