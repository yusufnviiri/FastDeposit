﻿using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace SaccoOps
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //CreateMap<Deposit,ShowSaccoTransactionDto>().ForCtorParam("ModelId", opt=>opt.MapFrom(p=>p.DepositId));
            //CreateMap<Deposit, ShowSaccoTransactionDto>().ForCtorParam("Id", opt => opt.MapFrom(p => p.DepositId));
            CreateMap<Withdraw, ShowSaccoTransactionDto>();
            CreateMap<Deposit, ShowSaccoTransactionDto>();
            // CreateMap< ShowSaccoTransactionDto, Deposit>();
            CreateMap<UserRegistrationDto, User>()
        .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));



        }
    }
}
