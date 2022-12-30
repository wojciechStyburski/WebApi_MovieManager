namespace MovieManager.UnitTests.Common;

public static class MovieDbContextFactory
{
    public static Mock<MovieManagerDbContext> Create()
    {
        var options = new DbContextOptionsBuilder<MovieManagerDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        
        var mock = new Mock<MovieManagerDbContext>(options) {CallBase = true};
        
        var context = mock.Object;
        context.Database.EnsureCreated();

        var directorId = Guid.Parse("9A3BA877-22F0-4245-B5FA-47CD4F45FD77");

        var director = new Domain.Entities.Director()
        {
            Id = directorId,
            DirectorName = new PersonName()
            {
                FirstName = "Wojciech",
                LastName = "Smarzowski"
            }
        };
        context.Directors.Add(director);

        var directorBiography = new DirectorBiography()
        {
            Id = Guid.NewGuid(),
            DirectorId = directorId,
            DateOfBirth = new DateTime(1963, 1, 18),
            CityOfBirth = "Korczyna",
            CountryOfBirth = "Polska",
            Education = "Państwowa Wyższa Szkoła Filmowa, Telewizyjna i Teatralna im. Leona Schillera w Łodzi",
            Career = string.Empty,
            Summary = string.Empty,
            DateOfDeath = null
        };
        context.DirectorBiographies.Add(directorBiography);

        var genre = new Genre()
        {
            Id = Guid.NewGuid(),
            Name = "Dramat"
        };
        context.Genres.Add(genre);

        var movie = new Movie()
        {
            Id = Guid.NewGuid(),
            DirectorId = directorId,
            Genres = { genre },
            Name = "Wesele",
            ReleaseYear = 2004
        };
        context.Movies.Add(movie);

        context.SaveChanges();

        return mock;

    }

    public static void Destroy(MovieManagerDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}