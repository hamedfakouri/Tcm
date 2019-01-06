using Framework.Log.MongoDb;
using Framework.Log.MongoDb.Interfaces;
using Framework.Persistence.Ef;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Tcm.Domain.Interfaces;
using Tcm.Interface.Api.MiddleWares;
using Tcm.Persistence.Ef;
using Tcm.Persistence.Ef.Repositories;

namespace Tcm.Interface.Api
{
    public class Startup
    {

        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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
         
        public void ConfigureServices(IServiceCollection services)
        {

            IocSetting(services);

            MvcSetting(services);

            AuthenticationSetting(services);


            //services.AddAuthorization(options =>
            //{
            //  options.AddPolicy("userRole", policy =>
            //  {
            //    policy.AddAuthenticationSchemes("Bearer");
            //    policy.RequireClaim(ClaimTypes.Role, "member");
            //  });
            //});

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

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseStaticFiles();

            app.UseExceptionHandler();

            app.UseLogRequestMidleware();

            app.UseAuthentication();


            //app.UseAuthentication()
            //    .Use(async (ctx, next) =>
            //    {
            //        var customHeader = ctx.Request.Headers["Authorization"].ToString();
            //        var user = ctx.User.Identity.IsAuthenticated;
            //        await next.Invoke();
            //    });

            app.UseUnitOfworkMiddleware();

            app.UseMvcWithDefaultRoute();

            app.UseMvc();

        }
    }
}
