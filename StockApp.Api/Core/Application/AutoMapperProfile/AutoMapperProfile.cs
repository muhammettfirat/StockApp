using AutoMapper;
using StockApp.Api.Core.Application.Dto;
using StockApp.Api.Core.Domain;
using System.Text.RegularExpressions;

namespace StockApp.Api.Core.Application.AutoMapperProfile
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<StockType, StockTypeDto>().ReverseMap();
            CreateMap<StockUnit, StockUnitDto>().ReverseMap();
            CreateMap<StockCard, StockCardDto>().ReverseMap();
            CreateMap<AppUser, AppUserDto>().ReverseMap();
            CreateMap<AppRole, AppRoleDto>().ReverseMap();
        }
    }
}
