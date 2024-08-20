using AutoCare.Application.Mediator.Commands.SocialMediaCommands;
using AutoCare.Application.Mediator.Results.SocialMediaResults;
using AutoCare.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateSocialMediaCommand, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaCommand, SocialMedia>().ReverseMap();
            CreateMap<GetByIdSocialMediaQueryResult, SocialMedia>().ReverseMap();
            CreateMap<GetSocialMediasQueryResult, SocialMedia>().ReverseMap();
        }
    }
}
