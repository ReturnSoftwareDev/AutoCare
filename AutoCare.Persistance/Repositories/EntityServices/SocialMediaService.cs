using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Interfaces.GenericRepositories;
using AutoCare.Application.Mediator.Commands.SocialMediaCommands;
using AutoCare.Application.Mediator.Queries.SocialMediaQueries;
using AutoCare.Application.Mediator.Results.SocialMediaResults;
using AutoCare.Application.UnitOfWorks;
using AutoCare.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoCare.Persistance.Repositories.EntityServices
{
    public class SocialMediaService : ISocialMediaService
    {
        private readonly IWriteRepository<SocialMedia> _writeRepository;
        private readonly IReadRepository<SocialMedia> _readRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SocialMediaService(IWriteRepository<SocialMedia> writeRepository, IReadRepository<SocialMedia> readRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CommandResponse> CreateSocialMedia(CreateSocialMediaCommand createSocialMediaCommand)
        {
            var mapped = _mapper.Map<SocialMedia>(createSocialMediaCommand);

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

        public async Task<CommandResponse> DeleteSocialMedia(DeleteSocialMediaCommand deleteSocialMediaCommand)
        {
            var model = await _readRepository.GetSingleByIdAsync(deleteSocialMediaCommand.Id);

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

        public async Task<ResultResponse<GetByIdSocialMediaQueryResult>> GetByIdSocialMedia(GetByIdSocialMediaQuery getByIdSocialMediaQuery)
        {
            var model = await _readRepository.GetSingleByIdAsync(getByIdSocialMediaQuery.Id);

            if(model is not null)
            {
                var data = _mapper.Map<GetByIdSocialMediaQueryResult>(model);
                return new ResultResponse<GetByIdSocialMediaQueryResult>(data, "Aranılan kayıt getirildi", (int)HttpStatusCode.OK);
            }
            else
            {
                return new ResultResponse<GetByIdSocialMediaQueryResult>(null, "Aranılan kayıt bulunmadı", (int)HttpStatusCode.OK);
            }
        }

        public async Task<ResultResponse<List<GetSocialMediasQueryResult>>> GetSocialMedias(GetSocialMediasQuery getSocialMediasQuery)
        {
            var model = await _readRepository.GetAllAsync();

            if (model.Any())
            {
                var mapped = _mapper.Map<List<GetSocialMediasQueryResult>>(model);
                return new ResultResponse<List<GetSocialMediasQueryResult>>(mapped, "Kayıtlar getirildi", (int)HttpStatusCode.OK);
            }
            else
            {
                return new ResultResponse<List<GetSocialMediasQueryResult>>(null, "Kayıtlar bulunamadı", (int)HttpStatusCode.NotFound);
            }
        }

        public async Task<CommandResponse> UpdateSocialMedia(UpdateSocialMediaCommand updateSocialMediaCommand)
        {
            var model = await _readRepository.GetSingleByIdAsync(updateSocialMediaCommand.Id);

            if(model is not null)
            {
                model = _mapper.Map(updateSocialMediaCommand, model);

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
