using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExample.Interfaces
{
    public interface ICircularBufferCache<TKey,TValue>
    {
        TValue Get(TKey key);

        bool IsContainsKey(TKey key);

        void Clear();

    }
}
