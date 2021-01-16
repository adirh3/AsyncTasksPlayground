using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncEnumerable
{
    internal static class Program
    {
        private static async Task Main()
        {
            // await foreach  
            await foreach (var i in RunAsync())
            {
                Console.WriteLine(i);
            }

            // Equals to this, nothing runs on parallel 
            IAsyncEnumerator<int> asyncEnumerator = RunAsync().GetAsyncEnumerator();
            // Move next is not blocking, unlike normal IEnumerable<T>
            while (await asyncEnumerator.MoveNextAsync())
            {
                Console.WriteLine(asyncEnumerator.Current);
            }
        }
        
        private static async IAsyncEnumerable<int> RunAsync()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(100);
                yield return i;
            }
        }
    }
}