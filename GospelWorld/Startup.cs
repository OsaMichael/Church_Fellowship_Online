using GospelWorld.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(GospelWorld.Startup))]
namespace GospelWorld
{
    public partial class Startup
    {

        public static Func<RoleManager<IdentityRole, string>> UserRoleFactory { get; private set; } = CreateRole;

        public static Func<UserManager<ApplicationUser>> UserManagerFactory { get; set; }


        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login"),
                CookieName = "PrasieZone"

            });

            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));


                usermanager.UserValidator = new UserValidator<ApplicationUser>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                return usermanager;
            };
        }




        public static RoleManager<IdentityRole, string> CreateRole()
        {
            //string[] roles = new string[2] { "ADMIN", "STAFF" };
            var dbContext = new ApplicationDbContext();
            var store = new RoleStore<IdentityRole, string, IdentityUserRole>(dbContext);
            var rolemanager = new RoleManager<IdentityRole, string>(store);


            // Array.ForEach(roles, r =>
            //{
            //    if (rolemanager.RoleExists(r))
            //        return;
            //    rolemanager.Create(new IdentityRole() { Name=r});
            //});
            //string username = "admin@store.com";
            //string password = "admin";



            //if (!rolemanager.RoleExists(role))
            //{
            //    var irole = new IdentityRole() { Name = role };
            //    rolemanager.Create(irole);
            //}

            return rolemanager;
        }
        //public void Configuration(IAppBuilder app)
        //{
        //    ConfigureAuth(app);
        //}
    }
}
