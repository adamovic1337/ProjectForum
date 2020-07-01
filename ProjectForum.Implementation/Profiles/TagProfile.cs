using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectForum.Application.DataTransfer;
using ProjectForum.Domain.Entities;

namespace ProjectForum.Implementation.Profiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>();
        }
    }
}
