using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Option2
{
    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student();
            Console.WriteLine("Ho" + "\tDem" + "\tTen" + "\tID" + "\t   Birthday"+"\tRA" + "  SD");
            Console.WriteLine();

            for (int i = 0; i < 25;i++ )
            {
                Console.Write(st.getName(i) +"\t"+"HV");
                st.getStudentID(i);
                Console.WriteLine();
            }
                Console.ReadLine();
        }
    }
}
