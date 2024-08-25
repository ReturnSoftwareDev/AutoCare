using AutoCare.Application.Interfaces.TokenServices;
using AutoCare.Application.Mediator.Results.UserResults;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutoCare.Application.Tools
{
    public class TokenService : ITokenService
    {
        private readonly JwtTokenModel _jwtTokenModel;

        public TokenService(IOptions<JwtTokenModel> options)
        {
            _jwtTokenModel = options.Value;
        }

        public async Task<JwtResponseModel> GenerateToken(UserLoginQueryResult model)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenModel.Key));
            var dateTimeNow = DateTime.UtcNow;
            List<Claim> claims = new List<Claim>()
            {
                    new Claim("Name", model.Name),
                    new Claim("Surname", model.Surname),
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(ClaimTypes.MobilePhone, model.Phone),
                    new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),

            };
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                    issuer: _jwtTokenModel.ValidIssuer,
                    audience: _jwtTokenModel.ValidAudience,
                    claims: claims,
                    notBefore: dateTimeNow,
                    expires: dateTimeNow.Add(TimeSpan.FromSeconds(20)),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return await Task.FromResult(new JwtResponseModel
            {
                Token = handler.WriteToken(jwtSecurityToken),
                ExpireDate = dateTimeNow.Add(TimeSpan.FromSeconds(20)),
                RefreshToken = await RefreshToken(),
            });
        }

        public async Task<string> RefreshToken()
        {
            byte[] number = new byte[32];

            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }




    }
}
