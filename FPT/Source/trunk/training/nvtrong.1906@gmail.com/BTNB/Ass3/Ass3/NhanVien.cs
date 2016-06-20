using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3
{
    abstract class NhanVien
    {
        // Họ và tên nhân viên
        public string HoTen { get; set; }

        // Hệ số lương nhân viên
        public float HeSoLuong { get; set; }

        // Phụ cấp của nhân viên
        protected int  PhuCap {get; set;}

        // Tính lương nhân viên
        public abstract int TinhLuong();

        // Nhập thông tin nhân viên
        public abstract void Nhap();

        // Xuất thông tin nhân viên
        public abstract void Xuat();
    }
}
