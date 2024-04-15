using System;
using PSDinner.Domain.Entities;

namespace PSDinner.Application.Authentication;

public record AuthenticationResult(
    User User,
    string Token);