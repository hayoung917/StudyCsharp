using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    // 구현이 없고 선언만 있다
    interface ILogger
    {
        void WriteLog(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void WriteLog(string message)
        {
            DateTime now = DateTime.Now;

            Console.WriteLine($"[{now.ToLocalTime()}] {message}");
        }
    }

    class FileLogger : ILogger
    {
        private StreamWriter writer;

        public FileLogger(string path)
        {
            writer = File.CreateText(path);
            writer.AutoFlush = true;
        }

        public void WriteLog(string message)
        {
            DateTime now = DateTime.Now;
            // 위에서 생성한 파일에 값을 write
            writer.WriteLine($"[{now.ToLocalTime()}] {message}");
        }
    }

    class ClimateMonitor
    {
        private ILogger logger;

        public ClimateMonitor(ILogger logger)
        {
            this.logger = logger;
        }

        public void start()
        {
            while (true)
            {
                Console.Write("온도 입력 : ");
                string temp = Console.ReadLine();

                if (temp == "q")
                    break;

                logger.WriteLog("현재 온도 : " + temp);
            }
        }
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            // climate.log 라는 이름의 txt파일 생성
            ClimateMonitor monitor = new ClimateMonitor(new FileLogger("climate.log"));

            // 콘솔창에 입력한 데이터 출력
            //ClimateMonitor monitor = new ClimateMonitor(new ConsoleLogger());
            monitor.start();
        }
    }
}