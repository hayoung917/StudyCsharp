using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property
{
    class BirthdayInfo
    {
        private string name;
        private DateTime birthday;

        //public void SetName(string name)      //옛날방식
        //{
        //    this.name = name;
        //}

        //public string GetName()
        //{
        //    return this.name;
        //}
        //public void SetBirthday(DateTime birth)
        //{
        //    this.birthday = birth;
        //}

        //public DateTime GetBirthday()
        //{
        //    return this.birthday;
        //}

        public string Name { get; set; } = "Unknown";      //줄여서 사용가능, 초기화 가능

        //public string Name
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        name = value;
        //    }
        //}

        public DateTime Birthday { get; set; } = new DateTime(1990, 1, 1);  //쓰레기값 방지 초기화

        //public DateTime Birthday
        //{
        //    get
        //    {
        //        return birthday;
        //    }
        //    set
        //    {
        //        if (value.Year >= DateTime.Now.Year)
        //        {
        //            Birthday = DateTime.Now;
        //        }
        //        else
        //        {
        //            birthday = value;
        //        }
        //    }
        //}

        public int Age
        {
            get
            {
                return new DateTime(DateTime.Now.Subtract(birthday).Ticks).Year;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BirthdayInfo info = new BirthdayInfo();

            //info.SetName("이하영");
            //info.SetBirthday(new DateTime(1993, 9, 17));

            //Console.WriteLine($"Name : {info.GetName()}");
            //Console.WriteLine($"Birthday : {info.GetBirthday()}");

            info.Name = "이하영";
            info.Birthday = new DateTime(1993, 9, 17);

            Console.WriteLine($"Name : {info.Name}");
            Console.WriteLine($"Birthday : {info.Birthday}");
            Console.WriteLine($"Age : {info.Age}");

            var myInstance = new { Name = "이하영", Home = "부산"};
            Console.WriteLine($"{myInstance.Name} / {myInstance.Home}");
            //myInstance.Home = "서울"; //변경 불가능 가져다 쓰는 것만 가능

            var b = new { Subject = "수학", Scores = new int[] { 99, 88, 77 } };
            Console.WriteLine($"{b.Subject}");
            foreach (var item in b.Scores)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
