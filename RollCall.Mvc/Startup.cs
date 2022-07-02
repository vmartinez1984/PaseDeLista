using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RollCall.BusinessLayer;
using RollCall.Core.Interfaces.InterfacesBl;
using RollCall.Core.Interfaces.IRepositories;
using RollCall.Core.Mappers;
using RollCall.Dao.Dao;
using RollCall.Persistence.Dao;
using RollCall.Persistence.Entities;

namespace RollCall.Mvc
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
			AddMappers(services);
            services.AddControllersWithViews();
            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //DbContext
            services.AddScoped<AppDbContext>();
            services.AddScoped<IScheduleRepository, ScheduleDao>();
            services.AddScoped<IUserRepository, UserDao>();
            services.AddScoped<IAreaRepository, AreaDao>();
            services.AddScoped<IConfigurationRepository, ConfigDao>();
            services.AddScoped<IRepository, Repository>();
            //BussinesLayer
            services.AddScoped<IScheduleBl, ScheduleBl>();
            services.AddScoped<ILoginBl, LoginBl>();
            services.AddScoped<IAreaBl, AreaBl>();
            services.AddScoped<IUserBl, UserBl>();
            services.AddScoped<IRoleBl, RolBl>();            
            services.AddScoped<IUnitOfWorkBl, UnitOfWork>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RollCall.WsApi", Version = "v1" });
            });
        }

        private void AddMappers(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<AreaMapper>();
                mapperConfig.AddProfile<UserMapper>();
                mapperConfig.AddProfile<RoleMapper>();
                mapperConfig.AddProfile<ScheduleMapper>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RollCall.WsApi v1"));
            }
            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapAreaControllerRoute(
                    "Employees",
                    "Employees",
                    "{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapAreaControllerRoute(
                    "Administrators",
                    "Administrators",
                    "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
