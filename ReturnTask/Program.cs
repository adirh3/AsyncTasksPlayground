using System.Threading.Tasks;

namespace ReturnTask
{
    /// <summary>
    /// When running an "async" method, the compiler creates a state machine class for managing the context switching
    /// </summary>
    static class Program
    {
        /// <summary>
        /// This is an async method, so the compiler will create a state machine for it
        /// </summary>
        private static async Task Main()
        {
            // To see the state machines look at "Parallel Stacks" in the debugger

            // Run async method
            await RunAwait();

            // Runs non-async method
            await ReturnTask();
        }

        /// <summary>
        /// This is an async method, so the compiler will create a state machine for it
        /// </summary>
        private static async Task RunAwait()
        {
            await Task.Delay(500);
        }

        /// <summary>
        /// This is non-async method, no state machine will be created
        /// </summary>
        private static Task ReturnTask()
        {
            return Task.Delay(500);
        }
    }
}