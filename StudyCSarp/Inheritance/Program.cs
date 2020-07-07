using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Parent
    {
        protected string Name { get; set; }

        public Parent(string name)
        {
            Name = name;
            Console.WriteLine($"{Name}.Base()");
        }

        public void BaseMethod()
        {
            Console.WriteLine($"{Name}.BaseMethod()");
        }
    }

    class Child : Parent
    {
        public Child(string name) : base(name)
        {
            Console.WriteLine($"{Name}.Child();");
        }

        public void ChildMethod()
        {
            base.BaseMethod();
            Console.WriteLine($"{Name}.ChildMethod()");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Parent p = new Parent("p");
            p.BaseMethod();
            Child c = new Child("c");
            c.BaseMethod();
            Console.WriteLine("------------------");
            c.ChildMethod();


        }
    }
}
