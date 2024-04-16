using ErrorOr;
using MediatR;
using PSDinner.Application.Authentication.Common;

namespace PSDinner.Application.Authentication.Command.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;