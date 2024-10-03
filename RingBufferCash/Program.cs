using System;
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
            var scache = new CircularBufferCache<string, string>(3);
            Console.WriteLine("<string, string>");
            Console.WriteLine(scache.Get("key1"));
            Console.WriteLine(scache.Get("key2"));
            Console.WriteLine(scache.Get("key3"));
            Console.ReadLine();

            var icache = new CircularBufferCache<int, int>(3);
            Console.WriteLine("<int, int>");
            Console.WriteLine(icache.Get(1));
            Console.WriteLine(icache.Get(7));
            Console.WriteLine(icache.Get(19));
            Console.ReadLine();

        }
    }
}
