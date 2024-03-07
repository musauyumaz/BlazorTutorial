using Domain.Entities;

namespace Application.Commons.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task UpdatePasswordAsync(string email);
}
