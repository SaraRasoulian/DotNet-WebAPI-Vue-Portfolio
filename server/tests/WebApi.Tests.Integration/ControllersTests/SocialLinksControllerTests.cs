namespace WebApi.Tests.Integration.ControllersTests;

public class SocialLinksControllerTests : BaseControllerTest
{
    public SocialLinksControllerTests(IntegrationTestWebApplicationFactory factory) : base(factory)
    { }

    [Fact]
    public async Task GetAll_Returns_SuccessStatusCode()
    {
        // Act
        var response = await _httpClient.GetAsync("api/social-links");

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetById_Returns_SuccessStatusCode()
    {
        // Arrange
        await AuthenticateAsync();

        // Get a random id
        Guid id = Guid.NewGuid();

        // Act
        var response = await _httpClient.GetAsync("api/social-links/" + id);

        // Assert
        response.EnsureSuccessStatusCode();
        response.Should().HaveStatusCode(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task Unauthorized_GetById_Returns_UnauthorizedStatusCode()
    {
        // Arrange
        Guid id = Guid.NewGuid();

        // Act
        var response = await _httpClient.GetAsync("api/social-links/" + id);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Post_Returns_OK_With_SocialLinkDto()
    {
        // Arrange
        await AuthenticateAsync();
        SocialLinkDto dto = new SocialLinkDto
        {
            Name = "GitHub",
            URL = "https://github.com/SaraRasoulian"
        };

        // Act
        var response = await _httpClient.PostAsJsonAsync("/api/social-links", dto);

        // Assert
        response.EnsureSuccessStatusCode();

        var responseDto = await response.Content.ReadFromJsonAsync<SocialLinkDto>();
        dto.Should().BeEquivalentTo(responseDto, options => options.Excluding(x => x.Id));
    }

    [Fact]
    public async void Put_Returns_SuccessStatusCode()
    {
        // Arrange
        // Create a new social link
        await AuthenticateAsync();
        SocialLinkDto dto = new SocialLinkDto
        {
            Name = "GitHub",
            URL = "https://github.com/SaraRasoulian"
        };

        var postResponse = await _httpClient.PostAsJsonAsync("/api/social-links", dto);
        var addedSocialLink = await postResponse.Content.ReadFromJsonAsync<SocialLinkDto>();

        // Update the added social link  
        addedSocialLink.Name = "GitLab";

        // Act
        var updateResponse = await _httpClient.PutAsJsonAsync("/api/social-links/" + addedSocialLink.Id, addedSocialLink);

        // Assert
        updateResponse.EnsureSuccessStatusCode();
        postResponse.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Delete_With_Valid_Id_Returns_SuccessStatusCode()
    {
        // Arrange
        // Create a new social link
        await AuthenticateAsync();
        SocialLinkDto dto = new SocialLinkDto
        {
            Name = "GitHub",
            URL = "https://github.com/SaraRasoulian"
        };

        var postResponse = await _httpClient.PostAsJsonAsync("/api/social-links", dto);
        var addedSocialLink = await postResponse.Content.ReadFromJsonAsync<SocialLinkDto>();

        // Act
        var deleteResponse = await _httpClient.DeleteAsync("/api/social-links/" + addedSocialLink.Id);

        // Assert
        postResponse.EnsureSuccessStatusCode();
        deleteResponse.EnsureSuccessStatusCode();

        var getResponse = await _httpClient.GetAsync("api/social-links/" + addedSocialLink.Id);
        getResponse.Should().HaveStatusCode(HttpStatusCode.NoContent);
    }
}
