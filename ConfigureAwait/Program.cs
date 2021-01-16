using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConfigureAwait
{
    class MyCustomSynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            Console.WriteLine("Running on synchronization context");
            base.Post(d, state);
        }
    }

    internal static class Program
    {
        private static async Task Main()
        {
            SynchronizationContext.SetSynchronizationContext(new MyCustomSynchronizationContext());

            Console.WriteLine("Running with configureAwait=true");
            await Task.Delay(100).ConfigureAwait(true);

            Console.WriteLine("\nRunning with configureAwait=false");
            await Task.Delay(100).ConfigureAwait(false);
            
            Console.WriteLine("\nRunning with configureAwait=false with await inside await");
            await RunAsync().ConfigureAwait(false);
        }

        private static async Task RunAsync()
        {
            await Task.Delay(100).ConfigureAwait(true);
        }
    }
}