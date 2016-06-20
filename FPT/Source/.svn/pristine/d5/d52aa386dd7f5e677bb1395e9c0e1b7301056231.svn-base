using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace Ass01
{
    public class GiangVien : CongNhanVienChuc
    {
        protected int soTietDay;

        protected string khoa;

        protected TrinhDo trinhDo;

        public int SoTietDay
        {
            get { return soTietDay; }
            set 
            {
                if (value > 0)
                {
                    soTietDay = value;
                }
                else
                {
                    soTietDay = 0;
                }
            }
        }

        public string Khoa
        {
            get { return khoa; }
            set 
            {
                if (value != null || value != "")
                {
                    khoa = value;
                }
                else
                {
                    khoa = "Chưa nhập";
                }
            }
        }

        public TrinhDo TrinhDoGiangVien
        {
            get { return trinhDo; }
            set
            {
                trinhDo = value;
                phuCap = (int) trinhDo;
            }
        }

        public GiangVien()
        {
            HoTen = "";
            HeSoLuong = 2;
            TrinhDoGiangVien = TrinhDo.CuNhan;
            soTietDay = 0;
            Khoa = "";
            TinhLuong();
        }

       public GiangVien(string hoTen, float heSoLuong, TrinhDo trinhDoGiangVien, int soTietDay, string khoa)
        {
            HoTen = hoTen;
            HeSoLuong = heSoLuong;
           TrinhDoGiangVien = trinhDoGiangVien;
           SoTietDay = soTietDay;
           Khoa = khoa;
            TinhLuong();
        }

        public override void TinhLuong()
        {
            luong =  heSoLuong*730 + phuCap + soTietDay*45;
        }

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.WriteLine("Nhap ten khoa: ");
            Khoa = Console.ReadLine();
            Console.WriteLine("Chon trinh do: ");

            int i = 0;
            foreach (PropertyInfo property in typeof(TrinhDo).GetProperties())
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
                        TrinhDoGiangVien = TrinhDo.ThacSi;
                        break;
                    case 2:
                        TrinhDoGiangVien = TrinhDo.TienSi;
                        break;
                    default:
                        TrinhDoGiangVien = TrinhDo.CuNhan;
                        break;
                }
            }
            else
            {
                TrinhDoGiangVien = TrinhDo.CuNhan;
            }

            Console.WriteLine("Nhap so tiet day trong thang: ");

            strTemp = Console.ReadLine();

            if (int.TryParse(strTemp, out intTemp))
            {
                SoTietDay = intTemp;
            }
            else
            {
                SoTietDay = 0;
            }
        }

        public override void XuatThongTin()
        {
            base.XuatThongTin();

            Console.WriteLine("Khoa: " + Khoa);
            Console.WriteLine("Trinh do: " + TrinhDoGiangVien.ToString());
            Console.WriteLine(string.Format("So tiet day trong thang: {0:N0}", SoTietDay));
            Console.WriteLine(string.Format("Phu cap: {0:N0}", PhuCap));
            Console.WriteLine(string.Format("Luong: {0:N0}", Luong));

        }
    }
}
