namespace E_commerce.Core.DTO
{
    public record AuthResponse(Guid UserId, string? UserName, string? Email, string? Gender, string? Token, bool succes)
    {
        public AuthResponse() : this(default, default, default, default, default, default)
        {

        }
    }
}
