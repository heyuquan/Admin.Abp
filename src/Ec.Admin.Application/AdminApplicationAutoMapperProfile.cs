using AutoMapper;
using Ec.Admin.AggregateRoot;
using Ec.Admin.DTO;

namespace Ec.Admin
{
    public class AdminApplicationAutoMapperProfile : Profile
    {
        public AdminApplicationAutoMapperProfile()
        {
            CreateMap<UserInfo, UserInfoDto>()
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.Name));

            CreateMap<Role, RoleDto>();
        }
    }
}
