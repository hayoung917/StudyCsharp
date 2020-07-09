using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingThrow
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoSomthing(1);
                DoSomthing(2);
                DoSomthing(9);
                DoSomthing(12);     //10보다 큰 값이면 예외 발생만들어야함
            }
            catch (Exception ex)
            {
                Console.WriteLine($"예외발생 : {ex.Message}");
                Console.WriteLine($"도움말링크 : {ex.HelpLink}");
                Console.WriteLine($"소스 : {ex.Source}");
            }
            finally
            {
                Console.WriteLine("에러가 있든 없든 수행");
            }
        }

        private static void DoSomthing(int arg)
        {
            if (arg < 10)
                Console.WriteLine($"arg : {arg}");
            else
                throw new Exception("arg가 10보다 큽니다")
                {
                    HelpLink = "https://www.google.com",
                    Source = "UsingThrow line 30",
                };
        }
    }
}
