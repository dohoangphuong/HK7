using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ass01_Opt2_Class_Simulation
{
    public class MyRandom
    {
        // Tham số truyền vào
        // Họ, đệm, tên và số lượng tên mong muốn 
        public static string[] RandomName(string[] lastNames,
            string[] middleNames,
            string[] firstNames,
            int n)
        {
            Random random = new Random();

            if (n > lastNames.Length * middleNames.Length * firstNames.Length)
            {
                return null;
            }

            string[] strTemps = new string[n];


            string strFullNameTemp = "";
            for (int i = 0; i < n; i++)
            {
                do
                {
                    // Chọn họ
                    string strLastNameTemp = lastNames[random.Next(0, lastNames.Length)];
                    // Chọn đệm
                    string strMiddleNameTemp = middleNames[random.Next(0, middleNames.Length)];
                    // Chọn tên
                    string strFirstNameTemp = firstNames[random.Next(0, firstNames.Length)];

                    strFullNameTemp = strLastNameTemp + " " +
                                      strMiddleNameTemp + " " +
                                      strFirstNameTemp;

                } while (strTemps.Contains(strFullNameTemp));

                strTemps[i] = strFullNameTemp;
            }

            return strTemps;
        }

        public static int[] RandomID(int n, int min, int max)
        {
            int[] intTemps = new int[n];

            int intRandomvalue = 0;

            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                do
                {
                    intRandomvalue = random.Next(min, max);
                } while (intTemps.Contains(intRandomvalue));

                intTemps[i] = intRandomvalue;
            }

            return intTemps;
        }

        public static DateTime[] RandomBirthday(int n, DateTime min, DateTime max)
        {
            Random random = new Random();

            TimeSpan time = max - min;

            DateTime dtmValueTemp = new DateTime();

            DateTime[] dtmTemps = new DateTime[n];

            for (int i = 0; i < n; i++)
            {
                do
                {
                    dtmValueTemp = min.AddDays(random.Next(0, time.Days));
                } while (dtmTemps.Contains(dtmValueTemp));

                dtmTemps[i] = dtmValueTemp;
            }

            return dtmTemps;
        }

        public static Dictionary<string, float>[] RandomScore(int n , int a, int b, int c, int d)
        {
            Dictionary<string, float>[] temps = new Dictionary<string, float>[n];

            Random random = new Random();
            string[] subjects = new[]
            {
                "Requirement analyze",
                "Software design",
                "Code and Unit Test",
                "FSoft Management Tool",
                "C# Programming"
            };

            foreach (string subject in subjects)
            {
                for (int i = 0; i < n; i++)
                {
                    do
                    {
                        temps[i][subject] = random.Next(0, 11);
                    } while (temps.Where(q => q[subject] >= 8 && q[subject] <= 10).Count() < a && 
                        temps.Where(q => q[subject] >= 5 && q[subject] <= 7).Count() < b &&
                        temps.Where(q => q[subject] >= 3&& q[subject] <= 4).Count() < c &&
                        temps.Where(q => q[subject] >= 1 && q[subject] <= 2).Count() < d &&
                        temps.Where(q => q[subject] == 0).Count() == 1);

                }
            }
            return temps;
        }

   
    }


}
