using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    abstract class AbstractBase     //인터페이스는 구현이 없지만 abstract와 virtual은 구현이 있음
    {
        protected void protectedMethodA()
        {
            Console.WriteLine("AbstractBase.protectedMethodA()");
        }

        public void PublicMethodA()
        {
            Console.WriteLine("AbstractBase.PublicMethodA()");
        }

        public abstract void AbstractMethodA();
    }

    class Derived : AbstractBase
    {
        public override void AbstractMethodA()
        {
            Console.WriteLine("Derived.AbstractMethodA()");
            protectedMethodA();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AbstractBase obj = new Derived();   //추상클래스는 new못함 그래서 Derived가져옴
            obj.AbstractMethodA();
            obj.PublicMethodA();
        }
    }
}
