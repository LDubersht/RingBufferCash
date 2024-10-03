using System;
using System.Collections.Generic;
using System.Linq;
using RingBufferCash;
namespace RingBufferCash
{
    public class CircularBufferCache<TKey, TValue>
    {
        private readonly Dictionary<TKey, CashItem<TValue>> _keyIndexMap;
        private readonly int _capacity;

        public CircularBufferCache(int capacity)
        {
            _capacity = capacity;
            _keyIndexMap = new Dictionary<TKey, CashItem<TValue>>();
        }
        public TValue Get(TKey key)
        {
            if (_keyIndexMap.ContainsKey(key)) //in cash
            {
                _keyIndexMap[key].LastAccessTime = DateTime.Now;
                return _keyIndexMap[key].ItemValue;
            }
            else //not in cash
            {
                TValue ItemValue = DataSource<TKey, TValue>.GetValue(key);
                CashItem<TValue> item = new CashItem<TValue>();
                { item.ItemValue = ItemValue; item.LastAccessTime = DateTime.Now; }
                if (_keyIndexMap.Count == _capacity)
                {
                    TKey LastKey = _keyIndexMap.Aggregate((x, y) => x.Value.LastAccessTime.CompareTo(y.Value.LastAccessTime) < 0 ? x : y).Key;
                    _keyIndexMap.Remove(LastKey);
                }
                _keyIndexMap.Add(key, item);
                return item.ItemValue;
            }
        }

        public bool IsContainsKey(TKey key)
        {
            return _keyIndexMap.ContainsKey(key);
        }

        public void Clear()
        {
            _keyIndexMap.Clear();
        }
    }

}