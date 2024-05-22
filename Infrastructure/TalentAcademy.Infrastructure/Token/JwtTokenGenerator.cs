using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TalentAcademy.Application.Dtos;
using TalentAcademy.Application.Features.Queries.Auth;

namespace TalentAcademy.Infrastructure.Token
{

    //CheckUserQueryResponse
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(CheckUserQueryResponse dto)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrWhiteSpace(dto.Role))
                claims.Add(new Claim("Role", dto.Role));

            claims.Add(new Claim(ClaimTypes.Role, dto.Role));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));

            if (!string.IsNullOrWhiteSpace(dto.UserName))
                claims.Add(new Claim("UserName", dto.UserName));

            claims.Add(new Claim("FullName", dto.FullName));

            var expireDate = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.Expire);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var signInCredential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expireDate,
                signingCredentials: null
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            return new TokenResponseDto(handler.WriteToken(token), expireDate);
        }
    }
}
