using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace IntegerType
{
    class Program
    {
        static void Main(string[] args)
        {
            //sbyte a = sbyte.MaxValue;
            //byte b = byte.MaxValue;

            //short c = short.MinValue;
            //ushort d = ushort.MaxValue;

            //int e = int.MaxValue;
            //uint f = uint.MaxValue;

            //long g = long.MaxValue;
            //ulong h = ulong.MaxValue;
            //ulong i = 20_000_000_000;
            //Console.WriteLine(i);

            byte a = 240;
            WriteLine($"a = {a}");

            byte b = 0b1111_0000;
            WriteLine($"b = {b}");

            byte c = 0xf0;
            WriteLine($"c = {c}");

            byte d = byte.MaxValue;
            WriteLine($"d = {d}");
            d += 1;                 //오버플로우 발생
            WriteLine($"d = {d}");  //원하는 값 안나옴

            float f = float.MaxValue;
            double g = double.MaxValue;
        }
    }
}
