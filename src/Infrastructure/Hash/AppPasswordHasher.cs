using Tililin.Application.Common.Hash;

namespace Tililin.Infrastructure.Hash;

public class AppPasswordHasher : IAppPasswordHasher
{
    public string Hash(string password)
        => BCrypt.Net.BCrypt.HashPassword(password);

    public bool Verify(string password, string hash)
        => BCrypt.Net.BCrypt.Verify(password, hash);
}
