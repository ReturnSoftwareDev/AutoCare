using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Interfaces.GenericRepositories;
using AutoCare.Application.Mediator.Commands.ServiceCommands;
using AutoCare.Application.Mediator.Queries.ServiceQueries;
using AutoCare.Application.Mediator.Results.ServiceResults;
using AutoCare.Application.UnitOfWorks;
using AutoCare.Domain.Entities;
using AutoMapper;
using System.Net;

namespace AutoCare.Persistance.Repositories.EntityServices;
internal class ServiceService : IServiceService
{
    private readonly IWriteRepository<Service> _writeRepository;
    private readonly IReadRepository<Service> _readRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ServiceService(IWriteRepository<Service> writeRepository, IReadRepository<Service> readRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommandResponse> CreateService(CreateServiceCommand createServiceCommand)
    {
        var mapped = _mapper.Map<Service>(createServiceCommand);

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

    public async Task<CommandResponse> DeleteService(DeleteServiceCommand deleteServiceCommand)
    {
        var model = await _readRepository.GetSingleByIdAsync(deleteServiceCommand.Id);

        if (model is not null)
        {
            model.IsDeleted = true;

            await _writeRepository.UpdateAsync(model);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                return new CommandResponse("Kayıt silindi", (int)HttpStatusCode.OK);
            }
            else
            {
                return new CommandResponse("Kayıt silinirken hata oluştu", (int)HttpStatusCode.BadRequest);
            }

        }
        else
        {
            return new CommandResponse("Silinecek kayıt bulunamadı", (int)HttpStatusCode.NotFound);
        }
    }

    public async Task<ResultResponse<GetServiceByIdQueryResult>> GetByIdService(GetServiceByIdQuery getByIdServiceQuery)
    {
        var model = await _readRepository.GetSingleByIdAsync(getByIdServiceQuery.Id);

        if (model is not null)
        {
            var data = _mapper.Map<GetServiceByIdQueryResult>(model);
            return new ResultResponse<GetServiceByIdQueryResult>(data, "Aranılan kayıt getirildi", (int)HttpStatusCode.OK);
        }
        else
        {
            return new ResultResponse<GetServiceByIdQueryResult>(null, "Aranılan kayıt bulunmadı", (int)HttpStatusCode.OK);
        }
    }

    public async Task<ResultResponse<List<GetServiceQueryResult>>> GetServices(GetServiceQuery getServicesQuery)
    {
        var model = await _readRepository.GetAllAsync();

        if (model.Any())
        {
            var mapped = _mapper.Map<List<GetServiceQueryResult>>(model);
            return new ResultResponse<List<GetServiceQueryResult>>(mapped, "Kayıtlar getirildi", (int)HttpStatusCode.OK);
        }
        else
        {
            return new ResultResponse<List<GetServiceQueryResult>>(null, "Kayıtlar bulunamadı", (int)HttpStatusCode.NotFound);
        }
    }

    public async Task<CommandResponse> UpdateService(UpdateServiceCommand updateServiceCommand)
    {
        var model = await _readRepository.GetSingleByIdAsync(updateServiceCommand.Id);

        if (model is not null)
        {
            model = _mapper.Map(updateServiceCommand, model);

            await _writeRepository.UpdateAsync(model);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result > 0)
            {
                return new CommandResponse("Kayıt başarıyla güncellendi", (int)HttpStatusCode.OK);
            }
            else
            {
                return new CommandResponse("Kayıt güncellenemedi", (int)HttpStatusCode.BadRequest);
            }
        }
        else
        {
            return new CommandResponse("Güncellenecek kayıt bulunamadı", (int)HttpStatusCode.NotFound);
        }

        throw new NotImplementedException();
    }
}
