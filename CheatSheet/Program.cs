using System;
using System.Threading;
using System.Threading.Tasks;

namespace CheatSheet
{
    class Program
    {
        static async Task Main(string[] args)
        {

            General.SeriLogExample("write to log");

            Task task1 = Task.Factory.StartNew(() => General.ThreadedTask("task1"));
            Task task2 = Task.Factory.StartNew(() => General.ThreadedTask("task2"));
            
    
            Console.WriteLine();
            Console.Read();
        }
    }
}
