using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCanBo
{
    abstract class CanBo
    {
        protected string HoTen;
        protected int PhuCap;
        protected int HeSoLuong;

        /// <summary> 
        /// Get HoTen of current CanBo
        /// </summary>
        /// <returns>
        /// HoTen of CanBo
        /// </returns>
        public string GetHoTen()
        {
            return HoTen;
        }

        /// <summary> 
        /// Get Luong of current CanBo
        /// </summary>
        /// <returns>
        /// Luong
        /// </returns>
        abstract public int GetLuong();

        /// <summary> 
        /// For user input and add new CanBo
        /// </summary>
        abstract public void Add();

        /// <summary> 
        /// Display the current canbo infomation in the console windows
        /// </summary>
        abstract public void ShowInfomation();
    }
}
