using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Fake;

internal sealed class FakeUserInformationReceivedContext : IFake
{
    private FakeUserInformationReceivedContext()
    {
      
    }
    private static ClaimsPrincipal Principal(string authenticationType) => new(new ClaimsIdentity(null, authenticationType));

    public static Func<string[], UserInformationReceivedContext> CreateFake => (constructorParameters) =>
    {
        var openIdConnectOptions = new OpenIdConnectOptions()
        {
            ClientId = constructorParameters[0],
        };
        var authenticationScheme = new AuthenticationScheme("", "", typeof(FakeAuthenticationHandler));
        var principal = Principal(constructorParameters[1]);
        var httpContext = new DefaultHttpContext();
         return new UserInformationReceivedContext(httpContext, authenticationScheme, openIdConnectOptions, principal, null);
    };
}

internal class FakeAuthenticationHandler : AuthenticationHandler<FakeAuthenticationOptions>
{
    private FakeAuthenticationHandler(IOptionsMonitor<FakeAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        throw new NotImplementedException();
    }
}
internal class FakeAuthenticationOptions : AuthenticationSchemeOptions
{
    public FakeAuthenticationOptions()
    {

    }
}