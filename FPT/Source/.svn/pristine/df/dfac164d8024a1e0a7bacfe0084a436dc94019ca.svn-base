using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ass01
{
    class Program
    {
        static void Main(string[] args)
        {
            Initialize();

            //List<NhanVien> nhanViens = new List<NhanVien>();

            //nhanViens.Add(new NhanVien("Nguyen Van A", (float)2.4, ChucVu.NhanVien, 25, "CNPM"));
            //nhanViens.Add(new NhanVien("Nguyen Van B", (float)4, ChucVu.TruongPhong, 25, "CNPM"));
            //nhanViens.Add(new NhanVien("Nguyen Van C", (float)2, ChucVu.PhoPhong, 25, "CNPM"));
            //nhanViens.Add(new NhanVien("Nguyen Van D", (float)1.4, ChucVu.NhanVien, 25, "CNPM"));
            //nhanViens.Add(new NhanVien("Nguyen Van E", (float)1.4, ChucVu.NhanVien, 25, "CNPM"));
            //nhanViens.Add(new NhanVien("Nguyen Van F", (float)1.24, ChucVu.PhoPhong, 25, "CNPM"));
            //nhanViens.Add(new NhanVien("Nguyen Van G", (float)2.41, ChucVu.NhanVien, 25, "CNPM"));

            //nhanViens.Sort();

            //foreach (NhanVien nhanVien in nhanViens)
            //{
            //    nhanVien.XuatThongTin();
            //}

            //var query = from nv in nhanViens
            //    where nv.HoTen.Contains("Van A") || nv.PhongBan.Contains("NPasdf")
            //    select nv;

            //Console.WriteLine("Tim kiem thong tin nhan vien");

            //foreach (NhanVien nhanVien in query)
            //{
            //    nhanVien.XuatThongTin();
            //}

            //Console.ReadLine();
        }

        private static void Initialize()
        {
            List<CongNhanVienChuc> congNhanVienChucs = new List<CongNhanVienChuc>();

            congNhanVienChucs.Add(new NhanVien("Nguyen Van A", (float)2.4, ChucVu.NhanVien, 25, "CNPM"));
            congNhanVienChucs.Add(new NhanVien("Nguyen Van B", (float)4, ChucVu.TruongPhong, 25, "CNPM"));
            congNhanVienChucs.Add(new NhanVien("Nguyen Van C", (float)2, ChucVu.PhoPhong, 25, "CNPM"));
            congNhanVienChucs.Add(new NhanVien("Nguyen Van D", (float)1.4, ChucVu.NhanVien, 25, "CNPM"));
            congNhanVienChucs.Add(new NhanVien("Nguyen Van E", (float)1.4, ChucVu.NhanVien, 25, "CNPM"));
            congNhanVienChucs.Add(new NhanVien("Nguyen Van F", (float)1.24, ChucVu.PhoPhong, 25, "CNPM"));
            congNhanVienChucs.Add(new NhanVien("Nguyen Van G", (float)2.41, ChucVu.NhanVien, 25, "CNPM"));

            congNhanVienChucs.Add(new GiangVien("Nguyen Van F", (float)2.6, TrinhDo.CuNhan, 25, "CNPM"));
            congNhanVienChucs.Add(new GiangVien("Nguyen Van I", (float)4.1, TrinhDo.TienSi, 25, "CNPM"));
            congNhanVienChucs.Add(new GiangVien("Nguyen Van K", (float)3.4, TrinhDo.ThacSi, 25, "CNPM"));
            congNhanVienChucs.Add(new GiangVien("Nguyen Van L", (float)2.41, TrinhDo.CuNhan, 25, "CNPM"));
            congNhanVienChucs.Add(new GiangVien("Nguyen Van M", (float)2.41, TrinhDo.CuNhan, 25, "CNPM"));
            congNhanVienChucs.Add(new GiangVien("Nguyen Van O", (float)2.5, TrinhDo.CuNhan, 25, "CNPM"));
            congNhanVienChucs.Add(new GiangVien("Nguyen Van P", (float)3, TrinhDo.ThacSi, 25, "CNPM"));


            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Nhap nhan vien");
                Console.WriteLine("2. Nhap giang vien");
                Console.WriteLine("3. Tim kiem nhan vien theo ten va phong ban");
                Console.WriteLine("4. Xuat tat ca danh sach");

                Console.WriteLine("5. Thoat");
                Console.WriteLine("Chon 1 - 5: ");
                int intChoose = 0;
                string strTemp = "";
                do
                {
                    strTemp = Console.ReadLine();

                    if (int.TryParse(strTemp, out intChoose))
                    {
                        switch (intChoose)
                        {
                            case 1:
                                NhapNhanVien(ref congNhanVienChucs);
                                break;
                            case 2:
                                NhapGiangVien(ref congNhanVienChucs);
                                break;
                            case 3:
                                TimTheoTenHoacPhongBan(congNhanVienChucs);
                                break;
                            case 4:
                                InToanBoDanhSach(congNhanVienChucs);
                                break;
                            case 5:
                                return;
                            default:
                                intChoose = 0;
                                break;
                        }
                    }

                } while (intChoose == 0);
                
            } while (true);
        }

        private static void TimTheoTenHoacPhongBan(List<CongNhanVienChuc> congNhanVienChucs)
        {
            do
            {
                string strHoTen = "";
                string strPhongBan = "";

                Console.WriteLine("Nhap ho ten muon tim: ");
                strHoTen = Console.ReadLine();

                Console.WriteLine("Nhap phong ban muon tim: ");
                strPhongBan = Console.ReadLine();

                var query = from cnvc in congNhanVienChucs
                            where cnvc.GetType() == typeof(NhanVien) &&
                                  (cnvc.HoTen.Contains(strHoTen) || (cnvc as NhanVien).PhongBan.Contains(strPhongBan))
                            select cnvc;

                foreach (var congNhanVienChuc in query)
                {
                    congNhanVienChuc.XuatThongTin();
                } 

                Console.WriteLine("An pim bat ky de thoat, an enter de tiep tuc!");
            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
        }

        private static void InToanBoDanhSach(List<CongNhanVienChuc> congNhanVienChucs )
        {
            congNhanVienChucs.Sort();
            foreach (var congNhanVienChuc in congNhanVienChucs)
            {
                congNhanVienChuc.XuatThongTin();
            }
        }

        private static void NhapGiangVien(ref List<CongNhanVienChuc> giangViens)
        {
            do
            {
                GiangVien giangVien = new GiangVien();  
                giangVien.NhapThongTin();
                giangViens.Add(giangVien);
                Console.WriteLine("An phim bat ky de thoat, an phim enter de tiep tuc");

            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
        }

        private static void NhapNhanVien(ref List<CongNhanVienChuc> nhanViens)
        {
            do
            {
                NhanVien nhanVien = new NhanVien();
                nhanVien.NhapThongTin();
                nhanViens.Add(nhanVien);
                Console.WriteLine("An phim bat ky de thoat, an phim enter de tiep tuc");
            } while (Console.ReadKey(true).Key == ConsoleKey.Enter);
        }

    }
}
