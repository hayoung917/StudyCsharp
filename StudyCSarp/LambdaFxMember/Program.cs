using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaFxMember
{
    class FriendList
    {
        private List<string> list = new List<string>();

        public void Add(string name) => list.Add(name);
        public void Remove(string name) => list.Remove(name);
        public void PrintAll()
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        public FriendList() => Console.WriteLine("FriendList()");

        //public int Capacity => list.Capacity; // 읽기전용

        public int Capacity     //속성
        {
            get => list.Capacity;
            set => list.Capacity = value;
        }

        //public string this[int index] => list[index];   //일기전용

        public string this[int index]
        {
            get => list[index];
            set => list[index] = value;
        }
    }

    
    class Program
    {
        static void Main(string[] args)
        {
            FriendList obj = new FriendList();
            obj.Add("Emey");
            obj.Add("Meeny");
            obj.Add("Hyory");
            obj.Add("Emey");
            obj.PrintAll();
            Console.WriteLine("-----");
            obj.Remove("Emey");
            obj.PrintAll();

            Console.WriteLine($"obj Capacity : {obj.Capacity}");
            obj.Capacity = 10;
            Console.WriteLine("----");
            obj[0] = "LHY";
            obj.PrintAll();

        }
    }
}
