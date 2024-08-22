using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Interfaces.GenericRepositories;
using AutoCare.Application.Mediator.Commands.AboutCommands;
using AutoCare.Application.Mediator.Queries.AboutQueries;
using AutoCare.Application.Mediator.Results.AboutResults;
using AutoCare.Application.UnitOfWorks;
using AutoCare.Domain.Entities;
using AutoMapper;
using System.Net;

namespace AutoCare.Persistance.Repositories.EntityServices
{
    public class AboutService : IAboutService
    {
        private readonly IWriteRepository<About> _writeRepository;
        private readonly IReadRepository<About> _readRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AboutService(IWriteRepository<About> writeRepository, IReadRepository<About> readRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse> CreateAbout(CreateAboutCommand createAboutCommand)
        {
            var mapped = _mapper.Map<About>(createAboutCommand);

            await _writeRepository.CreateAsync(mapped);

            var result = await _unitOfWork.SaveChangesAsync();

            if(result > 0)
            {
                return new CommandResponse("Kayıt başarıyla eklendi", (int)HttpStatusCode.Created);
            }
            else
            {
                return new CommandResponse("Kayıt ekleme başarısız", (int)HttpStatusCode.BadRequest);
            }
        }

        public async Task<CommandResponse> DeleteAbout(DeleteAboutCommand deleteAboutCommand)
        {
            var model = await _readRepository.GetSingleByIdAsync(deleteAboutCommand.Id);

            if(model is not null)
            {
                model.IsDeleted = true;

                await _writeRepository.UpdateAsync(model);

                var result = await _unitOfWork.SaveChangesAsync();

                if(result > 0)
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

        public async Task<ResultResponse<GetAboutByIdQueryResult>> GetByIdAbout(GetAboutByIdQuery getByIdAboutQuery)
        {
            var model = await _readRepository.GetSingleByIdAsync(getByIdAboutQuery.Id);

            if(model is not null)
            {
                var data = _mapper.Map<GetAboutByIdQueryResult>(model);
                return new ResultResponse<GetAboutByIdQueryResult>(data, "Aranılan kayıt getirildi", (int)HttpStatusCode.OK);
            }
            else
            {
                return new ResultResponse<GetAboutByIdQueryResult>(null, "Aranılan kayıt bulunmadı", (int)HttpStatusCode.OK);
            }
        }

        public async Task<ResultResponse<List<GetAboutQueryResult>>> GetAbouts(GetAboutQuery getAboutsQuery)
        {
            var model = await _readRepository.GetAllAsync();

            if (model.Any())
            {
                var mapped = _mapper.Map<List<GetAboutQueryResult>>(model);
                return new ResultResponse<List<GetAboutQueryResult>>(mapped, "Kayıtlar getirildi", (int)HttpStatusCode.OK);
            }
            else
            {
                return new ResultResponse<List<GetAboutQueryResult>>(null, "Kayıtlar bulunamadı", (int)HttpStatusCode.NotFound);
            }
        }

        public async Task<CommandResponse> UpdateAbout(UpdateAboutCommand updateAboutCommand)
        {
            var model = await _readRepository.GetSingleByIdAsync(updateAboutCommand.Id);

            if(model is not null)
            {
                model = _mapper.Map(updateAboutCommand, model);

                await _writeRepository.UpdateAsync(model);

                var result = await _unitOfWork.SaveChangesAsync();

                if(result > 0)
                {
                    return new CommandResponse("Kayıt başarıyla güncellendi",(int)HttpStatusCode.OK);
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
}
