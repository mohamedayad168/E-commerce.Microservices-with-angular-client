using E_commerce.Core.DTO;
using E_commerce.Core.Entities;
using E_commerce.Core.Repository_Contracts;
using E_commerce.Core.Service_Contracts;

namespace E_commerce.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<AuthResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser user = await userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return null;
            };

            return
                new AuthResponse(user.UserId, user.UserName, user.Email, user.Gender, "token", true);
        }

        public async Task<AuthResponse> Register(RegisterRequest register)
        {
            ApplicationUser user = new ApplicationUser()
            {
                UserId = Guid.NewGuid(),
                UserName = register.UserName,
                Email = register.Email,
                Password = register.Password,
                Gender = register.Gender.ToString(),
            };
            var response = await userRepository.AddUser(user);
            if (response == null)
                return null;
            AuthResponse authResponse = new AuthResponse
                (response.UserId, response.UserName, response.Email, user.Gender, "token", true);
            return authResponse;
        }
    }
}
