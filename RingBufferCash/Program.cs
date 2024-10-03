using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingBufferCash
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            int cnt = 1000000;            var scache = new CircularBufferCache<string, string>(3);
            Console.WriteLine("<string, string>");
            stopwatch.Start();
            for (int i = 0; i < cnt; i++)
            {
                var result = scache.Get("key"+i.ToString()); 
            }
            stopwatch.Stop();
            Console.WriteLine("count: "+ cnt+ " Exec time: " + +stopwatch.ElapsedMilliseconds);

            var icache = new CircularBufferCache<int, int>(3);
            stopwatch.Restart();
            for (int i = 0; i < cnt; i++)
            {
                var result = icache.Get(i);
            }
            stopwatch.Stop();
            Console.WriteLine("count: " + cnt + " Exec time: " + +stopwatch.ElapsedMilliseconds);

            Console.ReadLine();

        }
    }
}
