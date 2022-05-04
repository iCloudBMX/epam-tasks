using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Areas.Identity.Data
{
    public class AuthIdentityDbContext : IdentityDbContext<User>
    {
        public AuthIdentityDbContext(DbContextOptions<AuthIdentityDbContext> options)
            : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Name = "User", NormalizedName = "USER" });
            
            base.OnModelCreating(builder);            
        }            
    }
}
