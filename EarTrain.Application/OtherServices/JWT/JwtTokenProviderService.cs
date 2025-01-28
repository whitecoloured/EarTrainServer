using EarTrain.Core.Enums;
using EarTrain.Core.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EarTrain.Application.OtherServices.JWT
{
    public class JwtTokenProviderService(IOptions<JWTOptions> jwtOptions)
    {
        private readonly IOptions<JWTOptions> _jwtOptions = jwtOptions;

        public string GenereateJWTAccessToken(Guid UserID, UserRole Role)
        {
            Claim[] claims = [new Claim("ID", UserID.ToString()), new Claim("Role", Role.ToString())];

            SigningCredentials signingCredentials = new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.SecretKey)), SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                issuer:_jwtOptions.Value.Issuer,
                audience:_jwtOptions.Value.Audience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddMinutes(30)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateJWTRefreshToken(Guid UserID, UserRole Role)
        {
            Claim[] claims=[new Claim("ID", UserID.ToString()), new Claim("Role", Role.ToString())];

            SigningCredentials signingCredentials = new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.SecretKey)), SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new(
                issuer: _jwtOptions.Value.Issuer,
                audience: _jwtOptions.Value.Audience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.Now.AddDays(30)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
