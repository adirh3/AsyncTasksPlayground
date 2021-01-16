using System;
using System.Threading.Tasks;

namespace ValueTasks
{
    internal class Program
    {
        private static void Main()
        {
            
        }

        private static async Task<int> MaybeRunAsync(bool shouldIRun)
        {
            if (shouldIRun)
                return 0;

            await Task.Delay(100);
            return 5;
        }
    }
}