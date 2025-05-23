using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tililin.Application.Common.Jwt;
using Tililin.Domain.Entities;

namespace Tililin.Infrastructure.Jwt;

public class JwtTokenGenerator(IConfiguration configuration) : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration = configuration;

    public string Generate(Usuario usuario)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
        var issuer = jwtSettings["Issuer"];
        var audience = jwtSettings["Audience"];
        var expires = DateTime.UtcNow.AddHours(2);

        List<Claim> claims = 
        [
            new Claim(JwtRegisteredClaimNames.Sub, usuario.PublicId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Nome),
            new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
            new Claim("usuarioId", usuario.PublicId.ToString()),
        ];

        foreach (var role in usuario.RoleList)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }


        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: expires,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
