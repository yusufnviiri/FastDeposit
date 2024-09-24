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
           



            //var depositOne = new Deposit { Amount = 78523000, Balance = 3000 };
            //var depositTwo = new Deposit {   Amount = 465112000, Balance = 9200 };
            //var depositThree = new Deposit { Amount = 76908000, Balance = 7372900 };
            //var depositFour = new Deposit { Amount = 453547100, Balance = 83900 };

            //var withrawOne = new Withdraw {  Amount = 482000, Balance = 77000 };
            //var withrawTwo = new Withdraw { Amount = 8394000, Balance = 519200 };
            //var withrawThree = new Withdraw { Amount = 883000, Balance = 62900 };
            //var withrawFour = new Withdraw { Amount = 129300, Balance = 89900 };



            var withrawOne1 = new Withdraw {WithdrawId=5, Amount = 523000, Balance = 3000 };
            var withrawTwo2 = new Withdraw { WithdrawId =6, Amount = 112000, Balance = 9200 };
            var withrawThree3 = new Withdraw { WithdrawId =7, Amount = 908000, Balance = 7372900 };
            var withrawFour4 = new Withdraw { WithdrawId =8, Amount = 547100, Balance = 83900 };
            var withrawOne = new Withdraw { WithdrawId = 1, Amount = 523000, Balance = 3000 };
            var withrawTwo = new Withdraw { WithdrawId = 2, Amount = 112000, Balance = 9200 };
            var withrawThree = new Withdraw { WithdrawId = 3, Amount = 908000, Balance = 7372900 };
            var withrawFour = new Withdraw { WithdrawId = 4, Amount = 547100, Balance = 83900 };
            //List<Deposit> deposits2 = new List<Deposit> { depositOne1, depositTwo2, depositThree3, depositFour4 };
            //List<Withdraw> withdraws2 = new List<Withdraw> { withrawOne1, withrawTwo2, withrawThree3, withrawFour4 };

            //List<Deposit> deposits = new List<Deposit> { depositOne, depositTwo, depositThree, depositFour };
            //List<Withdraw> withdraws = new List<Withdraw> { withrawOne, withrawTwo, withrawThree, withrawFour };


            var hasher = new PasswordHasher<User>();


            // Create users
            var adminUser = new User
            {
                Id = "100", // Primary key
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin1!"),
                SecurityStamp = string.Empty,
                FirstName="Romeru",
                LastName="Lukaku"
                //Deposits=deposits,
                //Withdraws=withdraws,
                
                
            };
            var memberUser = new User
            {
                Id = "101", // Primary key
             UserName = "member@member.com",
             NormalizedUserName = "MEMBER@MEMBER.COM",
             Email = "member@member.com",
             NormalizedEmail = "MEMBER@MEMBER.COM",
             EmailConfirmed = true,
             PasswordHash = hasher.HashPassword(null, "User12!"),
             SecurityStamp = string.Empty,
                FirstName = "Dimitar",
                LastName = "Berbatov"
                //Deposits = deposits2,
                //Withdraws = withdraws2,

            };
            builder.HasData(adminUser, memberUser);


        }
 }
}
