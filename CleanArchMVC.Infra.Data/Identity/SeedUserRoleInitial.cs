using CleanArchMVC.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;

namespace CleanArchMVC.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void SeedRoles()
        {
            if (_userManager.FindByEmailAsync("usuario@localhost").Result.Equals(null))
            {
                ApplicationUser newUser = new ApplicationUser();

                newUser.UserName = "usuario@localhost";
                newUser.Email = "usuario@localhost";
                newUser.NormalizedUserName = "USUARIO@LOCALHOST";
                newUser.NormalizedEmail = "USUARIO@LOCALHOST";
                newUser.EmailConfirmed = true;
                newUser.LockoutEnabled = false;
                newUser.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(newUser, "Numsey#2022").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(newUser, "User").Wait();
            }

            if (_userManager.FindByEmailAsync("admin@localhost").Result.Equals(null))
            {
                ApplicationUser newUser = new ApplicationUser();

                newUser.UserName = "admin@localhost";
                newUser.Email = "admin@localhost";
                newUser.NormalizedUserName = "ADMIN@LOCALHOST";
                newUser.NormalizedEmail = "ADMIN@LOCALHOST";
                newUser.EmailConfirmed = true;
                newUser.LockoutEnabled = false;
                newUser.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(newUser, "Numsey#2022").Result;

                if (result.Succeeded)
                    _userManager.AddToRoleAsync(newUser, "Admin").Wait();
            }
        }

        public void SeedUsers()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }

            if (!_roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                role.NormalizedName = "ADMIN";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
