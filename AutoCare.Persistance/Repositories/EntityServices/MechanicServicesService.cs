using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Interfaces.GenericRepositories;
using AutoCare.Application.Mediator.Commands.MechanicServicesCommands;
using AutoCare.Application.Mediator.Queries.MechanicServicesQueries;
using AutoCare.Application.Mediator.Results.MechanicResults;
using AutoCare.Application.Mediator.Results.MechanicServicesResults;
using AutoCare.Application.UnitOfWorks;
using AutoCare.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Persistance.Repositories.EntityServices;
public class MechanicServicesService : IMechanicServicesService
{
    private readonly IWriteRepository<MechanicServices> _writeRepository;
    private readonly IReadRepository<MechanicServices> _readRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MechanicServicesService(IWriteRepository<MechanicServices> writeRepository, IReadRepository<MechanicServices> readRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<CommandResponse> CreateMechanicServices(CreateMechanicServicesCommand createMechanicServiceCommand)
    {
        var mapped = _mapper.Map<MechanicServices>(createMechanicServiceCommand);

        await _writeRepository.CreateAsync(mapped);

        var result = await _unitOfWork.SaveChangesAsync();

        if (result > 0)
        {
            return new CommandResponse("Kayıt başarıyla eklendi", (int)HttpStatusCode.Created);
        }
        else
        {
            return new CommandResponse("Kayıt ekleme başarısız", (int)HttpStatusCode.BadRequest);
        }
    }

    public async Task<ResultResponse<List<GetMechanicServicesQueryResult>>> GetMechanicServices(GetMechanicServicesQuery getMechanicQuery)
    {
        var model = await _readRepository.GetAllAsync();

        if (model.Any())
        {
            var mapped = _mapper.Map<List<GetMechanicServicesQueryResult>>(model);
            return new ResultResponse<List<GetMechanicServicesQueryResult>>(mapped, "Kayıtlar getirildi", (int)HttpStatusCode.OK);
        }
        else
        {
            return new ResultResponse<List<GetMechanicServicesQueryResult>>(null, "Kayıtlar bulunamadı", (int)HttpStatusCode.NotFound);
        }
    }
}
