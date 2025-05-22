namespace InfoTrackScraper.Interfaces
{
    public interface IGoogleClient
    {
        Task<string> FetchHtmlAsync(string searchTerm);
    }
}
