namespace WebApi.Tests.Integration.ControllersTests;

public class MessagesControllerTests : BaseControllerTest
{
    public MessagesControllerTests(IntegrationTestWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task GetAll_Returns_SuccessStatusCode()
    {
        // Arrange
        await AuthenticateAsync();

        // Act
        var response = await _httpClient.GetAsync("api/messages");

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
        var response = await _httpClient.GetAsync("api/messages/" + id);

        // Assert
        response.EnsureSuccessStatusCode();
        response.Should().HaveStatusCode(HttpStatusCode.NoContent);
    }

    [Fact]
    public async Task GetNumberOfUnread_Returns_SuccessStatusCode()
    {
        // Arrange
        await AuthenticateAsync();

        // Act
        var response = await _httpClient.GetAsync("api/messages/unread");

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task Post_Returns_OK_With_MessageDto()
    {
        // Arrange
        await AuthenticateAsync();
        MessageDto dto = new MessageDto
        {
            Name = "Sahra Farahani",
            Email = "farahani@gmail.com",
            Content = "Lorem ipsum is a placeholder text."
        };

        // Act
        var response = await _httpClient.PostAsJsonAsync("/api/messages", dto);

        // Assert
        response.EnsureSuccessStatusCode();

        var responseDto = await response.Content.ReadFromJsonAsync<MessageDto>();
        responseDto.Name.Should().Be(dto.Name);
        responseDto.Email.Should().Be(dto.Email);
        responseDto.Content.Should().Be(dto.Content);
        responseDto.IsRead.Should().BeFalse();

        // Should return 1 unread message
        var unReadResponse = await _httpClient.GetAsync("api/messages/unread");
        var numberOfUnread = await unReadResponse.Content.ReadAsStringAsync();
        numberOfUnread.Should().Be("1");
    }

    [Fact]
    public async Task Delete_With_Valid_Id_Returns_SuccessStatusCode()
    {
        // Arrange
        await AuthenticateAsync();

        // Create a new message
        MessageDto dto = new MessageDto
        {
            Name = "Sahra Farahani",
            Email = "farahani@gmail.com",
            Content = "Lorem ipsum is a placeholder text."
        };

        var postResponse = await _httpClient.PostAsJsonAsync("/api/messages", dto);
        var addedMessage = await postResponse.Content.ReadFromJsonAsync<MessageDto>();

        // Act
        var deleteResponse = await _httpClient.DeleteAsync("/api/messages/" + addedMessage.Id);

        // Assert
        postResponse.EnsureSuccessStatusCode();
        deleteResponse.EnsureSuccessStatusCode();
    }
}
