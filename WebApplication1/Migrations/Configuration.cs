namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using WebApplication1.Models;
    

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication1.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        bool AddUserAndRole( WebApplication1.Models.ApplicationDbContext context)
        {
            IdentityResult ir;

            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            //var rm = new RoleManager(new RoleStore(context));
            

            ir = rm.Create(new IdentityRole("canEdit"));

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //var um = new UserManager(new UserStore(context));
            
            var user = new ApplicationUser()
            {
                UserName = "admin",
            };

            ir = um.Create(user, "admin123");
            
            if (ir.Succeeded == false)
                return ir.Succeeded;
            
            ir = um.AddToRole(user.Id, "canEdit");
            
            return ir.Succeeded;
        
        }

        protected override void Seed(WebApplication1.Models.ApplicationDbContext context)
        {

            AddUserAndRole(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
