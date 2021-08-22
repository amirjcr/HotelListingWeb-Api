using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore;
using Microsoft.OpenApi.Models;
using HotelListiing.EndPoint.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using AutoMapper.Execution;
using HotelListing.EndPoint.Cofingurations;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using HotelListing.EndPoint.MyExtenstions;
using System.IO;
using System.Reflection;


namespace HotelListing.EndPoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureIdenittyService();
            services.AddControllers();
            services.AddCors(o =>
            {
                o.AddPolicy("AllowALl", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HotelListing", Version = "v1" });
                // var xmlFilePath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                // c.IncludeXmlComments(xmlFilePath);
            });
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("defaultConnection"));
            });
            services.ConfigureJwt(Configuration);
            services.CustomServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(c =>
            {
                c.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                // string baserouteprifiex = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                // c.SwaggerEndpoint($"{baserouteprifiex}/swagger/v1/swagger.json", "HoteListing API");
                c.SwaggerEndpoint($"swagger/v1/swagger.json", "HoteListing API");
            });

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseCors("AllowALl");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
