using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Interface
{
    public interface IUserService
    {
        Task<bool> Register(RegisterModel model);
        Task<string> Login(LoginModel model);
        Task<Object> GetUserProfile(string userId);

    }
}
