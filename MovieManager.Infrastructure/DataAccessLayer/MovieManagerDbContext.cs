namespace MovieManager.Infrastructure.DataAccessLayer;

public class MovieManagerDbContext : DbContext, IMovieManagerDbContext
{
    public MovieManagerDbContext(DbContextOptions<MovieManagerDbContext> options) : base(options)
    { }

    public DbSet<Director> Directors { get; set; }
    public DbSet<DirectorBiography> DirectorBiographies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Configure entities
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        //Seed data
        modelBuilder.SeedData();
    }
}