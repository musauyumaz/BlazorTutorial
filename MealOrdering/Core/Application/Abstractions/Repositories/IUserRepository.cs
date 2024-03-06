using Domain.Entities;

namespace Application.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task UpdatePasswordAsync(string email);
}
