namespace InfoTrackScraper.Interfaces
{
    public interface IHtmlParser
    {
        IReadOnlyList<int> ExtractPositions(string html, string targetUrl);
    }
}
