using System;
using System.Collections.Generic;
using System.Linq;

namespace Caching
{
    public class StaticMemoryCache : ICache
    {
        private class CachedObject
        {
            public string Key { get; set; }
            public object Value { get; set; }
            public DateTime CachedDate { get; set; }
        }

        private readonly TimeSpan _cacheLife;
        private static readonly IList<CachedObject> _cache = new List<CachedObject>();

        public StaticMemoryCache(TimeSpan cacheLife)
        {
            _cacheLife = cacheLife;
        }

        public object this[string key]
        {
            get
            {
                var cacheHit = _cache.FirstOrDefault(c => c.Key == key);
                if (cacheHit != null)
                {
                    if ((DateTime.Now - cacheHit.CachedDate) <= _cacheLife)
                    {
                        return cacheHit.Value;
                    }
                    _cache.Remove(cacheHit);
                }
                return null;
            }
            set
            {
                var cacheHit = _cache.FirstOrDefault(c => c.Key == key);
                if(cacheHit != null)
                {
                    _cache.Remove(cacheHit);
                }
                _cache.Add(new CachedObject {Key = key, Value = value, CachedDate = DateTime.Now});
            }
        }
    }
}