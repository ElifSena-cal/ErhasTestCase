using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<AppUser> FindByEmailAsync(string email);
        Task<IdentityResult> CreateUserAsync(AppUser user, string password);
        Task<AppUser> GetUserAsync(string userId);
    }
}
