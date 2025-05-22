namespace InfoTrackScraper.Interfaces
{
    public interface ISearchService
    {
        Task<IReadOnlyList<int>> GetPositionsAsync(string searchTerm, string targetUrl);
    }
}
