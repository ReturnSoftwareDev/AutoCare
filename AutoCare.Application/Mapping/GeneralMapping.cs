using AutoCare.Application.Mediator.Commands.MechanicCommands;
using AutoCare.Application.Mediator.Commands.MechanicServicesCommands;
using AutoCare.Application.Mediator.Commands.ServiceCommands;
using AutoCare.Application.Mediator.Commands.SocialMediaCommands;
using AutoCare.Application.Mediator.Commands.UserCommands;
using AutoCare.Application.Mediator.Results.MechanicResults;
using AutoCare.Application.Mediator.Results.MechanicServicesResults;
using AutoCare.Application.Mediator.Results.ServiceResults;
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

            CreateMap<CreateMechanicCommand, Mechanic>().ReverseMap();
            CreateMap<UpdateMechanicCommand, Mechanic>().ReverseMap();
            CreateMap<GetMechanicByIdQueryResult, Mechanic>().ReverseMap();
            CreateMap<GetMechanicQueryResult, Mechanic>().ReverseMap();

            CreateMap<CreateServiceCommand, Service>().ReverseMap();
            CreateMap<UpdateServiceCommand, Service>().ReverseMap();
            CreateMap<GetServiceByIdQueryResult, Service>().ReverseMap();
            CreateMap<GetServiceQueryResult, Service>().ReverseMap();

            CreateMap<CreateMechanicServicesCommand, MechanicServices>().ReverseMap();
            CreateMap<GetMechanicServicesQueryResult, MechanicServices>().ReverseMap();

            CreateMap<CreateUserCommand, User>().ReverseMap();
            CreateMap<UserLoginQueryResult, User>().ReverseMap();
        }
    }
}
