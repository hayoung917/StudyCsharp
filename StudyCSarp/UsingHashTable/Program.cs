using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingHashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();     
            ht["이름"] = "이하영";
            ht["주소"] = "부산광역시 해운대구";
            ht["전화번호"] = "010-1234-1234";
            ht["키"] = 160.5;
            ht["결혼여부"] = false;

            Console.WriteLine(ht["키"]);

        }
    }
}
