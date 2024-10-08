﻿using CheatSheet.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using DayOfWeek = CheatSheet.Model.DayOfWeek;

namespace CheatSheet
{
    public class CheatSheet
    {
        private static string _startupPath = AppDomain.CurrentDomain.BaseDirectory;
        static async Task Main(string[] args)
        {
            // Get variable from appsettings in a azure function
            //%name%


            string nullable = null;


            Console.WriteLine(nullable.Length);
            Console.Read();
        }

        // Blazor serverside.
        //När du kör async metoder kan du behöva köra "await InvokeAsync(StateHasChanged);" för att uppdatera ui statet. 
        //    Men annars kan du leka runt med onrender/oninitalized beroende på när de ska renderas. 
        //    Alla metoder som inte behöver vara async ska var icke async, annars kan de bli fel där med
        // Också viktigt! Ibland om du ändrar saker i en list då känner inte blazor av ändringarna om de är en shallow copy t ex.

        // Härifrån sätts DeviceList
        //await GetDevicesAsync();

        //var x = DeviceList;
        //DeviceList = new List<DeviceViewModel>();
        //DeviceList.AddRange(x);
        // Så gör en helt ny lista och skriv över resultat i den, så de blir en deep copy. De reagerer blazor på.
        //https://imgur.com/a/3ql8yJv
        //https://steven-giesel.com/blogPost/4fd1ba1d-f244-460e-8de4-06f2cc9c19cb

        public static void NameOfJsonContains()
        {
            string jsonString =
                            @"{
                              ""Name"": ""Peter"",
                              ""Age"": 35
                            }
                            ";
            var jsonObj = JsonNode.Parse(jsonString).AsObject();

            //Typed Json value instead of jsonObj.ContainsKey("Name")
            if (jsonObj.ContainsKey(nameof(Person.Name)))
            {
                Console.WriteLine(jsonObj);
            }

        }

        public static async Task GetRequestAsync()
        {
            HttpClient client = new HttpClient();
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://catfact.ninja/fact");

                if (response.IsSuccessStatusCode)
                {
                    var responseMessage = await response.Content.ReadAsStringAsync();
                    var data = JsonSerializer.Deserialize<CatFacts>(responseMessage, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }
            }
            catch (Exception ex)
            {

            }
        }
        public static void NameOfExceptionHandling()
        {
            try
            {
                throw new Exception();
            }
            catch
            {
                // Typing return type instad of a hardcoded string.
                Console.WriteLine("Method failed: " + nameof(NameOfExceptionHandling));
                Console.WriteLine("Method failed: " + "NameOfExceptionHandling");
            }

        }
        private static int RandomNumber(int a, int b)
        {
            var number = Random.Shared.Next(a, b);
            return number;
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Shared.Next(s.Length)]).ToArray());
        }


        // använd System.Text.Json; nyaste.
        public static string JsonSerializeObject()
        {
            Person person = new Person() { Age = 19, Name = "Peter" };
            Person person2 = new Person() { Age = 29, Name = "Jonas" };
            string jsonObject = JsonSerializer.Serialize(person);


            List<Person> list = new List<Person>() { person, person2 };
            string jsonList = JsonSerializer.Serialize(list);

            return jsonObject;
        }

        public static Person JsonDeSerializeObject()
        {
            string jsonString =
                            @"{
                              ""Name"": ""Peter"",
                              ""Age"": 25
                            }
                            ";
            // Vanliga Newton jsoft är inte case sensitive men system.text är. Så lägg till den option
            Person person = JsonSerializer.Deserialize<Person>(jsonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
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


        public static void LINQWhereFilter()
        {
            Person person = new Person() { Age = 19, Name = "Peter" };
            Person person2 = new Person() { Age = 29, Name = "Jonas" };
            List<Person> list = new List<Person>() { person, person2 };

            // DO.
            var DO = list.First(e => e.Name == "Peter");
            //DONT.
            var DONT = list.Where(e => e.Name == "Peter").FirstOrDefault();
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

        public static void StringInterpolationStringFormat()
        {
            //            @foreach(var item in cultures)
            //        {
            //            < MudSelectItem Value = "@(item.Key)" >

            //                 < img src = "@String.Format(" /{ 0}.svg", item.Key)" height = "14" class="mr-1" /> @item.Value
            //</MudSelectItem>
            //    }

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
