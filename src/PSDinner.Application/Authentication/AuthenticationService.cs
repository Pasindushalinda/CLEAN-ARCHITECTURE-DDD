using ErrorOr;
using PSDinner.Application.Common.Interfaces.Authentication;
using PSDinner.Application.Common.Interfaces.Persistence;
using PSDinner.Domain.Common.Errors;
using PSDinner.Domain.Entities;

namespace PSDinner.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator tokenGenerator,
        IUserRepository userRepository)
    {
        _tokenGenerator = tokenGenerator;
        _userRepository = userRepository;
    }
    
    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.User.DuplicateEmail;
        }

        if (password != user.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        User user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.AddUser(user);

        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}