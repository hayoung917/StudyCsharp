using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingYield
{
    class MyEnumerator
    {
        int[] NumberStyles = {1,2,3,4,5};
        public IEnumerator GetEnumerator()
        {
            yield return NumberStyles[0];
            yield return NumberStyles[1];
            yield return NumberStyles[2];
            //yield break;
            yield return NumberStyles[3];
            yield return NumberStyles[4];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new MyEnumerator();

            foreach (var item in obj)       //GetEnumerator가 없으면 foreach 사용못함 obj가 배열이나 콜렉션이어야함
            {
                Console.WriteLine(item);
            }
        }
    }
}
