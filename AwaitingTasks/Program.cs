using System;
using System.Threading;
using System.Threading.Tasks;

namespace AwaitingTasks
{
    static class Program
    {
        private static async Task Main()
        {
            Console.WriteLine($"Running non real-async method - {Thread.CurrentThread.ManagedThreadId}");
            await NonRealAsyncMethod();

            Console.WriteLine($"\nRunning real-async method - {Thread.CurrentThread.ManagedThreadId}");
            await AsyncMethod();

            Console.WriteLine($"\nRunning task.run method - {Thread.CurrentThread.ManagedThreadId}");
            await TaskRunNonAsyncCode();
        }

        private static async Task AsyncMethod()
        {
            Console.WriteLine($"Before async code - {Thread.CurrentThread.ManagedThreadId}");
            // Run async method
            await Task.Delay(100);
            Console.WriteLine($"After async code - {Thread.CurrentThread.ManagedThreadId}");
        }

        private static async Task NonRealAsyncMethod()
        {
            Console.WriteLine($"Before async code - {Thread.CurrentThread.ManagedThreadId}");
            // Run non-async method
            Thread.Sleep(100);
            Console.WriteLine($"After sleep code - {Thread.CurrentThread.ManagedThreadId}");
        }

        private static Task TaskRunNonAsyncCode()
        {
            // Runs the code in new Task
            return Task.Run(() =>
            {
                Console.WriteLine($"Before async code - {Thread.CurrentThread.ManagedThreadId}");
                // Run non-async method
                Thread.Sleep(100);
                Console.WriteLine($"After async code - {Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}