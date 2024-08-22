using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Commands.AboutCommands;
using AutoCare.Application.Mediator.Queries.AboutQueries;
using AutoCare.Application.Mediator.Results.AboutResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Interfaces.EntityServices;
public interface IAboutService
{
    Task<ResultResponse<List<GetAboutQueryResult>>> GetAbouts(GetAboutQuery getAboutQuery);
    Task<ResultResponse<GetAboutByIdQueryResult>> GetByIdAbout(GetAboutByIdQuery getByIdAboutQuery);
    Task<CommandResponse> CreateAbout(CreateAboutCommand createAboutCommand);
    Task<CommandResponse> UpdateAbout(UpdateAboutCommand updateAboutCommand);
    Task<CommandResponse> DeleteAbout(DeleteAboutCommand deleteAboutCommand);
}
