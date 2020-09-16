using CoreStarter.EFCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreStarter.API
{
    public static class UserManagerExtensions
    {
        public static async Task<AppUser> FindByEmailFromClaimsPrinciple(this UserManager<AppUser> input, ClaimsPrincipal user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}