using PSDinner.Application.Authentication;
using Microsoft.AspNetCore.Mvc;
using PSDinner.Contracts.Authentication;

namespace PSDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController(IAuthenticationService autheticationService) : ControllerBase
{
    private readonly IAuthenticationService _autheticationService = autheticationService;

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _autheticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token
        );
        
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _autheticationService.Login(
            request.Email,
            request.Password
        );

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token
        );
        
        return Ok(request);
    }
}