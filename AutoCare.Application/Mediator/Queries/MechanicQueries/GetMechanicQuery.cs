﻿using AutoCare.Application.Base;
using AutoCare.Application.Mediator.Results.MechanicResults;
using MediatR;

namespace AutoCare.Application.Mediator.Queries.MechanicQueries;
public class GetMechanicQuery : IRequest<ResultResponse<List<GetMechanicQueryResult>>>
{
}
