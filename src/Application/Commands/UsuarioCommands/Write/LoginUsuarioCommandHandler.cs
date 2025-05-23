using MediatR;
using Tililin.Application.Commands.Base;
using Tililin.Application.Common.Hash;
using Tililin.Application.Common.Jwt;
using Tililin.Domain.Exceptions;
using Tililin.Domain.Repositories;
using Tililin.Shared.DTOs.Responses;

namespace Tililin.Application.Commands.UsuarioCommands.Write;

public class LoginUsuarioCommandHandler(IUnitOfWork uow, IUsuarioRepository repository, IAppPasswordHasher passwordHasher, IJwtTokenGenerator jwtTokenGenerator)
    : CommandHandlerBase<IUsuarioRepository>(uow, repository), 
      IRequestHandler<LoginUsuarioCommand, UsuarioLoginResponse>
{
    private readonly IAppPasswordHasher _passwordHasher = passwordHasher;
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

    public async Task<UsuarioLoginResponse> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
    {
        var email = request.Email.Trim().ToLowerInvariant();
        var usuario = await _repository.GetByEmailAsync(email, cancellationToken);

        if (usuario == null || !_passwordHasher.Verify(request.Password, usuario.PasswordHash))
            throw new BusinessException("Usuário ou senha inválidos.");

        var token = _jwtTokenGenerator.Generate(usuario);

        return UsuarioLoginResponse.Of(token, usuario);        
    }
}
