using System;
using System.Threading.Tasks;

namespace AsyncVoid
{
    static class Program
    {
        private static async Task Main()
        {
            try
            {
                // Awaiting a task that had an exception will result in throwing it in the calling code
                await ThrowExceptionAsync();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("oops");
            }

            try
            {
                // There is no Task to await here, hence no exception will be caught
                ThrowExceptionAsyncVoid();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("This time I will catch you!");
            }
        }

        private static async Task ThrowExceptionAsync()
        {
            await Task.Delay(100);
            throw new DivideByZeroException("oops");
        }

        private static async void ThrowExceptionAsyncVoid()
        {
            await Task.Delay(100);
            throw new DivideByZeroException("oops");
        }
    }
}