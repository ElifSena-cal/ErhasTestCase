using Business.Abstract;
using Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserService(UserManager<AppUser> userManager) : IUserService
    {
        private readonly UserManager<AppUser> _userManager = userManager;
        public async Task<AppUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityResult> CreateUserAsync(AppUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<AppUser> GetUserAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }
    }
}
