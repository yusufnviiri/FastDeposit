﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
   public class User:IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? WithdrawId { get; set; }
        public string? ActiveAccountId { get; set; }
        public ActiveAccount? ActiveAccount { get; set; }

        public ICollection<Deposit>? Deposits { get; set; }
        public ICollection<Withdraw>? Withdraws { get; set; }


     

    }
}
