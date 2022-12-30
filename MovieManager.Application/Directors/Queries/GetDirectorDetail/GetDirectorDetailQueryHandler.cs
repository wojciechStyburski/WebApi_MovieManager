namespace MovieManager.Application.Directors.Queries.GetDirectorDetail;

public class GetDirectorDetailQueryHandler : IRequestHandler<GetDirectorDetailQuery, DirectorDetailViewModel>
{
    private readonly IMovieManagerDbContext _movieManagerDbContext;
    private readonly IMapper _mapper;

    public GetDirectorDetailQueryHandler(IMovieManagerDbContext movieManagerDbContext, IMapper mapper)
    {
        _movieManagerDbContext = movieManagerDbContext;
        _mapper = mapper;
    }

    public async Task<DirectorDetailViewModel> Handle(GetDirectorDetailQuery request, CancellationToken cancellationToken)
    {
        var director = await _movieManagerDbContext
            .Directors
            .AsNoTracking()
            .Include(d => d.Movies)
            .Where(d => d.Id == request.DirectorId)
            .FirstOrDefaultAsync(cancellationToken);

        var directorViewModel = _mapper
            .Map<DirectorDetailViewModel>(director);

        return directorViewModel;
    }
}