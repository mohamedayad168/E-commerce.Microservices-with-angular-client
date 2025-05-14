using AutoMapper;
using E_commerce.Core.DTO;
using E_commerce.Core.Entities;
using E_commerce.Core.Repository_Contracts;
using E_commerce.Core.Service_Contracts;

namespace E_commerce.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }
        public async Task<AuthResponse?> Login(LoginRequest loginRequest)
        {
            ApplicationUser user = await userRepository.GetUserByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return null;
            };

            return
                mapper.Map<AuthResponse>(user) with { succes = true, Token = "token" };
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
            AuthResponse authResponse =
                mapper.Map<AuthResponse>(response) with { succes = true, Token = "token" };
            return authResponse;
        }
    }
}
