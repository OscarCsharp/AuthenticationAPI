using DAL.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthAPI.Extensions
{
    public static class UserExtension
    {
        public static IServiceCollection AddUserIdentity(this IServiceCollection services, IConfiguration config)
        {
            //add default  services for identity core into the application
            services.AddDefaultIdentity<AppUser>()
                .AddRoles<IdentityRole>()//For Roles in the database
               .AddEntityFrameworkStores<DataContext>();

            //Customixe Identity core validations
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            }
            );
            return services;
        }
    }
}
