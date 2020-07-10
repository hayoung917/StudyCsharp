using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLinq
{
    class Profile
    {
        public string Name { get; set; }
        public int Height { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Profile> profiles = new List<Profile>
            {
                new Profile {Name = "김가람", Height = 166},
                new Profile {Name = "여예지", Height = 163},
                new Profile {Name = "이하영", Height = 160},
                new Profile {Name = "오동욱", Height = 168},
                new Profile {Name = "백규현", Height = 165},
            };

            var newProfiles = from item in profiles
                              where item.Height < 165
                              orderby item.Height
                              select new
                              {
                                  Name = item.Name,
                                  InchHeight = item.Height * 0.393
                              };

            foreach (var item in newProfiles)
            {
                Console.WriteLine($"{item.Name},{item.InchHeight} inch");
            }
        }
    }
}
