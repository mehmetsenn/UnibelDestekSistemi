using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using React.AspNet;

namespace UnibelDestekSistemi
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });




            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(1);//You can set Time   
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/";
        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            //Deðiþiklik denemesi kjqnwejhbqwebh dendende
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();
            app.UseCookiePolicy();
            
            app.UseMvc(ConfigureRoutes);
            
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("default", "/", defaults: new { controller = "LoginPage", action = "Login" });
            //routeBuilder.MapRoute("routeLogin", "/", defaults: new { controller = "LoginPage", action = "Login" });
            routeBuilder.MapRoute("routeDashboard", "/Dashboard", defaults: new { controller = "Dashboard", action = "Index" });
            routeBuilder.MapRoute("routeSignUp", "/Signup", defaults: new { controller = "Home", action = "Signup" });
            routeBuilder.MapRoute("routeLogout", "/Logout", defaults: new { controller = "Base", action = "LogOut" } );
            routeBuilder.MapRoute("routeShowTicket", "/showTicket/{ticketId}", defaults: new { controller = "TicketManagement", action = "showTicket" });
            routeBuilder.MapRoute("routeAdvancedSearch", "/AdvancedSearch", defaults: new { controller = "AdvancedSearch", action = "Index" });
            routeBuilder.MapRoute("routeOwnTicket", "/ownTicket/{ticketId}", defaults: new { controller = "TicketManagement", action = "ownTicket" });
            routeBuilder.MapRoute("routeAddCustomer", "/AddCustomer", defaults: new { controller = "First", action = "AddCustomer"});
            routeBuilder.MapRoute("routeAddStaff", "/AddStaff", defaults: new { controller = "First", action = "AddStaff" });
            routeBuilder.MapRoute("routeAddTicket", "/addTicket", defaults: new { controller = "First", action = "addTicket" });
            routeBuilder.MapRoute("RouteAddticket2", "/addticket2", defaults: new { controller = "TicketManagement", action = "addTicket" });
            routeBuilder.MapRoute(name: "routeChangePassword", template: "/ChangePassword", new { controller = "Profile", action = "ChangePassword" });
            routeBuilder.MapRoute(name: "routeCustomerChangePassword", template: "/CustomerChangePassword", new { controller = "CustomerChangePassword", action = "ChangePassword" });
            routeBuilder.MapRoute(name: "routeCustomerProfileController", template: "/CustomerProfile", new { controller = "CustomerProfile", action = "CustomerProfileSettings" });
            routeBuilder.MapRoute("getUser", "/try/{depid}", defaults: new { controller = "TicketManagement", action = "Jsres" });
            routeBuilder.MapRoute("getUser2", "/Den", defaults: new { controller = "CustomerCancelledRequest", action = "Den" });
            routeBuilder.MapRoute("getUser222", "/listshow", defaults: new { controller = "CustomerCancelledRequest", action = "listshow" });
            routeBuilder.MapRoute(name: "routeCustomerForgotPassword", template: "/CustomerForgotPassword", defaults: new { controller = "CustomerForgotPassword", action = "CustomerForgotPassword" });
            routeBuilder.MapRoute(name: "routeNewPassword", template: "/NewPassword/{Link}", defaults: new { controller = "NewPassword", action = "NewPassword" });
            routeBuilder.MapRoute(name: "routeCustomerChangeEmail", template: "/CustomerChangeEmail", new { controller = "CustomerChangeEmail", action = "CustomerChangeEmail" });
            routeBuilder.MapRoute("getlist", "/Den", defaults: new { controller = "CustomerCancelledRequest", action = "Den" });
            routeBuilder.MapRoute(name: "CustomerCancelledRequest", template: "/CustomerCancelledRequest", defaults: new { controller = "CustomerCancelledRequest", action = "Index" });
            routeBuilder.MapRoute(name: "TaleplerimTablo", template: "/Taleplerim", defaults: new { controller = "CustomerSendingRequest", action = "SendingRequest" });
            routeBuilder.MapRoute(name: "CustomerGönderilmişTalepler", template: "/CustomerSendingRequest", defaults: new { controller = "CustomerSendingRequest", action = "Index" });
        }

    }
}
