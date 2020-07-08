using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiInterfaceInheritance
{
    class Program
    {
        interface IRunnable
        {
            void Run();
        }

        interface IFlyable
        {
            void Fly();
        }

        interface IWalkable
        {
            void Run();
        }

        class Vehicle
        {
            public string Year;
            public string Company;
            public float HorsePower;
        }

        class FlyingCar : Vehicle, IRunnable, IFlyable, IWalkable   //클래스 하나에 여러개 인터페이스 사용할 수 있음
        {
            public void Fly()
            {
                Console.WriteLine("Fly!");
            }

            public void Run()                    //IWalkable도 Run() 함수를 가지고 있기때문에 또 만들어줄 필요가 없다
                                                 //매개변수나 함수가 달라질 경우엔 따로 만들어 줘야함
            {
                Console.WriteLine("Run!");
            }
        }
        static void Main(string[] args)
        {
            FlyingCar car = new FlyingCar();
            car.Run();
            car.Fly();
            car.Company = "현대";

            IRunnable runnable = car as IRunnable;  //형변환 안되면 null값 들어감
            runnable.Run();

            IFlyable flyable = car as IFlyable;
            flyable.Fly();

            IWalkable walkable = car as IWalkable;
            walkable.Run();
        }
    }
}
