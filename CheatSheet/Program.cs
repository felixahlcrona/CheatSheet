using System;
using System.Threading.Tasks;

namespace CheatSheet
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //General.NullCoalescingOperator();
          
                var res = await Async.ReturnAsyncInt();
                Console.WriteLine(res);
         
           
            //await HttpExamples.HttpClientGetGoogleImages();
            Console.Read();
        }
    }
}
