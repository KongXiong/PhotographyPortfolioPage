namespace PhotoPortfolio.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoPortfolio.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "PhotoPortfolio.Models.ApplicationDbContext";
        }

        protected override void Seed(PhotoPortfolio.Models.ApplicationDbContext context)
        {
            {
                RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);
                UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
                UserManager<ApplicationUser> userManager = new ApplicationUserManager(userStore);
                ApplicationUser admin = new ApplicationUser { UserName = "admin@admin.com" };

                userManager.Create(admin, password: "password");
                roleManager.Create(new IdentityRole { Name = "admin" });
                userManager.AddToRole(admin.Id, "admin");

            //    context.ExpenseCategories.AddOrUpdate(x => x.ID,
            //        new ExpenseCategory() { ID = 1, Name = "Cost of Goods" },
            //        new ExpenseCategory() { ID = 2, Name = "Advertising" },
            //        new ExpenseCategory() { ID = 2, Name = "Amortization" },
            //        new ExpenseCategory() { ID = 2, Name = "Auto Expenses" },
            //        new ExpenseCategory() { ID = 2, Name = "Banking Fees" },
            //        new ExpenseCategory() { ID = 2, Name = "Building Repairs" },
            //        new ExpenseCategory() { ID = 2, Name = "Business Travel" },
            //        new ExpenseCategory() { ID = 2, Name = "Charitable Deductions" },
            //        new ExpenseCategory() { ID = 2, Name = "Computer Supplies" },
            //        new ExpenseCategory() { ID = 2, Name = "Consulting Fees" },
            //        new ExpenseCategory() { ID = 2, Name = "Trade Shows" },
            //        new ExpenseCategory() { ID = 2, Name = "Dining" },
            //        new ExpenseCategory() { ID = 2, Name = "Discounts" },
            //        new ExpenseCategory() { ID = 2, Name = "Education" },
            //        new ExpenseCategory() { ID = 2, Name = "Employee Wages" },
            //        new ExpenseCategory() { ID = 2, Name = "Entertainment" },
            //        new ExpenseCategory() { ID = 2, Name = "Equipment" },
            //        new ExpenseCategory() { ID = 2, Name = "Freight & Shipping Costs" },
            //        new ExpenseCategory() { ID = 2, Name = "Gifts for Customers" },
            //        new ExpenseCategory() { ID = 2, Name = "Health Insurance" },
            //        new ExpenseCategory() { ID = 2, Name = "Home Office" },
            //        new ExpenseCategory() { ID = 2, Name = "Interest" },
            //        new ExpenseCategory() { ID = 2, Name = "Internet Costs" },
            //        new ExpenseCategory() { ID = 2, Name = "Losses due to Theft" },
            //        new ExpenseCategory() { ID = 2, Name = "Materials" },
            //        new ExpenseCategory() { ID = 2, Name = "Maintenance" },
            //        new ExpenseCategory() { ID = 2, Name = "Office Supplies" },
            //        new ExpenseCategory() { ID = 2, Name = "Parking" },
            //        new ExpenseCategory() { ID = 2, Name = "Prizes for Contests" },
            //        new ExpenseCategory() { ID = 2, Name = "Rent" },
            //        new ExpenseCategory() { ID = 2, Name = "Retirement Plans" },
            //        new ExpenseCategory() { ID = 2, Name = "Safe" },
            //        new ExpenseCategory() { ID = 2, Name = "Software" },
            //        new ExpenseCategory() { ID = 2, Name = "Taxes" },
            //        new ExpenseCategory() { ID = 2, Name = "Utilities" },
            //        new ExpenseCategory() { ID = 2, Name = "Website Design" }

            //);
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
}
