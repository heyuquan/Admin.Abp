using Ec.Admin.Application.Contracts.DTO;
using Ec.Admin.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

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
