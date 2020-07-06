using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //int a = null;       //정수, 숫자 null 허용안함
            int? b = null;        //?표시로 사용가능
            double? c = null;
            float? d = null;
            string s = null;

            Console.WriteLine(b.HasValue);
            Console.WriteLine(c == null);
            Console.WriteLine(s == null || s == "");        //string은 HashValue사용 못함
            Console.WriteLine(string.IsNullOrEmpty(s));     //문자열에서 null확인 함수 있음
            Console.WriteLine(string.IsNullOrWhiteSpace(s));//" " 빈 공간 메소드

            //Console.WriteLine(b.Value); //값이 없어서 에러남
            if(b.HasValue)
            {
                Console.WriteLine(b.Value);
            }

            c = 3.141592;
            if(c.HasValue)
            {
                Console.WriteLine($"c = {c.Value}");
            }
        }
    }
}
