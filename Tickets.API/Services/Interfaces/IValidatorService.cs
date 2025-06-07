namespace Tickets.API.Services.Interfaces
{
    public interface IValidatorService
    {
        Task ValidateAsync<TInput>(TInput input) where TInput : class;
    }
}
