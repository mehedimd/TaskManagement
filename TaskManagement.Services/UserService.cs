using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TaskManagement.Services.Interfaces;

namespace TaskManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string GetCurrentUserId
        {
            get
            {
                var userId = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return userId ?? string.Empty;
            }
        }
    }
}
