using Haber35.CORE.Concretes;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Haber35.UI.Utils
{
    public class ClaimService
    {
        private readonly UserManager<AppUser> userManager;

        public ClaimService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<bool> AddClaimsToUser(AppUser user)
        {
            await userManager.AddClaimAsync(user, new Claim("userId", user.Id));
            await userManager.AddClaimAsync(user, new Claim("firstName", user.FirstName));
            await userManager.AddClaimAsync(user, new Claim("photoPath", user.ImagePath));

            return true;
        }

        public async Task<bool> RemoveClaims(AppUser user)
        {
            await userManager.RemoveClaimsAsync(user, await userManager.GetClaimsAsync(user));
            return true;
        }
    }
}

