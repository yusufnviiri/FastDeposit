using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
public class UserConfiguration:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            builder.HasData(
            // Create users
            new IdentityUser
            {
                Id = "100", // Primary key
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin1!"),
                SecurityStamp = string.Empty
            },
         new IdentityUser
            {
                Id = "101", // Primary key
                UserName = "member@member.com",
                NormalizedUserName = "MEMBER@MEMBER.COM",
                Email = "member@member.com",
                NormalizedEmail = "MEMBER@MEMBER.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "User12!"),
                SecurityStamp = string.Empty
            });


        }
 }
}
