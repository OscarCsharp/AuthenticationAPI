using AuthAPI.Helpers;
using Authentication;
using Authentication.Service;
using DAL.Entities;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService userService ;
        public UserController(UserManager<AppUser> usermanager)
        {
            userService = new UserService(usermanager);
        }

        [HttpPost]
        [Route ("Register")]
        [AllowAnonymous]
        //POST : /api/User/Register
        public async Task<Object> PostAppUser (RegisterModel model) {

            bool signup = await userService.Register(model);

            return signup;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        //POST : /api/User/Login
        public async Task<IActionResult> Login(LoginModel model)
        {

            string login = await userService.Login(model);

            return Ok(login);
        }


        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        [Route("Userprofile")]
        //GET : /api/UserProfile
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            return await userService.GetUserProfile(userId);
        }


    }
}
