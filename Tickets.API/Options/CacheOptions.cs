namespace Tickets.API.Options
{
    public record CacheOptions
    {
        public TimeSpan Expiration { get; init; }

        public TimeSpan SlidingExpiration { get; init; }
    }
}
