using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice2
{
    class MainApp
    {
        public static void Mean(double a, double b, double c, double d, double e, double mean)
        {
            double result = (a + b + c + d + e + mean) / 5;
            Console.WriteLine($"평균 : {result}");
        }
        public static void Main(string[] args)
        {
            double mean = 0;
            Mean(1, 2, 3, 4, 5, mean);
        }
    }
}
