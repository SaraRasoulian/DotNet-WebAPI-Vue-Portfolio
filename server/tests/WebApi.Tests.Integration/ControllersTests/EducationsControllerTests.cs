namespace WebApi.Tests.Integration.ControllersTests;

public class EducationsControllerTests : BaseControllerTest
{
    public EducationsControllerTests(IntegrationTestWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetAll_Returns_OK()
    {
        // Arrange
        // Act
        var response = await _httpClient.GetAsync("api/educations");

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
