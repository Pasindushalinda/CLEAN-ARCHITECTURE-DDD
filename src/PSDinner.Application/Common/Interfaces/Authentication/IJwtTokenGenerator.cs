namespace PSDinner.Application.Common.Infrastructure.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(string userId, string firstName, string lastName, string email);
}