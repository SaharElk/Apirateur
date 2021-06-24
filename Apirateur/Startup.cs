using Client.Repositories;
using Client.Services;
using GS = Global.Services;
using GR = Global.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools.Connections.Database;
using Apirateur.Infrastructure.Session;

namespace Apirateur
{
    public class Startup
    {
        private string _connectionString = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // On crée la connexion que nous sera injecté dans notre projet
            // sp = Service Provider
            services.AddSingleton(sp => new Connection(SqlClientFactory.Instance, _connectionString));

            // On injecte les repositories de la couche Client dans notre projet
            services.AddSingleton<IAuthRepository, AuthService>();
            services.AddSingleton<IContactRepository, ContactService>();
            services.AddSingleton<ICategoryRepository, CategoryService>();

            services.AddSingleton<GR.IAuthRepository, GS.AuthService>();
            services.AddSingleton<GR.IContactRepository, GS.ContactService>();
            services.AddSingleton<GR.ICategoryRepository, GS.CategoryService>();

            // Configuration des sessions
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.IsEssential = true;
                options.Cookie.HttpOnly = true;
            });

            services.AddHttpContextAccessor();

            services.AddScoped<ISessionManager, SessionManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _connectionString = Configuration.GetConnectionString("TestApp");
                app.UseDeveloperExceptionPage();
            }
            else
            {
                _connectionString = Configuration.GetConnectionString("ProductionApp");
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Précise à l'application qu'on utilise les sessions
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
