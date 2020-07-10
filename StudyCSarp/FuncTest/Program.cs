using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FuncTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int> func1 = () => 10; //Func -> 결과반환 대리자
                                        //매개변수 없는 경우 ()로 사용
            Console.WriteLine($"func1() : {func1()}");

            Func<int, int> func2 = (x) => { return x * 2; };    //<int,int> 입력 int, 반환 int
            Console.WriteLine($"func2(4) : {func2(4)}");

            try
            {
                Func<double, double, int> func3 = (x, y) => // <input, input, out>
                {
                    if (y == 0)
                    {
                        throw new Exception($"Divide by zero!\nYour input data -> x = {x}, y = {y}");
                    }
                    return (int)(x / y);
                };


                Console.WriteLine($"func3() = {func3(22, 7)}");
                Console.WriteLine($"Type of func3 = {func3}");
                Console.WriteLine($"func3() = {func3(22, 0)}");
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error : {ex.Message}");
            }

        }
    }
}

