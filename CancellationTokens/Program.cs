using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationTokens
{
    internal static class Program
    {
        private static void Main()
        {
            var cancellationTokenSource = new CancellationTokenSource();

            Task _ = RunLongTask(cancellationTokenSource.Token);

            Thread.Sleep(400);
            cancellationTokenSource.Cancel();

            Console.WriteLine($"Task is canceled: {_.IsCanceled}");
        }

        private static async Task RunLongTask(CancellationToken cancellationToken)
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100, cancellationToken);

                if (cancellationToken.IsCancellationRequested)
                {
                    return;
                }

                Console.WriteLine($"Keep running: {i}");
            }
        }
    }
}