using E_commerce.Core.DTO;

namespace E_commerce.Core.Service_Contracts
{
    public interface IUserService
    {
        Task<AuthResponse?> Login(LoginRequest loginRequest);
        Task<AuthResponse?> Register(RegisterRequest register);
    }
}
