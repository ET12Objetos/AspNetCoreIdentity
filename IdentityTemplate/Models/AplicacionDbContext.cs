using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityTemplate.Models
{
    public class AplicacionDbContext : IdentityDbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUser>(i => { 
                i.Property(o => o.EmailConfirmed).HasConversion<int>(); 
                i.Property(o => o.LockoutEnabled).HasConversion<int>(); 
                i.Property(o => o.PhoneNumberConfirmed).HasConversion<int>(); 
                i.Property(o => o.TwoFactorEnabled).HasConversion<int>(); 
            });

            base.OnModelCreating(builder);
        }
    }
}
