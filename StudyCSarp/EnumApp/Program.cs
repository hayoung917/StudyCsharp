using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumApp
{
    class Program
    {
        enum DialogResult
        {
            YES = 10,   //값 지정 가능
            NO = 20,
            CANCEL = 30,
            CONFIRM = 40,
            OK = 50
        }
        static void Main(string[] args)
        {
            //Console.WriteLine(DialogResult.OK);
            //Console.WriteLine((int)DialogResult.OK);

            DialogResult result = DialogResult.YES;
            if(result == DialogResult.YES)      //열거형 비교하는 방법
            {
                Console.WriteLine("YES를 선택했습니다.");
            }
        }
    }
}
