namespace InfoTrackScraper.Interfaces
{
    public interface IGetSearchPositions
    {
        Task<IReadOnlyList<int>> ExecuteAsync();
    }
}
