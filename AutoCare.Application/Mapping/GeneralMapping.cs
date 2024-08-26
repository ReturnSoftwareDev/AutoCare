using AutoCare.Application.Mediator.Commands.SocialMediaCommands;
using AutoCare.Application.Mediator.Commands.UserCommands;
using AutoCare.Application.Mediator.Results.SocialMediaResults;
using AutoCare.Application.Mediator.Results.UserResults;
using AutoCare.Domain.Entities;
using AutoMapper;

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

            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<UserLoginQueryResult, User>().ReverseMap();
        }
    }
}
