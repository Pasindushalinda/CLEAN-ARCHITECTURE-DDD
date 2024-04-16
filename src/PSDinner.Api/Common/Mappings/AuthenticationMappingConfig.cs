using Mapster;
using PSDinner.Application.Authentication.Command.Register;
using PSDinner.Application.Authentication.Common;
using PSDinner.Application.Authentication.Query;
using PSDinner.Contracts.Authentication;

namespace PSDinner.Api.Common.Mappings;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // config.NewConfig<RegisterRequest, RegisterCommand>();
        //
        // config.NewConfig<LoginRequest, LoginQuery>();

        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}