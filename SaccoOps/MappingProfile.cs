using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace SaccoOps
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Deposit,ShowSaccoTransactionDto>();
            CreateMap<Withdraw, ShowSaccoTransactionDto>();
            CreateMap<UserRegistrationDto, User>();


        }
    }
}
