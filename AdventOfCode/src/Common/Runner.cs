using System;

namespace Common
{
    public static class Runner
    {
        public static void Run<TSource, TResult>(TSource input, Func<TSource, TResult> fn)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            var output = fn(input);
            
            watch.Stop();
            Console.WriteLine($"Result:         {output}");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }
    }
}