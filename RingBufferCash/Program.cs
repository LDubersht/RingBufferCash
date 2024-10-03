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
            int loopCNT = 1000; //count test calls
            int cashCNT = 100; //we can change cash cize
            int divCNT = 100;
            
            //---------strings----------------
            var scache = new CircularBufferCache<string, string>(cashCNT);
            var r = scache.Get("key"); //warming up the string date generator, because static
            Console.WriteLine("<string, string>");
            stopwatch.Start();
            for (int i = 0; i < loopCNT; i++)
            {
                scache.Get("key" + (i % divCNT).ToString());
                //var result = DataSource<string, string>.GetValue("key" + (i % divCNT).ToString());
            }
            stopwatch.Stop();
            Console.WriteLine($"loopCNT: {loopCNT} cashCNT: {cashCNT} divCNT {divCNT} Exec time: {stopwatch.ElapsedMilliseconds}");
            
            //---------int----------------
            var icache = new CircularBufferCache<int, int>(cashCNT);
            Console.WriteLine("<int, int>");
            stopwatch.Restart();
            for (int i = 0; i < loopCNT; i++)
            {
                var result = icache.Get(i % divCNT);
            }
            stopwatch.Stop();
            Console.WriteLine($"loopCNT: {loopCNT} cashCNT: {cashCNT} divCNT {divCNT} Exec time: {stopwatch.ElapsedMilliseconds}");

            Console.ReadLine();

        }
    }
}
