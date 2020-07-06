using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace StringSearchApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string greeting = "Good Morning, Good";
            Console.WriteLine(greeting);

            Console.WriteLine($"IndexOf 'Good' : {greeting.IndexOf("Good")}");
            Console.WriteLine($"IndexOf 'Hood' : {greeting.IndexOf("Hood")}");  //없으면 -1
            Console.WriteLine($"IndexOf 'Morning' : {greeting.IndexOf("Morning")}");

            Console.WriteLine($"LastIndexOf 'Good' : {greeting.LastIndexOf("Good")}");

            Console.WriteLine($"IndexOf 'n' : {greeting.IndexOf('n')}");
            Console.WriteLine($"LastIndexOf 'n' : {greeting.LastIndexOf('n')}");

            //StartsWith
            WriteLine($"StartsWith 'Good' : {greeting.StartsWith("Good")}");    //시작하는 단어가 맞으면 True
            WriteLine($"StartsWith 'Morning' : {greeting.StartsWith("Morning")}");

            //Contains
            WriteLine($"Contains 'Good' : {greeting.Contains("Good")}");

            //Replace
            WriteLine($"Replace 'Morning' to 'Evening' : " +
                $"{greeting.Replace("Morning", "Evening")}");   //단어 바꾸는 것

            if(greeting.Contains("Morning"))
            {
                greeting.Replace("Morning", "Evening");
            }

            WriteLine($"ToLower : {greeting.ToLower()}");
            WriteLine($"ToUpper : {greeting.ToUpper()}");

            WriteLine($"Insert : {greeting.Insert(greeting.IndexOf("Morning")-1 , " very")}");

            WriteLine($"Remove : '{"I don't Love You".Remove(2, 6)}'");

            WriteLine($"Trim : '{" No Space ".Trim()}'");
            WriteLine($"TrimStart : '{" No Space ".TrimStart()}'");
            WriteLine($"TrimEnd : '{" No Space ".TrimEnd()}'");

            string codes = "MSFT,GOOG,AMZN,AAPL, RHT";
            var result = codes.Split(',');
            foreach (var item in result)
            {
                WriteLine($"each item '{item.Trim()}'");    //,단위로 나눠서 공백 없애기
            }

            WriteLine($"substring : {greeting.Substring(0, 4)}");   //문자열 자르기
            WriteLine($"substing : {greeting.Substring(5)}");

            WriteLine(string.Format("{0}DEF", "ABC"));
            WriteLine(string.Format("{0,-10}DEF", "ABC"));
            WriteLine(string.Format("{0,10}DEF", "ABC"));

            DateTime dt = DateTime.Now;     //formating 종류 다양함
            WriteLine(string.Format("{0:yyyy-MM-dd HH:mm:ss}",dt)); //한국식
            WriteLine(string.Format($"{dt:yyyy-MM-dd HH:mm:ss}"));  //같은 식
            WriteLine(string.Format("{0:d/M/yyy HH:mm:ss}", dt));   //미국식 포맷팅
            WriteLine(string.Format("{0:y yy yyy yyyy}",dt));
            WriteLine(string.Format("{0:M MM MMM MMMM}", dt));
            WriteLine(string.Format("{0:d dd ddd dddd}", dt));
            WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("ko-KR"))); //ToString으로 사용가능
            WriteLine(dt.ToString("d-M-yyyy HH:mm:ss", new CultureInfo("en-US")));   //나라별로 바꿀 수 있음

            decimal mvalue = 27000000m;
            WriteLine(string.Format("price {0:C}", mvalue));    //C -> 돈표시
            WriteLine(string.Format($"price {mvalue:C}"));      //같은 식
            WriteLine(mvalue.ToString("C", new CultureInfo("en-US")));  //ToString 나라별로 변경 가능
            WriteLine(mvalue.ToString("C", new CultureInfo("fr-FR")));
            WriteLine(mvalue.ToString("C", new CultureInfo("ja-JP")));

        }
    }
}
