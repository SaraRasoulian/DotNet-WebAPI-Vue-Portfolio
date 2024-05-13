namespace WebApi.Tests.Integration.ControllersTests;

public class ExperiencesControllerTests : BaseControllerTest
{
    public ExperiencesControllerTests(IntegrationTestWebApplicationFactory factory) : base(factory)
    { }

    [Fact]
    public async Task GetAll_Returns_SuccessStatusCode()
    {
        // Act
        var response = await _httpClient.GetAsync("api/experiences");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
