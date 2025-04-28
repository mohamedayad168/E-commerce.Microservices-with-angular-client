namespace E_commerce.Core.DTO
{
    public record RegisterRequest(string? UserName, string? Password, string? Email, GenderOption Gender);
}
