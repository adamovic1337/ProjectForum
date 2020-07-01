using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Domain.Entities;

namespace ProjectForum.Implementation.Profiles
{
    public class UseCaseLogProfile : Profile
    {
        public UseCaseLogProfile()
        {
            CreateMap<UseCaseLog, UseCaseLogDto>();
            CreateMap<UseCaseLogDto, UseCaseLog>();
        }
    }
}
