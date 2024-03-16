namespace Application.Features.Auths.DTOs
{
    public record TokenDTO(string AccessToken, DateTime Expiration, string RefreshToken);
    
}



