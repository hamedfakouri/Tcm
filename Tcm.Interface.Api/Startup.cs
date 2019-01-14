﻿using Framework.Log.MongoDb;
using Framework.Log.MongoDb.Interfaces;
using Framework.Persistence.Ef;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Net.Http;
using System.Security.Claims;
using Tcm.Domain.IdentityModel;
using Tcm.Domain.Interfaces;
using Tcm.Interface.Api.MiddleWares;
using Tcm.Persistence.Ef;
using Tcm.Persistence.Ef.Repositories;
using static Tcm.Persistence.Ef.Identity.AspIdentityServices;

namespace Tcm.Interface.Api
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {


            services.AddDbContext<TcmContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, Role>(identityOptions =>
            {
                // ...
            }).AddUserStore<ApplicationUserStore>()
              .AddUserManager<ApplicationUserManager>()
              .AddRoleStore<ApplicationRoleStore>()
              .AddRoleManager<ApplicationRoleManager>()
              .AddSignInManager<ApplicationSignInManager>()
              // You **cannot** use .AddEntityFrameworkStores() when you customize everything
              //.AddEntityFrameworkStores<ApplicationDbContext, int>()
              .AddDefaultTokenProviders();



            services.AddScoped<UserStore<ApplicationUser, Role, TcmContext, int, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>, ApplicationUserStore>();
            services.AddScoped<UserManager<ApplicationUser>, ApplicationUserManager>();
            services.AddScoped<RoleManager<Role>, ApplicationRoleManager>();
            services.AddScoped<SignInManager<ApplicationUser>, ApplicationSignInManager>();
            services.AddScoped<RoleStore<Role, TcmContext, int, UserRole, RoleClaim>, ApplicationRoleStore>();
         


            services.AddMvc();




            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseCors(
options => options.AllowAnyOrigin()
);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication(); // not needed, since UseIdentityServer adds the authentication middleware ** important



            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }


        private IConfiguration _configuration;

       

        protected void IocSetting(IServiceCollection services)
        {
          
            services.AddDbContext<TcmContext>(c =>
                c.UseSqlServer(_configuration.GetConnectionString("TransportCentralizedManagementConnection")), ServiceLifetime.Scoped, ServiceLifetime.Scoped);


            AddRepositoriesToServices(services);



        }

        private void AddRepositoriesToServices(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.Scan(scan => scan
                 .FromAssemblyOf<TcmContext>()
                 .AddClasses(classes => classes.AssignableTo(typeof(IRepositoryMarker)))
                 .AsImplementedInterfaces()
                 .WithScopedLifetime());

            services.AddScoped<IUnitOfWork, TcmContextUnitOfWork>();

            var mongoSetting = new MongoSetting();
            _configuration.Bind("MongoSetting", mongoSetting);

            services.AddScoped<IApiLogService>(x => new ApiLogService(mongoSetting));

        }
         
       

        private void AuthenticationSetting(IServiceCollection services)
        {
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = "http://localhost:5000/";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "http://localhost:5000",
                        ValidateAudience = true,
                        ValidAudience = "http://localhost:5000/resources",
                        ValidateLifetime = true,

                    };
                });
        }

        private void MvcSetting(IServiceCollection services)
        {
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver
                    = new DefaultContractResolver();
            });
        }

       
    }
}
