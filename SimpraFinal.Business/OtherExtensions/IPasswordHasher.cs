using SimpraFinal.Data.Entities;

namespace SimpraFinal.Business.OtherExtensions;

public interface IPasswordHasher
{
    void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
    bool VerifyPasswordHash(string password, byte[] storedHash);
}