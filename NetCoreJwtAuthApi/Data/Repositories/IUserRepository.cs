using NetCoreJwtAuthApi.Models;

namespace NetCoreJwtAuthApi.Data.Repositories
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
    }
}
