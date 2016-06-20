using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment3
{
    class Manage
    {
        private  List<CanBo> ListCanBo;
        private List<NhanVienHanhChinh> ListNhanVienHanhChinh;
        private List<GiangVien> ListGiangVien;
        private NhanVienHanhChinh nhanvienhanhchinh;
        private GiangVien giangvien;

        private int SoLuongNhanVien;
        private int SoLuongGiangVien;

        public Manage()
        {
            ListCanBo = new List<CanBo>();
            ListNhanVienHanhChinh = new List<NhanVienHanhChinh>();
            ListGiangVien = new List<GiangVien>();
        }

        public void NhapListCanBo()
        {
            try
            {
                Console.OutputEncoding = Encoding.Unicode;

                Console.Write("Nhập Số Lượng Giảng Viên :");
                SoLuongGiangVien = int.Parse(Console.ReadLine());

                for (int i = 0; i < SoLuongGiangVien; i++)
                {
                    Console.WriteLine("Nhập Thông Tin Giảng Viên :" + (i + 1));
                    giangvien = new GiangVien();
                    giangvien.Nhap();
                    ListCanBo.Add(giangvien);
                }

                Console.Write("Nhập Số Lượng Cán Bộ Hành Chính :");
                SoLuongNhanVien = int.Parse(Console.ReadLine());

                for (int i = 0; i < SoLuongNhanVien; i++)
                {
                    nhanvienhanhchinh = new NhanVienHanhChinh();
                    nhanvienhanhchinh.Nhap();
                    ListCanBo.Add(nhanvienhanhchinh);
                    ListNhanVienHanhChinh.Add(nhanvienhanhchinh);
                }
            }
            catch
            {
                Console.WriteLine("Lỗi xảy ra! Vui lòng thử lại!");
                NhapListCanBo();
            }
        }

        public void XuatListCanBo()
        {
            ListCanBo = this.SapXep();
            for (int i = 0; i < ListCanBo.Count;i++ )
            {
                Console.WriteLine("Thông Tin Nhân Viên Thứ :" + (i + 1));
                ListCanBo[i].Xuat();
            }
        }

       public void TimKiem()
        {
            String hoten; //information Ho Ten to search
            String phongban;////information Ho Ten to search

            nhanvienhanhchinh = new NhanVienHanhChinh();

            Console.Write("Nhập Họ Tên Muốn Tìm :");
            hoten = Console.ReadLine();

            Console.Write("Nhập Phòng Ban Muốn Tìm:");
            phongban = Console.ReadLine();

            foreach (NhanVienHanhChinh nhanvien in ListNhanVienHanhChinh)
            {
                if (nhanvien.HoTen1.Trim().ToLower() == hoten.Trim().ToLower() && nhanvien.PhongBan1.Trim().ToLower() == phongban.Trim().ToLower())
                {
                    Console.WriteLine("Tìm Thấy");
                    nhanvien.Xuat();
                    return;
                    
                }
            }

            Console.WriteLine("Không Tìm Thấy");
        }
       public List<CanBo> SapXep()
       {
           CanBo tempnhanvien = new CanBo();
           for (int j = 0; j < ListCanBo.Count; j++)
           {
               for (int i = 1; i < ListCanBo.Count; i++)
               {
                   if (ListCanBo[i].TinhLuong() < ListCanBo[j].TinhLuong()) // sort by ascending Luong
                   {
                       tempnhanvien = ListCanBo[i];
                       ListCanBo[i] = ListCanBo[j];
                       ListCanBo[j] = tempnhanvien;
                   }
                   else if (ListCanBo[i].TinhLuong() == ListCanBo[j].TinhLuong())
                   {
                       if (ListCanBo[i].HoTen1.CompareTo(ListCanBo[j].HoTen1) < 0)  // sort by ascending Ho Ten
                      {
                         tempnhanvien = ListCanBo[i];
                         ListCanBo[i] = ListCanBo[j];
                         ListCanBo[j] = tempnhanvien;

                      }
                   }
               }
           }

           return ListCanBo;
       }

    }
}
