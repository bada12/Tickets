using Tickets.Domain.Entities;

namespace Tickets.API.Services.Interfaces
{
    public interface ICacheService
    {
        public bool TryGet<T>(string key, out T entry) where T : EntityBase;

        public void Set<T>(T entry) where T : EntityBase;

        public void SetList<T>(IEnumerable<T> entries) where T : EntityBase;

        public void Remove(string key);

        public void RemoveList<T>() where T : EntityBase;
    }
}
