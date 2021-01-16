using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ValueTasks
{
    internal static class Program
    {
        private static async Task Main()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await MaybeRunTask(true);
            Console.WriteLine($"Task with true: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();
            await MaybeRunValueTask(true);
            Console.WriteLine($"ValueTask with true: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();
            await MaybeRunTask(false);
            Console.WriteLine($"Task with false: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();
            await MaybeRunValueTask(false);
            Console.WriteLine($"ValueTask with false: {stopwatch.ElapsedMilliseconds}");
        }

        private static async Task<int> MaybeRunTask(bool shouldIRun)
        {
            if (shouldIRun)
                return 0;

            await Task.Delay(100);
            return 5;
        }
        
        private static async ValueTask<int> MaybeRunValueTask(bool shouldIRun)
        {
            if (shouldIRun)
                return 0;

            await Task.Delay(100);
            return 5;
        }
    }
}