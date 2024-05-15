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

    [Fact]
    public async Task GetById_Returns_SuccessStatusCode()
    {
        // Arrange
        await AuthenticateAsync();
        Guid id = Guid.NewGuid();

        // Act
        var response = await _httpClient.GetAsync("api/experiences/" + id);

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Unauthorized_GetById_Returns_UnauthorizedStatusCode()
    {
        // Arrange
        Guid id = Guid.NewGuid();

        // Act
        var response = await _httpClient.GetAsync("api/experiences/" + id);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.Unauthorized);
    }

    [Fact]
    public async Task Post_Returns_OK_With_ExperienceDto()
    {
        // Arrange
        await AuthenticateAsync();
        ExperienceDto dto = new ExperienceDto
        {
            CompanyName = "Google",
            StartYear = "2020",
            EndYear = "2022",
            Description = "Lorem ipsum is a placeholder text",
        };

        // Act
        var response = await _httpClient.PostAsJsonAsync("/api/experiences", dto);

        // Assert
        response.EnsureSuccessStatusCode();

        var responseDto = await response.Content.ReadFromJsonAsync<ExperienceDto>();
        dto.Should().BeEquivalentTo(responseDto, options => options.Excluding(x => x.Id));
    }

    [Fact]
    public async void Put_Returns_SuccessStatusCode()
    {
        // Arrange
        // Create a new experience
        await AuthenticateAsync();
        ExperienceDto dto = new ExperienceDto
        {
            CompanyName = "Google",
            StartYear = "2020",
            EndYear = "2022",
            Description = "Lorem ipsum is a placeholder text",
        };

        var postResponse = await _httpClient.PostAsJsonAsync("/api/experiences", dto);
        var addedExperience = await postResponse.Content.ReadFromJsonAsync<ExperienceDto>();

        // Update the added experience  
        addedExperience.CompanyName = "Apple";

        // Act
        var updateResponse = await _httpClient.PutAsJsonAsync("/api/experiences/" + addedExperience.Id, addedExperience);

        // Assert
        updateResponse.EnsureSuccessStatusCode();
        postResponse.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Delete_With_Valid_Id_Returns_SuccessStatusCode()
    {
        // Arrange
        // Create a new experience
        await AuthenticateAsync();
        ExperienceDto dto = new ExperienceDto
        {
            CompanyName = "Google",
            StartYear = "2020",
            EndYear = "2022",
            Description = "Lorem ipsum is a placeholder text",
        };

        var postResponse = await _httpClient.PostAsJsonAsync("/api/experiences", dto);
        var addedExperience = await postResponse.Content.ReadFromJsonAsync<ExperienceDto>();

        // Act
        var deleteResponse = await _httpClient.DeleteAsync("/api/experiences/" + addedExperience.Id);

        // Assert
        postResponse.EnsureSuccessStatusCode();
        deleteResponse.EnsureSuccessStatusCode();
    }
}
