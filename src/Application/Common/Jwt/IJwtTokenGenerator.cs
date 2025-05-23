using Tililin.Domain.Entities;

namespace Tililin.Application.Common.Jwt;

public interface IJwtTokenGenerator
{
    string Generate(Usuario usuario);
}
