using Moq;

public class GetSearchPositionsTests
{
    [Fact]
    public async Task Returns_positions_when_target_url_is_found()
    {
        // Arrange
        var fakeHtml = "<html>some google html</html>";
        var expectedPositions = new List<int> { 1, 5 };

        var googleClient = new Mock<IGoogleClient>();
        googleClient.Setup(g => g.FetchHtmlAsync("search term")).ReturnsAsync(fakeHtml);

        var parser = new Mock<IHtmlParser>();
        parser.Setup(p => p.ExtractPositions(fakeHtml, "example.com")).Returns(expectedPositions);

        var command = new GetSearchPositions(googleClient.Object, parser.Object, "search term", "example.com");

        // Act
        var result = await command.ExecuteAsync();

        // Assert
        Assert.Equal(expectedPositions, result);
    }

    [Fact]
    public async Task Returns_zero_when_no_positions_found()
    {
        var fakeHtml = "<html>no matches</html>";

        var googleClient = new Mock<IGoogleClient>();
        googleClient.Setup(g => g.FetchHtmlAsync("search term")).ReturnsAsync(fakeHtml);

        var parser = new Mock<IHtmlParser>();
        parser.Setup(p => p.ExtractPositions(fakeHtml, "example.com")).Returns(new List<int>());

        var command = new GetSearchPositions(googleClient.Object, parser.Object, "search term", "example.com");

        var result = await command.ExecuteAsync();

        Assert.Equal(new[] { 0 }, result);
    }
}
