using System;
using CheatSheet.Model;
using Serilog;

namespace CheatSheet
{
    class General
    {
        private static string _startupPath = AppDomain.CurrentDomain.BaseDirectory;

        enum DayOfWeek
        {
            Monday,
            Friday
        }

        public static void AnonymousType()
        {
            var student = new { Id = 1, FirstName = "James"};
            Console.WriteLine(student.Id); //output: 1
            Console.WriteLine(student.FirstName); //output: James
        }
        public static void NULLConditionalOperator()
        {
            // Använd ? innan för värden som kan vara NULL
            Person person = null;
            var res = person?.Name;
        }


        public static void NullCoalescingOperator()
        {
            // Använd ?? för sätta null värden till default värde.
            Person person = null;
            var name = person?.Name ?? "default name";
        }
        public static void TernaryOperator()
        {
            //Kortare variant av if else
            int x = 20, y = 10;
            var result = x > y ? "x is greater than y" : "x is less than y";

            Console.WriteLine(result);
            //x is greater than y
        }



        static (string name, int age) NamedTuples()
        {
            var name = "John hopkinss";
            var age = 33;
            return (name, age);
        }

        static string InlineSwitch(DayOfWeek day)
        {
            var res = "";
            switch (day)
            {
                case DayOfWeek.Monday: res = "Fizz"; break;
                case DayOfWeek.Friday: res = "Buzz"; break;
            }
            return res;
        }



        public static void SeriLogExample(string message)
        {
            var log = new LoggerConfiguration()
          .MinimumLevel.Debug()
          .WriteTo.File(_startupPath + "Serilog\\LogFile.txt",
           rollOnFileSizeLimit: true, shared: true).CreateLogger();

            log.Information("LogMessage : {message} ", message);
        }



     
    }
}
