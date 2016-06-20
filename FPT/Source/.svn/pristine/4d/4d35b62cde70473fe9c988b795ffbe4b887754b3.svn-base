using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.SqlServer.Server;

namespace Ass01_Opt2_Class_Simulation
{
    public class Student
    {
        // Họ tên
        private string fullName;

        // Mã số
        private string id;

        // Ngày sinh
        private DateTime birthday;

        // Điểm số
        private Dictionary<string, float> score;

        public Dictionary<string, float> Score
        {
            get { return score; }
        }

        public DateTime DateTime
        {
            get { return birthday; }
            set
            {
                // Giới hạn ngày dưới
                DateTime dtmStartDate = new DateTime(1970, 1, 1);

                // Giới hạn ngày trên
                DateTime dtmEndDate = new DateTime(1997, 12, 31);

                if (value >= dtmEndDate && value <= dtmEndDate )
                {
                    birthday = value;
                }
                else
                {
                    value = dtmStartDate;
                }
                
            }
        }

        public string Id
        {
            get { return id; }
            set
            {
                int intTemp = 0;
                if (int.TryParse(value, out intTemp))
                {
                    // ID phải là số có 7 chữ số
                    if (intTemp != 0 && (intTemp - 1000000 > 0))
                    {
                        id = "HV" + value;
                    }
                }
            }
        }

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        // Thêm sửa điểm cho môn học
        // Điểm số không thể vượt quá phạm vi cho phép
        public void SetScore(string name, float score)
        {
            if (score >= 0 && score <= 10)
            {
                this.score[name] = score;
            }
            else
            {
                this.score[name] = 0;
            }
        }
    }
}
