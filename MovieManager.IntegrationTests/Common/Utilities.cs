using Newtonsoft.Json;

namespace MovieManager.IntegrationTests.Common;

public class Utilities
{
    public static void InitializeDbForTests(MovieManagerDbContext context)
    {
        var directorId = Guid.Parse("3A94D38C-DEC5-4EB8-A6B9-7AE2E49EFFB3");

        var director = new Director()
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
    }

    public static async Task<T> GetResponseContentTask<T> (HttpResponseMessage response)
    {
        var stringResponse = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<T>(stringResponse);

        return result;
    }
}