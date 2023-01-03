using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MARIHUBtask.Domin.Context;
using MARIHUBtask.Repository.Abstraction;
using MARIHUBtask.Repository.Mangers;
using MARIHUBtask.Services.Abstraction;
using MARIHUBtask.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MARIHUBtask.Domin.Models;
using MARIHUBtask.DTO.MappingConfigurations;
using MARIHUBtask.DTO.configuration;
using MARIHUBtask.UI.Authorization;

namespace MARIHUBtask.UI
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
            services.AddAutoMapper(typeof(UserProfile));
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));
            services.AddDbContext<MARIHUBtaskContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<MARIHUBtaskContext>()
                .AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);
            
            //repositories
            services.AddScoped<IAccountRepo, AccountRepo>();
            services.AddScoped<IApplicationUserRepo, ApplicationUserRepo>();
            services.AddScoped<IOrderDeatailsRepo, OrderDeatailsRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            //service
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IUserMangementService, UserMangementService>();
            services.AddScoped< OrderDeatailsService ,OrderDeatailsService > ();
            services.AddScoped< OrderService ,OrderService > ();
            services.AddScoped<IJwtUtils, JwtUtils>();

            services.AddControllers();
           
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MARIHUBtask.UI", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MARIHUBtask.UI v1"));
            }
            
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRouting();
            //app.UseAuthorization();
            //app.UseAuthentication();
            app.UseMiddleware<JwtMiddleware>();
            app.UseEndpoints(x => x.MapControllers());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
