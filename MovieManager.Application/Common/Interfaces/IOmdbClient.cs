namespace MovieManager.Application.Common.Interfaces;

public interface IOmdbClient
{
    Task<string> GetMovie(string searchFilter, CancellationToken cancellationToken);
}