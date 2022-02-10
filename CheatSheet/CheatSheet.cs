using CheatSheet.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using DayOfWeek = CheatSheet.Model.DayOfWeek;

namespace CheatSheet
{
    public class CheatSheet
    {
        private static string _startupPath = AppDomain.CurrentDomain.BaseDirectory;
        static async Task Main(string[] args)
        {

            NullCoalescingOperator();

            LINQIntersect();
            //Task task1 = Task.Factory.StartNew(() => ThreadedTask("task1"));
            //Task task2 = Task.Factory.StartNew(() => ThreadedTask("task2"));

            Console.WriteLine();
            Console.Read();
        }



        // använd System.Text.Json; nyaste.
        public static string JsonSerializeObject()
        {
            Person person = new Person() { Age = 19, Name = "Peter" };

            string jsonString = JsonSerializer.Serialize(person);
            return jsonString;
        }

        public static Person JsonDeSerializeObject()
        {
            string jsonString =
                            @"{
                              ""Name"": ""Peter"",
                              ""Age"": 25
                            }
                            ";
            Person person = JsonSerializer.Deserialize<Person>(jsonString);
            return person;
        }


        // Sätt ihop två listor som har gemensama värden,
        // i detta fall kommer endast Jonas och Peter finnas i "results"
        public static void LINQIntersect()
        {
            IList<string> strList1 = new List<string>() { "Jonas", "Peter", "Max" };
            IList<string> strList2 = new List<string>() { "Jonas", "Peter", "Eva" };
            var result = strList1.Intersect(strList2);

            foreach (string str in result)
                Console.WriteLine(str);
        }


        // Sätter ihop alla värden från två listor till en lista
        // Resultat blir Eva,Peter,Max
        public static void LINQConcat()
        {
            IList<string> collection1 = new List<string>() { "Eva", "Peter" };
            IList<string> collection2 = new List<string>() { "Max" };

            var collection3 = collection1.Concat(collection2);

            foreach (string str in collection3)
                Console.WriteLine(str);
        }



        // Generisk metod. Kan lägga till (int,int) i en lista eller (string, string) t ex.
        //ReturnGenricArray(32, 12);
        //ReturnGenricArray("hej", "hopp");
        public static List<T> ReturnGenricArray<T>(T elementOne, T elementTwo)
        {
            List<T> result = new List<T>();
            result.Add(elementOne);
            result.Add(elementTwo);
            return result;
        }

        public static void DateAndTimeOnly()
        {
            // C# 10, få ut endast date eller bara tid utav en datetime
            DateTime dateTime = DateTime.Now;

            DateOnly dateOnly = DateOnly.FromDateTime(dateTime);
            TimeOnly timeOnly = TimeOnly.FromDateTime(dateTime);

        }

        public static void ObjectCreation()
        {
            var person0 = new Person();
            Person book1 = new Person();

            //C# 9 Feature
            // New way
            Person personNew = new();

        }
        public static void StringInterpolation()
        {
            string name = "Mark";
            var date = DateTime.Now;
            // Composite formatting:
            Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);
            // String interpolation:
            Console.WriteLine($"Hello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now.");
        }
        public static void AnonymousType()
        {
            var student = new { Id = 1, FirstName = "James" };
            Console.WriteLine(student.Id); //output: 1
            Console.WriteLine(student.FirstName); //output: James
        }
        public static void NullConditionalOperator()
        {
            // Använd ? innan för värden som kan vara NULL. Så om name inte finns så får man inget exception error
            Person person = null;
            var res = person?.Name;
        }

        public static void NullCoalescingOperator()
        {
            // Använd ?? för sätta null värden till default värde.
            Person person = null;
            var name = person?.Name ?? "default name";

        }
        public static void NullCoalescingForEach()
        {
            List<Person> persons = new List<Person>();

            foreach (var item in persons ?? Enumerable.Empty<Person>())
            {
                // Bra i Blazor om man försöker göra något med en tom lista.
            }

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

        public static double CalculatorAddTest(double x, double y)
        {
            return x + y;
        }
        public static string StringReturnNameTest(string x)
        {
            return x;
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
