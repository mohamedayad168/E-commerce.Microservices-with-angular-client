using E_commerce.Core.DTO;
using E_commerce.Core.Entities;
using E_commerce.Core.Repository_Contracts;

namespace E_commerce.Infrastructre.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();
            return user;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string email, string password)
        {
            var user = new ApplicationUser()
            {
                Email = email,
                Password = password,
                UserId = Guid.NewGuid(),
                Gender = GenderOption.Male.ToString(),
                UserName = "Name",


            };
            return user;
        }
    }
}
