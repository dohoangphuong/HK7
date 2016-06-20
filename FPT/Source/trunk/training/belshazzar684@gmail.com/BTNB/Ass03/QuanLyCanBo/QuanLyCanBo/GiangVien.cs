using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCanBo
{
    class GiangVien : CanBo
    {
        //Enum for TrinhDo which include it's name as description and PhuCap as value
        public enum TrinhDoType
        {
            [Description("Cu nhan")]
            CuNhan = 300,
            [Description("Thac si")]
            ThacSi = 500,
            [Description("Tien si")]
            TienSi = 1000,
        }

        private string Khoa;
        private string TrinhDo;
        private int SoTietDay;

        /// <summary> 
        /// For user input and add new GiangVien
        /// </summary>
        public override void Add()
        {          
            try
            {
                Console.Write("Nhap ho ten: ");
                HoTen = Console.ReadLine();
                Console.Write("Nhap khoa: ");
                Khoa = Console.ReadLine();
                int choice = 0;

                //Trinh do
                bool isFirstAttempt = true;
                do
                {
                    //Is 1st attemp
                    if (isFirstAttempt)
                    {
                        isFirstAttempt = false;
                        Console.WriteLine("Trinh do: 1) {0}\t2) {1}\t3) {2}", TrinhDoType.CuNhan.GetDescription(), 
                                TrinhDoType.ThacSi.GetDescription(), TrinhDoType.TienSi.GetDescription());
                        Console.Write("Chon trinh do: ");
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
                                TrinhDo = TrinhDoType.CuNhan.GetDescription();
                                PhuCap = (int)TrinhDoType.CuNhan;
                                break;
                            case 2:
                                TrinhDo = TrinhDoType.ThacSi.GetDescription();
                                PhuCap = (int)TrinhDoType.ThacSi;
                                break;
                            case 3:
                                TrinhDo = TrinhDoType.TienSi.GetDescription();
                                PhuCap = (int)TrinhDoType.TienSi;
                                break;
                            default:
                                choice = 0;
                                break;
                        }
                    }
                }
                while (choice == 0);

                //So tiet 
                isFirstAttempt = true;
                do
                {
                    if (isFirstAttempt)
                    {
                        Console.Write("Nhap so tiet day trong thang: ");
                        isFirstAttempt = false;
                    }
                    else
                    {
                        Console.Write("Vui long chi nhap so lon hon 0: ");
                    }
                    int.TryParse(Console.ReadLine(), out SoTietDay);
                }
                while (SoTietDay == 0);

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
            return (HeSoLuong * 730 + PhuCap + SoTietDay * 45);
        }

        /// <summary> 
        /// Display the current GiangVien infomation in the console windows
        /// </summary>
        public override void ShowInfomation()
        {
            Console.WriteLine("Ho ten: {0}\tKhoa: {1}\tTrinh do: {2}\tPhu cap: {3}\tSo tiet day trong thang: {4}\tLuong: {5}",
                HoTen, Khoa, TrinhDo, PhuCap, SoTietDay, GetLuong());
        }
    }
}
