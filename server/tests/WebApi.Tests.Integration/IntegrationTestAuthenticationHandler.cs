using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace WebApi.Tests.Integration;

public class IntegrationTestAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    public IntegrationTestAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        throw new NotImplementedException();
    }
}
