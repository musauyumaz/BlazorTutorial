namespace Application.Features.Commands.Users
{
    public record UserDTO(
        string Id,
        string FirstName,
        string LastName,
        string EmailAddress,
        bool IsActive,
        DateTime CreatedDate,
        string FullName);
}



