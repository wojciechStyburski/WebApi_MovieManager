namespace MovieManager.Application.Common.Interfaces;

public interface IMovieManagerDbContext
{
    DbSet<Director> Directors { get; set; }
    DbSet<DirectorBiography> DirectorBiographies { get; set; }
    DbSet<Genre> Genres { get; set; }
    DbSet<Movie> Movies { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}