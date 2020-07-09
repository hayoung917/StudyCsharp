using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintsOnTypeParameters
{
    class StructArray<T> where T : struct   // where T : struct(T는 값형식만 가능하다)
    {
        public T[] Array { get; set; }
        public StructArray(int size)
        {
            Array = new T[size];
        }
    }

    class RefArray<T> where T : class       //구조체 int 값형식은 할 수 없다
    {
        public T[] Array { get; set; }
        public RefArray(int size)
        {
            Array = new T[size];
        }
    }

    class Base { }
    class Derived : Base { }

    class BaseArray<U> where U : Base   //U는 Base클래스만 사용가능하다
    {
        public U[] Array { get; set; }

        public BaseArray(int size)
        {
            Array = new U[size];
        }

        public void CopyArray<T>(T[] source) where T: U  //where T:Base로 써도 상관없다
        {
            source.CopyTo(Array, 0);
        }
    }

    class Program
    {
        public static T CreatedInstance<T>() where T : new()    //파라미터가 없는 생성자로 작업해야한다
        {
            return new T();
        }
        static void Main(string[] args)
        {
            StructArray<int> a = new StructArray<int>(3);
            a.Array[0] = 0;
            //StructArray<string> b = new StructArray<string>(3); 값형식만 가능하기때문에 string 안됨

            //RefArray<>
            RefArray<string> b = new RefArray<string>(3);
            b.Array[0] = "hello";

            RefArray<StructArray<double>> e = new RefArray<StructArray<double>>(3); //string을 double로 변환
            e.Array[1] = new StructArray<double>(5);

            BaseArray<Base> c = new BaseArray<Base>(3);
            c.Array[0] = new Base();
            c.Array[1] = new Derived();
            c.Array[2] = CreatedInstance<Derived>();
            BaseArray<Derived> d = new BaseArray<Derived>(3);
        }
    }
}
