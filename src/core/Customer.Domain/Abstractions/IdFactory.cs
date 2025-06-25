using System.Collections.Concurrent;

namespace CustomerFlow.Core.Domain.Abstractions;

public class IdFactory
{
    private readonly ConcurrentDictionary<int, Id> _cache = new();

    public Id Create(int value)
    {
        return _cache.GetOrAdd(value, v => new Id(v));
    }
}
