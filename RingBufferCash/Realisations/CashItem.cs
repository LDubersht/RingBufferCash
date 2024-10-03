using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RingBufferCash
{
    internal class CashItem<TValue>
    {
        public CashItem(TValue itemValue)
        {
            ItemValue = itemValue;
            LastAccessTime = DateTime.Now;
        }
        public TValue ItemValue { get; set; }

        public DateTime LastAccessTime { get; set; }    
    }
}
