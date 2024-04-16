using ErrorOr;
using MediatR;
using PSDinner.Application.Authentication.Common;
using PSDinner.Application.Common.Interfaces.Authentication;
using PSDinner.Application.Common.Interfaces.Persistence;
using PSDinner.Domain.Common.Errors;
using PSDinner.Domain.Entities;

namespace PSDinner.Application.Authentication.Query;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(request.Email) is not User user)
        {
            return Errors.User.DuplicateEmail;
        }

        if (request.Password != user.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}