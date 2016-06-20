using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QLGV
{
    public abstract class CanBo
    {
        public float luong;
        private string hoten;

        public string Hoten
        {
            get { return hoten; }
            set { hoten = value; }
        }
        private int phucap;

        public int Phucap
        {
            get { return phucap; }
            set { phucap = value; }
        }
        private float hesoluong;

        public float Hesoluong
        {
            get { return hesoluong; }
            set { hesoluong = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public CanBo(string _type)
        {
            this.type = _type;

        }
        public virtual void XuatThongTin()
        {

        }
        public virtual float Luong()
        {
            return luong;
        }
        
    }
}
