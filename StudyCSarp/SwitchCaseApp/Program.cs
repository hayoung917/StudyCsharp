﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchCaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            object obj = null;
            string s = Console.ReadLine();
            if (int.TryParse(s, out int out_i))
                obj = out_i;
            else if (float.TryParse(s, out float out_f))
                obj = out_f;
            else
                obj = s;

            switch (obj)
            {
                case int i:
                    Console.WriteLine($"{i}는 int 형식");
                    break;
                case float f when f >= 0:       //f를 when으로 나눠서 사용할 수 있음
                    Console.WriteLine($"{f}는 0보다 큰 float 형식");
                    break;
                case float f:
                    Console.WriteLine($"{f}는 0보다 작은 float 형식");
                    break;

                default:
                    Console.WriteLine($"{obj}는 모르는 형식");
                    break;
            }
        }
    }
}
