using Microsoft.AspNetCore.Identity;
using Persistence.Services.CurrentCustomer;
using System.Security.Claims;

namespace Api.Identity
{
    public class CurrentUserServiceWebApiImpl : ICurrentUserService
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<IdentityUser> _userManager;

        public CurrentUserServiceWebApiImpl(IHttpContextAccessor accessor, UserManager<IdentityUser> userManager)
        {
            _accessor = accessor;
            _userManager = userManager;
        }

        public async Task<string> GetUserIdAsync()
        {
            var httpUser = _accessor.HttpContext?.User?.Identity?.Name;
            var user = await _userManager.FindByNameAsync(httpUser);
            return user.Id;
        }
    }
}
