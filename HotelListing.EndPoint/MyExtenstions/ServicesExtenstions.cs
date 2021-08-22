using System;
using System.Text;
using HotelListiing.EndPoint.Data;
using HotelListing.EndPoint.Data.Entities.identity;
using HotelListing.EndPoint.Models;
using HotelListing.EndPoint.Services.IRepositories;
using HotelListing.EndPoint.Services.Repositories;
using HotelListing.EndPoint.Services.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace HotelListing.EndPoint.MyExtenstions
{
    public static class ServieExtentions
    {
        public static void ConfigureIdenittyService(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>()
                    .AddDefaultTokenProviders();


            services.Configure<IdentityOptions>(options =>
            {



                //PassWord Configration
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;


                //Sign configuration

                options.SignIn.RequireConfirmedEmail = false;


                //Usre Configuration

                options.User.RequireUniqueEmail = true;


            });
        }



        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtsetting = configuration.GetSection("JwtSetting");
            var Key = Environment.GetEnvironmentVariable("JWTKEY");

            services.AddAuthentication(conf =>
            {
                conf.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                conf.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,

                      ValidIssuer = jwtsetting.GetSection("Issuer").Value,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key))
                  };
              });
        }


        public static void CustomServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthManager, AuthManager>();
        }


        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error =>
            {

                error.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var contextfeatures = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextfeatures != null)
                    {
                        Log.Error($"there are some Errors {nameof(contextfeatures.Error)}");

                        await context.Response.WriteAsync(new Error
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error Please Try Later"
                        }.ToString());
                    }

                });
            });
        }

    }
}