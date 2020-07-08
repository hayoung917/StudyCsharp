using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingGenericClass
{
    class MyList<T> : IEnumerable
    {
        private T[] array;

        public MyList()
        {
            array = new T[3];
        }

        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                if(index >= array.Length)
                {
                    Array.Resize<T>(ref array, index + 1);        //인덱서로 배열 사이즈를 늘려줄 수 있음
                    Console.WriteLine($"Array resized : {array.Length}");
                }
                array[index] = value;
            }
        }
        public int Length
        {
            get { return array.Length; }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyList<string> strList = new MyList<string>();
            strList[0] = "abc";
            strList[1] = "def";
            strList[2] = "ghi";
            strList[3] = "jkl";

            //for (int i = 0; i < strList.Length; i++)
            //{
            //    Console.WriteLine(strList[i]);
            //}

            foreach (var item in strList)       //IEnumerable 사용시 foreach 사용가능
            {
                Console.WriteLine($"{item}");
            }

            MyList<float> floatList = new MyList<float>();
            floatList[0] = 12.4f;
            floatList[1] = 3.141592f;

            for (int i = 0; i < floatList.Length; i++)
            {
                Console.WriteLine(floatList[i]);
            }
        }
    }
}
