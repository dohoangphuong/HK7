using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCanBo
{
    class NhanVien : CanBo
    {
        //Enum for TrinhDo which include it's name as description and PhuCap as value
        public enum ChucVuType
        {
            [Description("Truong phong")]
            TruongPhong = 2000,
            [Description("Pho phong")]
            PhoPhong = 1000,
            [Description("Nhan vien")]
            NhanVien = 500,
        }

        private string PhongBan;
        private string ChucVu;
        private int SoNgayCong;

        /// <summary> 
        /// For user input and add new NhanVien
        /// </summary>
        public override void Add()
        {
            try
            {
                Console.Write("Nhap ho ten: ");
                HoTen = Console.ReadLine();
                Console.Write("Nhap phong ban: ");
                PhongBan = Console.ReadLine();

                //Chuc vu
                int choice = 0;
                bool isFirstAttempt = true;
                do
                {
                    //Neu la lan nhap dau tien
                    if (isFirstAttempt)
                    {
                        isFirstAttempt = false;
                        Console.WriteLine("Chuc vu: 1) {0}\t2) {1}\t3) {2}", ChucVuType.TruongPhong.GetDescription(),
                            ChucVuType.PhoPhong.GetDescription(), ChucVuType.NhanVien.GetDescription());
                        Console.Write("Chon chuc vu: ");
                    }
                    else
                    {
                        Console.Write("Vui long chi nhap so trong cac lua chon: ");
                    }

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                ChucVu = ChucVuType.TruongPhong.GetDescription();
                                PhuCap = (int)ChucVuType.TruongPhong;
                                break;
                            case 2:
                                ChucVu = ChucVuType.PhoPhong.GetDescription();
                                PhuCap = (int)ChucVuType.PhoPhong;
                                break;
                            case 3:
                                ChucVu = ChucVuType.NhanVien.GetDescription();
                                PhuCap = (int)ChucVuType.NhanVien;
                                break;
                            default:
                                choice = 0;
                                break;
                        }
                    }
                }
                while (choice == 0);

                //Ngay cong
                isFirstAttempt = true;
                do
                {
                    if (isFirstAttempt)
                    {
                        Console.Write("Nhap so ngay cong: ");
                        isFirstAttempt = false;
                    }
                    else
                    {
                        Console.Write("Vui long chi nhap so lon hon 0: ");
                    }
                    int.TryParse(Console.ReadLine(), out SoNgayCong);
                }
                while (SoNgayCong <= 0);

                //He so luong
                isFirstAttempt = true;          
                do
                {
                    if (isFirstAttempt)
                    {
                        Console.Write("Nhap he so luong: ");
                        isFirstAttempt = false;
                    }
                    else
                    {
                        Console.Write("Vui long chi nhap so lon hon 0: ");
                    }
                    int.TryParse(Console.ReadLine(), out HeSoLuong);
                }
                while (HeSoLuong == 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary> 
        /// Get Luong of current CanBo
        /// </summary>
        /// <returns>
        /// Luong
        /// </returns>
        public override int GetLuong()
        {
            return (HeSoLuong * 730 + PhuCap + SoNgayCong * 30);
        }

        /// <summary> 
        /// Display the current NhanVien infomation in the console windows
        /// </summary>
        public override void ShowInfomation()
        {
            Console.WriteLine("Ho ten: {0}\tPhong ban: {1}\tChuc vu: {2}\tPhu cap: {3}\tSo ngay cong: {4}\tLuong: {5}",
                HoTen, PhongBan, ChucVu, PhuCap, SoNgayCong, GetLuong());
        }

        /// <summary> 
        /// Check info of NhanVien if match with given hoTen and phongBan
        /// </summary>
        /// <returns>
        /// True if match, otherwise false
        /// </returns>
        public bool CheckInfo(string hoTen, string phongBan)
        {
            if (PhongBan == phongBan && HoTen.ToLower().Contains(hoTen.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}
