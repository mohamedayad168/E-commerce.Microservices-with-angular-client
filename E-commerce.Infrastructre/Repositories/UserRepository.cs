using Dapper;
using E_commerce.Core.Entities;
using E_commerce.Core.Repository_Contracts;
using E_commerce.Infrastructre.DbContext;

namespace E_commerce.Infrastructre.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly DapperDbContext dbContext;

        public UserRepository(DapperDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();
            string query = "INSERT INTO public.\"Users\"(\"UserId\",\"Email\",\"UserName\",\"Gender\",\"Password\")" +
                "VALUES(@UserId,@Email,@UserName,@Gender,@Password)";
            int rowCountAffected = await dbContext.connection.ExecuteAsync(query, user);
            if (rowCountAffected > 0)
            {
                return user;
            }
            return null;
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string email, string password)
        {
            var query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";

            ApplicationUser? user = await dbContext.connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, new { Email = email, Password = password });


            return user;
        }
    }
}
