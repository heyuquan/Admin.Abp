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
            CreateMap<UserInfoDto, UserInfo>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.UserName));
        }
    }
}
