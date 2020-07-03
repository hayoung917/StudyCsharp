using static System.Console;  //Console.WriteLine에서 콘솔 생략가능

namespace HelloApp
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                WriteLine("ex: HelloApp.exe<이름>");
                return;
            }
            WriteLine($"Hello, {args[0]}!");
        }
    }
}
