namespace Tickets.API.Services
{
    public interface IValidatorService
    {
        Task ValidateAsync<TInput>(TInput input) where TInput : class;
    }
}
