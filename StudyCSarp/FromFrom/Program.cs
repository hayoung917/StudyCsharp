using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FromFrom
{
    class Subject
    {
        public string Name { get; set; }
        public int[] Score { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Subject> subjects = new List<Subject>
            {
                new Subject {Name = "가람반", Score = new int[] {99,80,70,24,52}},
                new Subject {Name = "하영반", Score = new int[] {60,45,87,72}},
                new Subject {Name = "예지반", Score = new int[] {92,30,85,94}},
                new Subject {Name = "동욱반", Score = new int[] {99,88,0 }},
            };

            var newSubjects = from s in subjects
                              from d in s.Score
                              where d < 60
                              orderby d
                              select new { s.Name, Lowest = d };

            foreach (var item in newSubjects)
            {
                Console.WriteLine($"낙제 : {item.Name}, {item.Lowest}");
            }
        }
    }
}
