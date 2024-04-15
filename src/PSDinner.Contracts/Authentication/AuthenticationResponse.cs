using System;
using PSDinner.Domain.Entities;

namespace PSDinner.Contracts.Authentication;

public record AuthenticationResponse(
    User User,
    string Token);