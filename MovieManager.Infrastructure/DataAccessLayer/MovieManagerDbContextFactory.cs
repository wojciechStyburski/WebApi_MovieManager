namespace MovieManager.Infrastructure.DataAccessLayer;

public class MovieManagerDbContextFactory : DesignTimeDbContextFactoryBase<MovieManagerDbContext>
{
    protected override MovieManagerDbContext CreateNewInstance(DbContextOptions<MovieManagerDbContext> options)
    {
        return new MovieManagerDbContext(options);
    }
}