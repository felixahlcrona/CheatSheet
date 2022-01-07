using CheatSheet.Model;
using Serilog;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DayOfWeek = CheatSheet.Model.DayOfWeek;

namespace CheatSheet
{
   public class Program
    {
        private static string _startupPath = AppDomain.CurrentDomain.BaseDirectory;
        static async Task Main(string[] args)
        {

            SeriLogExample("write to log");

            Task task1 = Task.Factory.StartNew(() => ThreadedTask("task1"));
            Task task2 = Task.Factory.StartNew(() => ThreadedTask("task2"));

            Console.WriteLine();
            Console.Read();
        }

      
        public static double CalculatorAddTest(double x, double y)
        {
            return x + y;
        }
        public static string StringReturnNameTest(string x)
        {
            return x;
        }

        public static void AnonymousType()
        {
            var student = new { Id = 1, FirstName = "James" };
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

        public static async Task ThreadedTask(string thread)
        {
            for (int i = 0; i < 10; i++)
            {
                HttpClient _client = new HttpClient();
                var res = await _client.GetAsync("http://www.google.com/");

                Console.WriteLine($"Get request done from {thread}");
            }


        }

        public static void FindColumnBySQlTable()
        {
            
            // Går att söka efter kolumn i hela databasen.

            //SELECT Table_Name, Column_Name 
            //FROM INFORMATION_SCHEMA.COLUMNS
            //WHERE TABLE_CATALOG = 'databasename'
            //AND COLUMN_NAME LIKE '%column%'
        }
    }
}
