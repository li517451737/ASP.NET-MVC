using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Core.Users;

namespace TP.Core.IdentityConfig
{
    public class TPDbContext : IdentityDbContext<User>
    {

        public TPDbContext() : base("Default", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("TPUser");
        }

        public static TPDbContext Create()
        {
            return new TPDbContext();
        }
    }
}
