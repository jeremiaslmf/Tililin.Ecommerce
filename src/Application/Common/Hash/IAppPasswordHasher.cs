namespace Tililin.Application.Common.Hash;

public interface IAppPasswordHasher
{
    string Hash(string password);
    bool Verify(string password, string hash);
}
