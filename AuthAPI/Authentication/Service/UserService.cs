using Authentication.Interface;
using DAL.Entities;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service
{
    public class UserService : IUserService
    {
        private UserManager<AppUser> _userManager;
        private TokenManager tokenManager = new TokenManager();

        public UserService(UserManager<AppUser> usermanager)
        {
            _userManager = usermanager;
        }

        public async Task<bool> Register(RegisterModel model)
        {
            var applicationUser = new AppUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                IdNumber = model.IdNumber
            };

            try
            {

                var result = await _userManager.CreateAsync(applicationUser, model.PasswordHash);
                await _userManager.AddToRoleAsync(applicationUser, model.Role); //Adding role to the database

                return true;

            }
            catch (Exception ex)
            {

                throw ex;

            }
        }
        public async Task<string> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.PasswordHash))
            {

                var role = await _userManager.GetRolesAsync(user);
                string username = user.Id.ToString();

                string token = tokenManager.GenerateToken(username, role.FirstOrDefault());
                return token ;
            }
            else
                return "Username or password is incorrect.";
        }
        public async Task<Object> GetUserProfile(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userRole = await _userManager.GetRolesAsync(user);
            return new
            {
                user.UserName,
                user.FullName,
                user.IdNumber,
                user.PhoneNumber,
                user.Email,
                userRole

            };
        }
    }
}
