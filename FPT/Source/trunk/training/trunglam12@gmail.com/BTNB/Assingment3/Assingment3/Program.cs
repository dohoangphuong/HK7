using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Manage manage = new Manage();
            int index = 0;

            while (true)
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("************************************");
                Console.WriteLine("Phím 1 nếu muốn tạo danh sách nhân viên");
                Console.WriteLine("Phím 2 nếu muốn tìm kiếm nhân viên theo tên và phòng ban");
                Console.WriteLine("Phím 3 nếu muốn xuất ra danh sách nhân viên");
                Console.WriteLine("Phím 4 nếu muốn thoát");
                Console.WriteLine("************************************");
                if (int.TryParse(Console.ReadLine(), out index))
                {
                    Console.Clear();
                    switch (index)
                    {
                        case 1:
                            {
                                manage.NhapListCanBo();

                                break;
                            }
                        case 2:
                            {
                                manage.TimKiem();
                                break;
                            }
                        case 3:
                            {

                                manage.XuatListCanBo();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Hãy chọn đúng như menu để thực hiện!");
                                break;
                            }
                    }
                    if (index == 4) break;
                }
                else Console.WriteLine("Nhập lựa chọn không đúng!");
            }
        }
    }
}
