namespace WebApi.Tests.Integration.ControllersTests;

public class ProfilesControllerTests : BaseControllerTest
{
    public ProfilesControllerTests(IntegrationTestWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task Get_Returns_OK_With_ProfileDto()
    {
        // Act
        var response = await _httpClient.GetAsync("api/profiles");

        // Assert
        response.EnsureSuccessStatusCode();

        // Should return the one profile created by database seed
        var profile = await response.Content.ReadFromJsonAsync<ProfileDto>();
        profile.Should().NotBeNull();
    }

    [Fact]
    public async void Put_Returns_SuccessStatusCode()
    {
        // Arrange
        await AuthenticateAsync();

        // Get the one profile created by database seed
        var response = await _httpClient.GetAsync("api/profiles");
        ProfileDto profileDto = await response.Content.ReadFromJsonAsync<ProfileDto>();

        // Update the profile 
        profileDto.FirstName = "Emma";

        // Act
        var updateResponse = await _httpClient.PutAsJsonAsync("/api/profiles/", profileDto);

        // Assert
        updateResponse.EnsureSuccessStatusCode();
    }
}