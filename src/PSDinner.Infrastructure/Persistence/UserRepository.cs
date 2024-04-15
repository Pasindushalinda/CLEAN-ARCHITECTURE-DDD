using PSDinner.Application.Common.Interfaces.Persistence;
using PSDinner.Domain.Entities;

namespace PSDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();

    public User? GetUserByEmail(string email)
    {
        return _users.FirstOrDefault(x => x.Email == email);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }
}