using PSDinner.Domain.Entities;

namespace PSDinner.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);