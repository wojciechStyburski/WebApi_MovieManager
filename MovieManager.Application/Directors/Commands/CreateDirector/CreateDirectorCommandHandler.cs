namespace MovieManager.Application.Directors.Commands.CreateDirector;

public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, Guid>
{
    private readonly IMovieManagerDbContext _movieManagerDbContext;

    public CreateDirectorCommandHandler(IMovieManagerDbContext movieManagerDbContext)
    {
        _movieManagerDbContext = movieManagerDbContext;
    }
    public async Task<Guid> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
    {
        var director = new Director()
        {
            Id = Guid.NewGuid(),
            DirectorName = new PersonName() { FirstName = request.FirstName, LastName = request.LastName },
        };

        _movieManagerDbContext.Directors.Add(director);

        var directorBiography = new DirectorBiography()
        {
            Id = Guid.NewGuid(),
            DateOfBirth = request.DateOfBirth,
            CountryOfBirth = request.CountryOfBirth,
            CityOfBirth = request.CityOfBirth,
            Education = request.Education,
            Career = request.Career,
            Summary = request.Summary,
            DateOfDeath = request.DateOfDeath,
            DirectorId = director.Id
        };

        _movieManagerDbContext.DirectorBiographies.Add(directorBiography);

        await _movieManagerDbContext.SaveChangesAsync(cancellationToken);

        return director.Id;
    }
}