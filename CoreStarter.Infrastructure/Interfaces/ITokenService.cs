using CoreStarter.EFCoreIdentity;

namespace CoreStarter.Infrastructure.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}