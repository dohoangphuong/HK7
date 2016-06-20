using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ass3
{
    enum ChucVu
    {
        TruongPhong,
        PhoPhong,
        NhanVien
    }
    class NhanVienHanhChinh : NhanVien
    {
        private static readonly int[] PHU_CAP = new int[] { 2000, 1000, 500 };

        private ChucVu chucVu;

        public string ChucVuNhanVien 
        { 
            get
            {
                return chucVu.ToString();
            }
            set
            {
                switch (value)
                {
                    case "TruongPhong":
                        this.chucVu = ChucVu.TruongPhong;
                        this.PhuCap = PHU_CAP[(int)this.chucVu];
                        break;
                    case "PhoPhong":
                        this.chucVu = ChucVu.PhoPhong;
                        this.PhuCap = PHU_CAP[(int)this.chucVu];
                        break;
                    case "NhanVien":
                        this.chucVu = ChucVu.NhanVien;
                        this.PhuCap = PHU_CAP[(int)this.chucVu];
                        break;
                    default:
                        this.chucVu = ChucVu.NhanVien;
                        this.PhuCap = PHU_CAP[(int)this.chucVu];
                        break;
                }
            }
        }

        public string PhongBan { get; set; }

        public int SoNgayCong { get; set; }

        public NhanVienHanhChinh()
        {
        }

        override
        public int TinhLuong()
        {
            return 0;
        }

        override
        public void Nhap()
        {
            Console.WriteLine("Vui long nhap thong tin nhan vien: ");
            Console.Write("Ho va Ten: "); this.HoTen = Console.ReadLine();
            Console.Write("Phong ban: "); this.PhongBan = Console.ReadLine();
            this.SoNgayCong = CatchException.ReadInt("So ngay cong: ");
            this.HeSoLuong = CatchException.ReadFloat("He so luong: ");
            bool flag = true; ;
            do
            {
                Console.WriteLine("Chuc vu: 1. Truong Phong; 2. Pho phong; 3.Nhan Vien - Chon mot trong 3");
                try
                {
                    int choose = int.Parse(Console.ReadLine());
                    switch (choose)
                    {
                        case 1:
                            this.chucVu = ChucVu.TruongPhong;
                            flag = false;
                            break;
                        case 2:
                            this.chucVu = ChucVu.PhoPhong;
                            flag = false;
                            break;
                        case 3:
                            this.chucVu = ChucVu.NhanVien;
                            flag = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (flag);
        }

        override
        public void Xuat()
        {
            Console.Write("Ho và tên: {0}");
        }
    }
}
