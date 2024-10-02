using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;



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
         .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<User>()
       .HasMany(b => b.Withdraws)
       .WithOne(p => p.User)
       .HasForeignKey(p => p.UserId);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new WithdrawConfiguration());
            modelBuilder.ApplyConfiguration(new DepositConfiguration());
            base.OnModelCreating(modelBuilder);


        }

        public DbSet<Deposit> Deposits { get; set; }
        public DbSet<Withdraw> Withdraws { get; set; }
        public DbSet<ActiveAccount> ActiveAccounts { get; set; }

    }
}
