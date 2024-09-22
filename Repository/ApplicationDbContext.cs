using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;


namespace Repository
{
  public class ApplicationDbContext:IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options):base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
         .HasMany(b => b.Deposits)
         .WithOne(p => p.User)
         .HasForeignKey(p => p.Id);
            modelBuilder.Entity<User>()
       .HasMany(b => b.Withdraws)
       .WithOne(p => p.User)
       .HasForeignKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Withdraw> Withdraws { get; set; }

    }
}
