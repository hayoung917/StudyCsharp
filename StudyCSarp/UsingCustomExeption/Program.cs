using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingCustomExeption
{
    class InvalidArgumentException : Exception
    {
        public object Argument { get; set; }
        public string Range { get; set; }

        public InvalidArgumentException()
        {
            
        }

        public InvalidArgumentException(string message):base(message)
        {
            
        }
    }
    class Program
    {
        static uint MergeARGB(uint alpha, uint red, uint green, uint blue)
        {
            uint[] args = new uint[] { alpha, red, green, blue };

            foreach (uint arg in args)
            {
                if (arg > 255)
                    throw new InvalidArgumentException()
                    {
                        Argument = arg,
                        Range = "0~255"
                    };
            }

            return (alpha << 24 & 0xff000000) |
                (red << 16 & 0x00ff0000) |
                (green << 8 & 0x0000ff00) |
                (blue & 0x000000ff);
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"0x{MergeARGB(255, 111, 111, 111):x}");
                Console.WriteLine($"0x{MergeARGB(1, 65, 192, 128):x}");
                Console.WriteLine($"0x{MergeARGB(0, 255, 255, 300):x}");
            }
            catch (InvalidArgumentException ex)
            {
                Console.WriteLine($"예외발생 : {ex.Message}");
                Console.WriteLine($"Argument:{ex.Argument}, 입력범위 : {ex.Range}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
