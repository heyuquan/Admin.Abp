using AutoMapper;
using Ec.Admin.Application.Contracts.DTO;
using Ec.Admin.Domain;
using Ec.Admin.Domain.AggregateRoot;

namespace Ec.Admin.Application
{
    public class AdminApplicationAutoMapperProfile : Profile
    {
        public AdminApplicationAutoMapperProfile()
        {
            CreateMap<UserInfo, UserInfoDto>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Name));

            //CreateMap<UserInfo, UserInfoDto>();
        }
    }
}
