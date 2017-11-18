namespace TP.EntityFrameworkCore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TP.EntityFrameworkCore.TPDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TPDbContext context)
        {
            context.Users.Add(new Core.Users.User
            {
                Name = "Admin",
                Created = DateTime.Now,
                Mobile = "18090548343"
            });
            context.SaveChanges();
        }
    }
}
