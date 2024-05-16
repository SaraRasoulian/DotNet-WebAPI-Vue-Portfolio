using System.Net.Http.Headers;

namespace WebApi.Tests.Integration;

public class BaseControllerTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    protected readonly HttpClient _httpClient;

    protected BaseControllerTest(IntegrationTestWebApplicationFactory factory)
    {
        _httpClient = factory.CreateDefaultClient();
    }

    /// <summary>
    /// Authenticate using the one user created by database seed
    /// </summary>
    /// <returns></returns>
    protected async Task AuthenticateAsync()
    {
        UserLoginDto userLoginDto = new UserLoginDto
        {
            UserName = "admin",
            Password = "123456"
        };

        var loginResponse = await _httpClient.PostAsJsonAsync("api/identity/login", userLoginDto);
        string token = await loginResponse.Content.ReadAsStringAsync();

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}