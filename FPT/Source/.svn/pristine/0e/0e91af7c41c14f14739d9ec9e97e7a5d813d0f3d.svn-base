using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ass3
{
    static class CatchException
    {
        public static int ReadInt(string msg)
        {
            int value = 0;
            Console.Write(msg);
            try
            {
                value = int.Parse(Console.ReadLine());
            }
            catch (FormatException ef)
            {
                Console.WriteLine(ef.Message);
                CatchException.ReadInt(msg);
            }
            return value;
        }

        public static float ReadFloat(string msg)
        {
            float value = 0;
            Console.Write(msg);
            try
            {
                value = int.Parse(Console.ReadLine());
            }
            catch (FormatException ef)
            {
                Console.WriteLine(ef.Message);
                CatchException.ReadInt(msg);
            }
            return value;
        }

    }
}
