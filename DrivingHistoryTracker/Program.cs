using System;
using System.IO;

namespace DrivingHistoryTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            //DELETE input.txt FILE BEFORE SUBMITTING
            if(args.Length > 0)
            {
                string[] fileContents = File.ReadAllLines(args[0]);
                if(fileContents.Length > 0)
                {
                    DrivingReportGenerator report = new DrivingReportGenerator(fileContents);
                    report.GenerateReport();
                }
                else
                {
                    Console.WriteLine("File contains no data! Try again with another file!");
                }
                
            }
            else
            {
                Console.WriteLine("Please specify a file to read!");
            }
            Console.ReadKey();
        }
    }
}
