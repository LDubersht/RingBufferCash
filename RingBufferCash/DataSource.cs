using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace RingBufferCash
{
    internal static class DataSource<TKey, TValue>
    {
        private static Random random = new Random();
        public static TValue GetValue(TKey key)
        {
            
            if (typeof(TValue) == typeof(int)) //int
            {
                return (TValue)(object)random.Next(1, 100);  
            }
            else if (typeof(TValue) == typeof(string)) //string
            {
                string[] randomStrings = { "Hello", "World", "Random", "Data", "Test", "For" , "This", "Task" }; 
                return (TValue)(object)randomStrings[random.Next(randomStrings.Length)];  
            }
            else if (typeof(TValue) == typeof(DateTime)) //DateTime
            {
                int range = (DateTime.Today - new DateTime(2000, 1, 1)).Days; 
                return (TValue)(object)new DateTime(2000, 1, 1).AddDays(random.Next(range));  
            }
            else
            {
                throw new ArgumentException("Wrong value type");
            }
        }

        public static TValue GetSimpleValue(TKey key)
        {

            Random random = new Random();
            if (typeof(TValue) == typeof(TKey)) //int
            {
                TValue val = (TValue)(object)key;
                return val;
            }
            else
            {
                throw new ArgumentException("Different key value type");
            }
        }
    }
}
