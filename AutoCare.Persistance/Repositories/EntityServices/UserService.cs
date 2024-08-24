using AutoCare.Application.Base;
using AutoCare.Application.Interfaces.EntityServices;
using AutoCare.Application.Interfaces.GenericRepositories;
using AutoCare.Application.Mediator.Commands.UserCommands;
using AutoCare.Application.Mediator.Queries.UserQueries;
using AutoCare.Application.Mediator.Results.UserResults;
using AutoCare.Application.Tools;
using AutoCare.Application.UnitOfWorks;
using AutoCare.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Persistance.Repositories.EntityServices
{
    public class UserService : IUserService
    {
        private readonly IWriteRepository<User> _writeRepository;
        private readonly IReadRepository<User> _readRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly JwtGeneratorToken _jwtGeneratorToken;

        public UserService(IWriteRepository<User> writeRepository, IMapper mapper, IUnitOfWork unitOfWork, IReadRepository<User> readRepository, JwtGeneratorToken jwtGeneratorToken)
        {
            _writeRepository = writeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _readRepository = readRepository;
            _jwtGeneratorToken = jwtGeneratorToken;
        }

        public async Task<ResultResponse<JwtResponseModel>> LoginUser(UserLoginQuery userLoginQuery)
        {
            var user = await _readRepository.GetSingleAsync(x=>x.Email == userLoginQuery.Email && x.Password == userLoginQuery.Password);

            if(user is not null)
            {
                var model = _mapper.Map<UserLoginQueryResult>(user);

                var token =await _jwtGeneratorToken.GenerateToken(model);

                user.RefreshToken = token.RefreshToken;

                user.RefreshTokenEndDate = token.ExpireDate.AddMinutes(1);

                await _writeRepository.UpdateAsync(user);

                await _unitOfWork.SaveChangesAsync();

                return new ResultResponse<JwtResponseModel>(token, "Giriş yapıldı", (int)HttpStatusCode.OK);
            }

            else
            {
                return new ResultResponse<JwtResponseModel>(null, "Giriş başarısız", (int)HttpStatusCode.BadRequest);
            }
        }

        public async Task<ResultResponse<JwtResponseModel>> RefreshTokenLoginUser(RefreshTokenLoginQuery refreshTokenLoginQuery)
        {
            var user = await _readRepository.GetSingleAsync(x => x.RefreshToken == refreshTokenLoginQuery.RefreshToken);

            if(user is not null)
            {
                var model = _mapper.Map<UserLoginQueryResult>(user);

                var token = await _jwtGeneratorToken.GenerateToken(model);

                user.RefreshToken = token.RefreshToken;

                user.RefreshTokenEndDate = token.ExpireDate.AddMinutes(1);

                await _writeRepository.UpdateAsync(user);

                await _unitOfWork.SaveChangesAsync();

                return new ResultResponse<JwtResponseModel>(token, "Giriş yapıldı", (int)HttpStatusCode.OK);
            }
            else
            {
                return new ResultResponse<JwtResponseModel>(null, "Giriş başarısız", (int)HttpStatusCode.BadRequest);
            }
        }

        public async Task<CommandResponse> RegisterUser(CreateUserCommand createUserCommand)
        {
            var mapped = _mapper.Map<User>(createUserCommand);  

            await _writeRepository.CreateAsync(mapped);

            var result = await _unitOfWork.SaveChangesAsync();

            if(result > 0)
            {
                return new CommandResponse("Kullanıcı kayıt edildi", (int)HttpStatusCode.Created);
            }
            else
            {
                return new CommandResponse("Kullanıcı kaydı başarısız!", (int)HttpStatusCode.BadRequest);
            }
        }



    }
}
