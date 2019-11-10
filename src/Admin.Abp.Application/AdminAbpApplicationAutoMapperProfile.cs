using Admin.Abp.Application.Contracts.DTO;
using Admin.Abp.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Abp.Application
{
    public class AdminAbpApplicationAutoMapperProfile : Profile
    {
        public AdminAbpApplicationAutoMapperProfile()
        {
            CreateMap<UserInfoDto, UserInfo>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.UserName));
        }
    }
}
