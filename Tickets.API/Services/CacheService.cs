using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Tickets.API.Options;
using Tickets.API.Services.Interfaces;
using Tickets.Domain.Entities;

namespace Tickets.API.Services
{
    public class CacheService : ICacheService
    {
        private readonly HashSet<string> _eventKeys = new();
        private readonly object _lock = new();

        private readonly IMemoryCache _memoryCache;
        private readonly CacheOptions _options;

        public CacheService(
            IMemoryCache memoryCache,
            IOptions<CacheOptions> options)
        {
            _memoryCache = memoryCache ??
                throw new ArgumentNullException(nameof(memoryCache));

            _options = options?.Value ??
                throw new ArgumentNullException(nameof(options));
        }

        public bool TryGet<T>(string key, out T entry)
            where T : EntityBase
        {
            return _memoryCache.TryGetValue(key, out entry);
        }

        public void Set<T>(T entry)
            where T : EntityBase
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = _options.Expiration,
                SlidingExpiration = _options.SlidingExpiration
            };

            var key = GetCacheKey<T>() + entry.Id.ToString();
            _memoryCache.Set(key, entry, cacheEntryOptions);

            lock (_lock)
            {
                if (!_eventKeys.Contains(key))
                {
                    _eventKeys.Add(key);
                }
            }
        }

        public void SetList<T>(IEnumerable<T> entries)
            where T : EntityBase
        {
            foreach (var entry in entries)
            {
                Set(entry);
            }
        }

        public void Remove(string key)
        {
            lock (_lock)
            {
                if (_eventKeys.Contains(key))
                {
                    _memoryCache.Remove(key);
                    _eventKeys.Remove(key);
                }
            }
        }

        public void RemoveList<T>()
            where T : EntityBase
        {
            var eventKeys = _eventKeys.Where(eventKey => eventKey.StartsWith(GetCacheKey<T>())).ToList();

            foreach (var eventKey in eventKeys)
            {
                Remove(eventKey);
            }
        }

        private static string GetCacheKey<T>()
        {
            return typeof(T).FullName ?? throw new InvalidOperationException("Type name cannot be null.");
        }
    }
}
