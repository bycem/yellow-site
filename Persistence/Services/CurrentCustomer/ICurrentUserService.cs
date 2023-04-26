namespace Persistence.Services.CurrentCustomer;

public interface ICurrentUserService
{
    Task<string> GetUserIdAsync();
}

