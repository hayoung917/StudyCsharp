using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingFrom
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 9, 2, 6, 4, 5, 3, 7, 8, 1, 10 };
            //IEnumerable<int> result = from n in numbers
            //                          select n;
            var result = from n in numbers
                         where n % 2 == 0
                         orderby n ascending
                         select n;

            //result가 IEnumerable형태이기 때문에 foreach사용 가능
            foreach (var item in result)
            {
                Console.WriteLine($"짝수 : {item}");
            }
        }
    }
}
