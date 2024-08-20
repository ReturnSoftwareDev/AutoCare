using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Commands.SocialMediaCommands;
using AutoCare.Application.Mediator.Queries.SocialMediaQueries;
using AutoCare.Application.Mediator.Results.SocialMediaResults;
using AutoCare.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Interfaces.EntityServices
{
    public interface ISocialMediaService
    {
        Task<ResultResponse<List<GetSocialMediasQueryResult>>> GetSocialMedias(GetSocialMediasQuery getSocialMediasQuery);
        Task<ResultResponse<GetByIdSocialMediaQueryResult>> GetByIdSocialMedia(GetByIdSocialMediaQuery getByIdSocialMediaQuery);
        Task<CommandResponse> CreateSocialMedia(CreateSocialMediaCommand createSocialMediaCommand);
        Task<CommandResponse> UpdateSocialMedia(UpdateSocialMediaCommand updateSocialMediaCommand);
        Task<CommandResponse> DeleteSocialMedia(DeleteSocialMediaCommand deleteSocialMediaCommand);
    }
}
