using System;
using PSDinner.Application.Common.Infrastructure.Authentication;

namespace PSDinner.Application.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator;

    public AuthenticationService(IJwtTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }
    public AuthenticationResult Login(string email, string password)
    {
        var userId = Guid.NewGuid();
        
        return new AuthenticationResult(
            userId,
            "Amichai",
            "Mantinband",
            email,
            "token");
    }

    public AuthenticationResult Register (string firstName, string lastName, string email, string password)
    {
        var userId = Guid.NewGuid();
        
        var token = _tokenGenerator.GenerateToken(userId.ToString(), firstName, lastName, email);
        
        return new AuthenticationResult(
            userId,
            "firstName",
            "lastName",
            email,
            token
        );
    }
}