using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Interfaces.GenericRepositories;
using AutoCare.Application.Mediator.Commands.MechanicCommands;
using AutoCare.Application.Mediator.Queries.MechanicQueries;
using AutoCare.Application.Mediator.Results.MechanicResults;
using AutoCare.Application.UnitOfWorks;
using AutoCare.Domain.Entities;
using AutoMapper;
using System.Net;

namespace AutoCare.Persistance.Repositories.EntityServices;
public class MechanicService : IMechanicService
{
    private readonly IWriteRepository<Mechanic> _writeRepository;
    private readonly IReadRepository<Mechanic> _readRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public MechanicService(IWriteRepository<Mechanic> writeRepository, IReadRepository<Mechanic> readRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommandResponse> CreateMechanic(CreateMechanicCommand createMechanicCommand)
    {
        var mapped = _mapper.Map<Mechanic>(createMechanicCommand);

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

    public async Task<CommandResponse> DeleteMechanic(DeleteMechanicCommand deleteMechanicCommand)
    {
        var model = await _readRepository.GetSingleByIdAsync(deleteMechanicCommand.Id);

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

    public async Task<ResultResponse<GetMechanicByIdQueryResult>> GetByIdMechanic(GetMechanicByIdQuery getByIdMechanicQuery)
    {
        var model = await _readRepository.GetSingleByIdAsync(getByIdMechanicQuery.Id);

        if (model is not null)
        {
            var data = _mapper.Map<GetMechanicByIdQueryResult>(model);
            return new ResultResponse<GetMechanicByIdQueryResult>(data, "Aranılan kayıt getirildi", (int)HttpStatusCode.OK);
        }
        else
        {
            return new ResultResponse<GetMechanicByIdQueryResult>(null, "Aranılan kayıt bulunmadı", (int)HttpStatusCode.OK);
        }
    }

    public async Task<ResultResponse<List<GetMechanicQueryResult>>> GetMechanics(GetMechanicQuery getMechanicsQuery)
    {
        var model = await _readRepository.GetAllAsync();

        if (model.Any())
        {
            var mapped = _mapper.Map<List<GetMechanicQueryResult>>(model);
            return new ResultResponse<List<GetMechanicQueryResult>>(mapped, "Kayıtlar getirildi", (int)HttpStatusCode.OK);
        }
        else
        {
            return new ResultResponse<List<GetMechanicQueryResult>>(null, "Kayıtlar bulunamadı", (int)HttpStatusCode.NotFound);
        }
    }

    public async Task<CommandResponse> UpdateMechanic(UpdateMechanicCommand updateMechanicCommand)
    {
        var model = await _readRepository.GetSingleByIdAsync(updateMechanicCommand.Id);

        if (model is not null)
        {
            model = _mapper.Map(updateMechanicCommand, model);

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
