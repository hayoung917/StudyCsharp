using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingArryList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            for (int i = 0; i < 10; i++)
            {
                //list.Add(i);        //리스트 마지막에 값 추가
                int iresult = list.Add(i);
                Console.WriteLine($"{iresult}번째에 데이터 {i}추가완료"); //필요할때마다 log날리기 가능
            }

            list.Remove(2);         //인덱스 2번 자리 삭제
            list.Insert(5, 4.5);    //인덱스 위치 값 추가
            list.Clear();           //배열 비우기(전체 삭제)
            Console.WriteLine("After Clear()");

            foreach (var item in list)
            {
                Console.Write($"{item}, ");
            }
            Console.WriteLine();

            

            
        }
    }
}
