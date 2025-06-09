using Tickets.Domain.Entities;

namespace Tickets.API.Services.Interfaces
{
    public interface ICacheService
    {
        bool TryGet<T>(string key, out T entry) where T : EntityBase;

        void Set<T>(T entry) where T : EntityBase;

        void SetList<T>(IEnumerable<T> entries) where T : EntityBase;

        void Remove(string key);

        void RemoveList<T>() where T : EntityBase;
    }
}
