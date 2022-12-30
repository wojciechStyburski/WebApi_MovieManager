namespace MovieManager.Infrastructure.DataAccessLayer;

public static class Seed
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        var directorId = "51A340E7-C0B9-465C-89D9-2C931B712514";
        var firstMovieId = "3F25D6FD-DB78-49A9-9D79-E210ABF7FA5F";
        var secondMovieId = "ABA6CF27-8F2A-4C85-B75D-EA9A0065AC40";

        modelBuilder.Entity<Director>(d =>
        {
            d.HasData(new Director()
            {
                Id = Guid.Parse(directorId)
            });
            d.OwnsOne(d => d.DirectorName).HasData(new
            {
                DirectorId = Guid.Parse(directorId),
                FirstName = "Andrzej",
                LastName = "Wajda"
            });
        });

        modelBuilder.Entity<Movie>().HasData
        (
            new Movie()
            {
                Id = Guid.Parse(firstMovieId),
                DirectorId = Guid.Parse(directorId),
                Name = "Pan Tadeusz",
                ReleaseYear = 1999
            },
            new Movie()
            {
                Id = Guid.Parse(secondMovieId),
                DirectorId = Guid.Parse(directorId),
                Name = "Popiół i diament",
                ReleaseYear = 1958
            }
        );

        modelBuilder.Entity<Genre>().HasData
        (
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Dramat"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Komedia"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Thriller"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Horror"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Akcja"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Science fiction"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Dokumentalny"
            },
            new Genre()
            {
                Id = Guid.NewGuid(),
                Name = "Musical"
            }
        );
    }
}