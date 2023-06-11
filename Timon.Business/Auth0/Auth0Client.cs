using IdentityModel.Client;
using IdentityModel.OidcClient;
using IdentityModel.OidcClient.Browser;

namespace Timon.Business.Auth0;

public class Auth0Client
{
    private readonly OidcClient _oIdcClient;

    public Auth0Client(Auth0ClientOptions options)
    {
        _oIdcClient = new OidcClient(new OidcClientOptions
        {
            Authority = $"https://{options.Domain}",
            ClientId = options.ClientId,
            Scope = options.Scope,
            RedirectUri = options.RedirectUri,
            Browser = options.Browser
        });
    }

    public IdentityModel.OidcClient.Browser.IBrowser Browser
    {
        get => _oIdcClient.Options.Browser;
        set => _oIdcClient.Options.Browser = value;
    }

    public async Task<LoginResult> LoginAsync()
    {
        return await _oIdcClient.LoginAsync();
    }

    public async Task<BrowserResult> LogoutAsync()
    {
        var logoutParameters = new Dictionary<string, string>
        {
            {"client_id", _oIdcClient.Options.ClientId },
            {"returnTo", _oIdcClient.Options.RedirectUri }
        };

        var logoutRequest = new LogoutRequest();
        var endSessionUrl = new RequestUrl($"{_oIdcClient.Options.Authority}/v2/logout")
            .Create(new Parameters(logoutParameters));
        var browserOptions = new BrowserOptions(endSessionUrl, _oIdcClient.Options.RedirectUri)
        {
            Timeout = TimeSpan.FromSeconds(logoutRequest.BrowserTimeout),
            DisplayMode = logoutRequest.BrowserDisplayMode
        };

        var browserResult = await _oIdcClient.Options.Browser.InvokeAsync(browserOptions);

        return browserResult;
    }
}