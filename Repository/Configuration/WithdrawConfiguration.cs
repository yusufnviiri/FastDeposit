﻿using Entities.Models;
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
    public class WithdrawConfiguration : IEntityTypeConfiguration<Withdraw>
    {
        public void Configure(EntityTypeBuilder<Withdraw> builder)
        {
            var withrawOne = new Withdraw { Id = 1, Amount = 523000, Balance = 3000, UserId = "101" };
            var withrawTwo = new Withdraw { Id = 2, Amount = 112000, Balance = 9200, UserId = "101" };
            var withrawThree = new Withdraw { Id = 3, Amount = 908000, Balance = 7372900, UserId = "101" };
            var withrawFour = new Withdraw { Id = 4, Amount = 547100, Balance = 83900, UserId = "101" };
            var withrawOne1 = new Withdraw { Id = 5, Amount = 523000, Balance = 3000,UserId="100" };
            var withrawTwo2 = new Withdraw {    Id = 6, Amount = 112000, Balance = 9200,UserId = "100" };
            var withrawThree3 = new Withdraw { Id = 7, Amount = 908000, Balance = 7372900,UserId = "100" };
            var withrawFour4 = new Withdraw { Id = 8, Amount = 547100, Balance = 83900 , UserId = "100" };

            builder.HasData(withrawOne, withrawTwo, withrawThree, withrawFour, withrawOne1, withrawTwo2, withrawThree3, withrawFour4);
        }
    }
}
