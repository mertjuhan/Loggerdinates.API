using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Loggerdinates.Shared.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public SharedIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId
        {
            get
            {
                if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null)
                {
                    // Handle the case when HttpContext or IHttpContextAccessor is null
                    return null;
                }

                var userClaim = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier);

                if (userClaim != null)
                {
                    return userClaim.Value;
                }

                // Handle the case when userClaim is null
                return null;
            }
        }
    }
}
