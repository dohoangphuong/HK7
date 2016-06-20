using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ass3
{
    class QuanLyNhanVien
    {
        private static readonly string[] KHOA = { "CNPM", "Khoa hoc", "He thong", "Mang" };
        private static readonly string[] PHONG_BAN = { "Giao duc", "Bao ve", "Hanh chinh", "Dao tao" };
        private static readonly string[] HO = { "Nguyen", "Tran", "Duong", "Pham", "Phan" };
        private static readonly string[] TEN_DEM = { "Thi", "Van", "Thu", "Ngoc", "Thanh" };
        private static readonly string[] TEN = { "Thai", "Thao", "Vu", "Phu", "Cong", "Sang" };

        private List<NhanVien> listNhanVien;
        private Random random = new Random();

        public void QuanLyNhanVien()
        {

            for (int i = 0; i < 5; i++)
            {
                string hoVaTen = string.Empty;
                string khoa = string.Empty;
                string phongBan = string.Empty;
                string ho = string.Empty;
                string tenDem = string.Empty;
                string ten = string.Empty;

                khoa = KHOA[random.Next(KHOA.Length)];


            }
        }

        public NhanVienHanhChinh NewNhanVienHanhChinh()
        {
            string hoVaTen = string.Empty;
            string khoa = string.Empty;
            string phongBan = string.Empty;
            string ho = string.Empty;
            string tenDem = string.Empty;
            string ten = string.Empty;
            string chucVu = string.Empty;
            int soNgayCong = 0;
            float heSoLuong = 0;

            khoa = KHOA[random.Next(KHOA.Length)];
        }

    }
}
