using System;

namespace StringNumberConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 12345;
            string b = a.ToString();
            Console.WriteLine($"b = {b}");

            float c = 3.141592f;
            string d = c.ToString();
            Console.WriteLine($"d = {d}");

            int f;
            string e = "123456*";
            if(int.TryParse(e, out f)) //제대로 파싱됐는지 모를때 불린으로 확인
            {
                Console.WriteLine($"f = {f}");
            }
            else
            {
                Console.WriteLine("f 변환시 에러발생, 문자열 확인 요망");
            }
           
            string g = "3.141592";
            float h = float.Parse(g);
            Console.WriteLine($"h = {h}");
        }
    }
}
