using ErrorOr;
using MediatR;
using PSDinner.Application.Authentication.Common;

namespace PSDinner.Application.Authentication.Query;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;