using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatementLambda
{
    class Program
    {
        delegate string Concatenate(string[] arg);

        static void Main(string[] args)
        {
            #region 불필요한 부분 주석처리
            Concatenate concat = (arr) =>
            {
                //에러 빨간줄 생길땐 return ""; 써놓고 퇴근하기
                string result = string.Empty;  //"";
                foreach (string item in arr)
                {
                    result += $"{item}";    //포맷팅
                }
                return result;
            };
            #endregion
            Console.WriteLine(concat(args));
        }
    }
}
