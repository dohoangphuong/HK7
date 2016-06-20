using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass01
{
    abstract public class CongNhanVienChuc : IComparable<CongNhanVienChuc>
    {
        protected string hoTen;
        protected int phuCap;
        protected float heSoLuong;
        protected float luong;
        public int PhuCap
        {
            get { return phuCap; }
            set 
            {
                if (value >= 0)
                {
                    phuCap = value;
                }
                else
                {
                    phuCap = 0;
                }
            }
        }

        public float HeSoLuong
        {
            get { return heSoLuong; }
            set 
            {
                if (value > 1 && value < 5)
                {
                    heSoLuong = value;
                }
                else
                {
                    heSoLuong = 2;
                }
            }
        }

        public string HoTen
        {
            get { return hoTen; }
            set 
            {
                if (value != null || value != "")
                {
                    hoTen = value;
                }
                else
                {
                    hoTen = "Chưa nhập";
                }
            }
        }

        public float Luong
        {
            get { return luong; }
        }

        abstract public void TinhLuong();

        public virtual void NhapThongTin()
        {
            Console.WriteLine("Nhap ho ten: ");
            HoTen = Console.ReadLine();

            Console.WriteLine("\nNhap he so luong:");

            float fltTemp;

            if (float.TryParse(Console.ReadLine(), out fltTemp))
            {
                HeSoLuong = fltTemp;
            }
            else
            {
                HeSoLuong = 0;
            }
        }

        public virtual void XuatThongTin()
        {
            Console.WriteLine();
            Console.WriteLine("Ho ten: " + HoTen);
            Console.WriteLine("He so luong: " + HeSoLuong);
        }

        public int CompareTo(CongNhanVienChuc other)
        {
            if (other == null)
            {
                return 1;
            }
            else
            {
                if (Luong.CompareTo(other.Luong) == 0)
                {
                    return HoTen.CompareTo(other.HoTen);
                }
                else
                {
                    return Luong.CompareTo(other.Luong);
                }
            }
        }

        public override int GetHashCode()
        {
            return (int) Luong;
        }

        public override string ToString()
        {
            return HoTen;
        }
    }
}
