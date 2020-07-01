using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Domain.Entities;

namespace ProjectForum.Implementation.Profiles
{
    public class RoleUseCaseProfile : Profile
    {
        public RoleUseCaseProfile()
        {
            CreateMap<RoleUseCaseDto, RoleUseCase>();
            CreateMap<RoleUseCase, RoleUseCaseDto>();
        }
    }
}
