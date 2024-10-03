using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RingBufferCash
{
    internal static class DataSource<TKey, TValue>
    {
        private const int cntBase = 10000;
        private static Random random = new Random();
        private static List<string> words = GenerateWords(cntBase);
        public static TValue GetValue(TKey key)
        {
            Thread.Sleep(3); //simulate network latency
            if (typeof(TValue) == typeof(int)) //int
            {
                return (TValue)(object)random.Next(1, cntBase);  
            }
            else if (typeof(TValue) == typeof(string)) //string
            {
                string[] randomStrings = { "Hello", "World", "Random", "Data", "Test", "For" , "This", "Task", "Use", "Hook", "tetra", "VayEffect", "Ups", "Tas", "Err" }; 
                return (TValue)(object)words[random.Next(cntBase)];  
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
            Thread.Sleep(3);//simulate network latency
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

        static List<string> GenerateWords(int count)
        {
            var words = new List<string>();
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"; 

            for (int i = 0; i < count; i++)
            {
                int wordLength = random.Next(4, 10); //word length between 4 and 10
                StringBuilder word = new StringBuilder();

                for (int j = 0; j < wordLength; j++)
                {
                    word.Append(chars[random.Next(chars.Length)]);
                }

                words.Add(word.ToString());
            }

            return words;
        }
    }
}
