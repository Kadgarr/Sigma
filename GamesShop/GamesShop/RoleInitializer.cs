using GamesShop.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesShop
{
    public class RoleInitializer
    {

        public static async Task InitializeUserAsync(User user, UserManager<User> _userManager)
        {
            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, "user");
            }
               
        }
    }
}
