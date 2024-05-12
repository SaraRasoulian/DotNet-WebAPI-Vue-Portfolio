namespace WebApi.Tests.Integration;

public class BaseControllerTest : IClassFixture<IntegrationTestWebApplicationFactory>
{
    protected readonly HttpClient _httpClient;

    protected BaseControllerTest(IntegrationTestWebApplicationFactory factory)
    {
        _httpClient = factory.CreateDefaultClient();
    }
}