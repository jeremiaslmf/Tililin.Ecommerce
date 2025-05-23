using Tililin.Infrastructure.Data.Context;
using Tililin.Domain.Entities;
using Tililin.Domain.Enums;
using Tililin.Application.Common.Hash;

namespace Tililin.Infrastructure.Data.Seed
{
    public static class DbInitializer
    {
        public static void Seed(TililinDbContext context, IAppPasswordHasher passwordHasher)
        {
            // Se já existe usuário admin, não insere novamente
            if (context.Usuarios.Any(u => u.Email == "admin@dev.com"))
                return;

            var senhaHash = passwordHasher.Hash("123456");

            var usuario = Usuario.New(
                nome: "admin",
                email: "admin@dev.com",
                senhaHash: senhaHash,
                roles: [UserRoleType.Admin]
            );

            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }
    }
}
