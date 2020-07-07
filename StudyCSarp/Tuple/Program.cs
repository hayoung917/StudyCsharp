using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            ////명명되지 않은 튜플
            //var a = ("슈퍼맨", 9999,"크립톤");
            //Console.WriteLine($"{a.Item1}, {a.Item2}, {a.Item3}");  //튜플 수 만큼 ItemN 나옴
            //Console.WriteLine($"{a.Item1.GetType()}, {a.Item2.GetType()}, {a.Item3.GetType()}");

            ////명명된 튜플
            //var b = (Name: "이하영", Age: 28, Home: "부산");
            //Console.WriteLine($"{b.Name}, {b.Age}, {b.Home}");

            //b = a;
            //Console.WriteLine($"{b.Name}, {b.Age}, {b.Home}");

            ////분해
            //var (name, age, home) = b;
            //Console.WriteLine($"{name},{age},{home}");

            var (name, age, home) = GetInfo();
            Console.WriteLine($"{name},{age},{home}");
        }

        static Tuple<string, int, string> GetInfo()
        {
            return new Tuple<string, int, string>("이하영", 28, "부산");
        }
    }
}
