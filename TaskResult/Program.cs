using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskResult
{
    static class Program
    {
        private static async Task Main()
        {
            CallWithResult();
            await CallWithAwait();
        }

        /// <summary>
        /// Calling with Task.Result will block the current thread
        /// </summary>
        private static void CallWithResult()
        {
            Console.WriteLine("Task.Result Thread: " + Thread.CurrentThread.ManagedThreadId);
            // Option 1
            string status = CheckStatusAsync().Result;
            Console.WriteLine(status);

            Console.WriteLine("Task.Result Thread: " + Thread.CurrentThread.ManagedThreadId);

            // Option 2 equivalent to option 1
            Task<string> checkStatusAsync = CheckStatusAsync();
            checkStatusAsync.Wait();
            string status2 = checkStatusAsync.Result;
            Console.WriteLine(status2);
        }

        /// <summary>
        /// Calling with await will NOT block the current thread
        /// </summary>
        private static async Task CallWithAwait()
        {
            Console.WriteLine("Task Await Thread: " + Thread.CurrentThread.ManagedThreadId);
            string status = await CheckStatusAsync();
            Console.WriteLine(status);
            Console.WriteLine("Task Await Thread: " + Thread.CurrentThread.ManagedThreadId);
        }

        /// <summary>
        /// Everything seems to be ok, just need to check anyway
        /// </summary>
        private static async Task<string> CheckStatusAsync()
        {
            await Task.Delay(1000);
            return "OK";
        }
    }
}