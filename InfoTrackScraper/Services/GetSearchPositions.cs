using InfoTrackScraper.Interfaces;

namespace InfoTrackScraper.Services
{
    public class GetSearchPositions : IGetSearchPositions
    {
        public GetSearchPositions(IGoogleClient googleClient, IHtmlParser parser, string searchTerm, string targetUrl)
        {
            // Constructor is empty for now
        }

        public Task<IReadOnlyList<int>> ExecuteAsync()
        {
            // Just return something dummy to make it compile
            return Task.FromResult<IReadOnlyList<int>>(new List<int>());
        }
    }
}
