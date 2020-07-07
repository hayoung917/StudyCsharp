using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTypeCasting
{
    class Program
    {
        class Mammal    //포유류
        {
            public void Nurse()
            {
                Console.WriteLine("Nurse()");
            }
        }

        class Dog : Mammal
        {
            public void Bark()
            {
                Console.WriteLine("Bark()");
            }
        }

        class Cat : Mammal
        {
            public void Meow()
            {
                Console.WriteLine("Meow()");
            }
        }
        static void Main(string[] args)
        {
            Mammal mammal = new Dog();
            Dog dog;

            if(mammal is Dog)       //is as 같이 써서 형변환이 더 나음.
            {
                dog = mammal as Dog;
                dog.Bark();
            }
        }
    }
}
