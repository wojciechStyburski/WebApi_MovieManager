

namespace MovieManager.Application.Directors.Queries.GetDirectors;

public class GetDirectorsQueryHandler : IRequestHandler<GetDirectorsQuery, DirectorsViewModel>
{
    private readonly IMovieManagerDbContext _movieManagerDbContext;
    private readonly IMapper _mapper;

    public GetDirectorsQueryHandler(IMovieManagerDbContext movieManagerDbContext, IMapper mapper)
    {
        _movieManagerDbContext = movieManagerDbContext;
        _mapper = mapper;
    }

    public async Task<DirectorsViewModel> Handle(GetDirectorsQuery request, CancellationToken cancellationToken)
    {
        var directors = await _movieManagerDbContext
            .Directors
            .AsNoTracking()
            .ProjectTo<DirectorDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var directorsViewModel = new DirectorsViewModel() { Directors = directors };

        return directorsViewModel;
    }
}