using InfoTrackScraper.Interfaces;

namespace InfoTrackScraper.Services
{
    public class GetSearchPositions : IGetSearchPositions
    {
        private readonly IGoogleClient _googleClient;
        private readonly IHtmlParser _parser;
        private readonly string _searchTerm;
        private readonly string _targetUrl;

        public GetSearchPositions(
            IGoogleClient googleClient,
            IHtmlParser parser,
            string searchTerm,
            string targetUrl)
        {
            _googleClient = googleClient;
            _parser = parser;
            _searchTerm = searchTerm;
            _targetUrl = targetUrl;
        }

        public async Task<IReadOnlyList<int>> ExecuteAsync()
        {
            var html = await _googleClient.FetchHtmlAsync(_searchTerm);
            var positions = _parser.ExtractPositions(html, _targetUrl);
            return positions.Any() ? positions : new List<int> { 0 };
        }
    }
}
