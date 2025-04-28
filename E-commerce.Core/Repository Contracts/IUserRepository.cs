using E_commerce.Core.Entities;

namespace E_commerce.Core.Repository_Contracts
{
    public interface IUserRepository
    {
        Task<ApplicationUser?> AddUser(ApplicationUser user);
        Task<ApplicationUser?> GetUserByEmailAndPassword(string email, string password);
    }
}
