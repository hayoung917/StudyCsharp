using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambda
{
    class Program
    {
        delegate int Calculate(int a, int b);   //익명 메소드를 만들려면 대리자 필요
        static void Main(string[] args)
        {
            Calculate calc = (a, b) => a + b;   //람다 식
                                                //C#컴파일러는 대리자의 선언 코드로부터 람다식이 만드는 
                                                //익명 메소드의 매개변수 형식 유추함

            Console.WriteLine($"{3} + {2} = {calc(3, 2)}");
        }
    }
}
