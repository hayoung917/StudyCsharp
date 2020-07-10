using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicThread
{
    class Program
    {
        static void DoSomething()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"DoSomething : {i}");
                Thread.Sleep(1000);       //다른 스레드도 cpu를 사용할수 있도록 cpu점유를 내려놓는것
            }
        }

        static void DoAnything()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"DoAnything : {i}");
                Thread.Sleep(1000);       //다른 스레드도 cpu를 사용할수 있도록 cpu점유를 내려놓는것
            }
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(DoSomething)); //ThreadStart -> 대리자
            Thread thread1 = new Thread(new ThreadStart(DoAnything));

            Console.WriteLine("Starting Thread...");
            thread.Start();     //스레드 시작(DoSomething 호출) 대리자
            thread1.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main : {i}");
                Thread.Sleep(500);
            }

            Console.WriteLine("Wating until thread stops...");
            thread.Join();      //스레드 종료대기
            thread1.Join();

            Console.WriteLine("Finished");
           
        }
    }
}
