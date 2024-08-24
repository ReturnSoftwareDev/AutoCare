using AutoCare.Application.Mediator.Commands.AboutCommands;
using AutoCare.Application.Mediator.Commands.SocialMediaCommands;
using AutoCare.Application.Mediator.Commands.UserCommands;
using AutoCare.Application.Mediator.Results.AboutResults;
using AutoCare.Application.Mediator.Results.SocialMediaResults;
using AutoCare.Application.Mediator.Results.UserResults;
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

            CreateMap<CreateAboutCommand, About>().ReverseMap();
            CreateMap<UpdateAboutCommand, About>().ReverseMap();
            CreateMap<GetAboutByIdQueryResult, About>().ReverseMap();
            CreateMap<GetAboutQueryResult, About>().ReverseMap();

            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<UserLoginQueryResult, User>().ReverseMap();
        }
    }
}
