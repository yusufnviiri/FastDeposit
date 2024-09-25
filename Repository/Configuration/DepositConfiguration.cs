using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class DepositConfiguration : IEntityTypeConfiguration<Deposit>
    {
        public void Configure(EntityTypeBuilder<Deposit> builder)
        {
            //var depositOne = new Deposit { DepositId = 1, Amount = 78523000, Balance = 3000, Id = "101" };
            //var depositTwo = new Deposit { DepositId = 2, Amount = 465112000, Balance = 9200, Id = "101" };
            //var depositThree = new Deposit { DepositId = 3, Amount = 76908000, Balance = 7372900, Id = "101" };
            //var depositFour = new Deposit { DepositId = 4, Amount = 453547100, Balance = 83900, Id = "101" };

            //var depositOne1 = new Deposit { DepositId = 5, Amount = 3393000, Balance = 93000 ,Id = "100" };
            //var depositTwo2 = new Deposit { DepositId = 6, Amount = 9342000, Balance = 11100, Id = "100" };
            //var depositThree3 = new Deposit { DepositId = 7, Amount = 5108000, Balance = 333700, Id = "100" };
            //var depositFour4 = new Deposit { DepositId = 8, Amount = 88887100, Balance = 63800, Id = "100" };
            var depositOne = new Deposit { Id = 1, Amount = 78523000, Balance = 3000, UserId = "101" };
            var depositTwo = new Deposit { Id = 2, Amount = 465112000, Balance = 9200, UserId = "101" };
            var depositThree = new Deposit { Id = 3, Amount = 76908000, Balance = 7372900, UserId = "101" };
            var depositFour = new Deposit { Id = 4, Amount = 453547100, Balance = 83900, UserId = "101" };

            var depositOne1 = new Deposit { Id = 5, Amount = 3393000, Balance = 93000, UserId = "100" };
            var depositTwo2 = new Deposit { Id = 6, Amount = 9342000, Balance = 11100, UserId = "100" };
            var depositThree3 = new Deposit { Id = 7, Amount = 5108000, Balance = 333700, UserId = "100" };
            var depositFour4 = new Deposit { Id = 8, Amount = 88887100, Balance = 63800, UserId = "100" };

            builder.HasData(depositOne1, depositTwo2, depositThree3, depositFour4, depositOne, depositTwo, depositThree, depositFour);
        }
    }
}