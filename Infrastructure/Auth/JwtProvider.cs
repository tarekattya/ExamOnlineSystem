
using ExamOnlineSystem.Infrastructure.Auth;
using ExamOnlineSystem.Shared.Auth;
using ExamOnlineSystem.Shared.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExamOnlineSystem.Application.Auth
{
    public class JwtProvider(IOptions<jwtSettings> options) : IJwtProvider
    {
        private readonly jwtSettings _options = options.Value;

        public (string token, int expiresIn) GenerateToken(ApplicationUser user ,  IEnumerable<string> Roles)
        {
             var claims = new List<Claim> {

                new Claim(JwtRegisteredClaimNames.Sub , user.Id),
                new Claim(JwtRegisteredClaimNames.Email , user.Email!),
                new Claim(JwtRegisteredClaimNames.Name , user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())
                };

                 claims.AddRange(Roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));

            var signingCredentials = new SigningCredentials(symmetricSecurityKey , SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(

                issuer: _options.Issuer,
            audience: _options.Audience,
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddMinutes(_options.ExpireMinutes)
                );

            return (token: new JwtSecurityTokenHandler().WriteToken(token), _options.ExpireMinutes);
  
        }

        public string? ValidateToken(string token)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));

            try
            {
                tokenhandler.ValidateToken(token, new TokenValidationParameters
                {
                    IssuerSigningKey = symmetricSecurityKey,
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _options.Issuer,
                    ValidAudience = _options.Audience,
                    ClockSkew = TimeSpan.Zero

                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
               return jwtToken.Claims.First(x=> x.Type == JwtRegisteredClaimNames.Sub).Value.ToString();
            }
            catch 
            {

                return null;
            }
        }

       
    }
}
