namespace MovieManager.Application.Directors.Commands.DeleteDirector;

public class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand>
{
    private readonly IMovieManagerDbContext _movieManagerDbContext;

    public DeleteDirectorCommandHandler(IMovieManagerDbContext movieManagerDbContext)
    {
        _movieManagerDbContext = movieManagerDbContext;
    }

    public async Task<Unit> Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
    {
        var directorToRemove = await _movieManagerDbContext.Directors.Where(d => d.Id == request.DirectorId).FirstOrDefaultAsync(cancellationToken);

        if (directorToRemove != null)
            _movieManagerDbContext.Directors.Remove(directorToRemove);

        await _movieManagerDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}