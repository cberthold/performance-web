using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Performance.Models.Security;
using Performance.Web.Imports;
using Performance.Web.Services;
using Performance.Web.Utilities;

namespace Performance.Web
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
            services.AddMvc();
            string databaseConnection = "Data Source=.;Initial Catalog=WideWorldImporters;Integrated Security=True";
            services.AddDbContext<SecurityContext>(options => options.UseSqlServer(databaseConnection));
            services.AddDbContext<ImportersContext>(options => options.UseSqlServer(databaseConnection));
            // Add OpenID Connect server to produce JWT access tokens.
            services.AddAuthenticationServer();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })


            .AddJwtBearer(options =>
            {
                options.Authority = "http://localhost:5000/";
                options.Audience = "resource-server";
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthServer.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromSeconds(0)
                };
            });
            /*
            services.AddMemoryCache();
            services.AddSignalR();
            */

            services.AddScoped<IAuthorizationHandler, TenantOperationAuthorizationHandler>();
            services.AddTransient<IActiveTenantService, ActiveTenantService>();
            services.AddTransient<IAllowedTenantService, AllowedTenantService>();
            services.AddTransient<IUserPermissionsService, UserPermissionsService>();
            services.AddTransient<IDashboardOverviewService, DashboardOverviewService>();
            services.AddTransient<ITopSalesService, TopSalesService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseAuthentication();
            app.UseWebSockets();
            /*
            app.UseSignalR(routes => routes.MapDotNetifyHub());
           */

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
            
            /*
            app.Run(async (context) =>
            {
                var uri = context.Request.Path.ToUriComponent();
                if (uri.EndsWith(".map"))
                    return;
                else if (uri.EndsWith("_hmr"))  // Fix HMR for deep links.
                    context.Response.Redirect("/dist/__webpack_hmr");

                using (var reader = new StreamReader(File.OpenRead("wwwroot/index.html")))
                    await context.Response.WriteAsync(reader.ReadToEnd());
            });
            */
        }
    }
}