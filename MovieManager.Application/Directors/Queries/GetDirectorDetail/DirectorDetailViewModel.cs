namespace MovieManager.Application.Directors.Queries.GetDirectorDetail;

public class DirectorDetailViewModel : IMapFrom<Director>
{
    public string FullName { get; set; }
    public string LastMovieName { get; set; }

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Director, DirectorDetailViewModel>()
            .ForMember(d => d.FullName, map => map.MapFrom(src => src.DirectorName.ToString()))
            .ForMember(d => d.LastMovieName, map => map.MapFrom<LastMovieNameResolver>());
    }

    private class LastMovieNameResolver : IValueResolver<Director, object, string>
    {
        public string Resolve(Director source, object destination, string destMember, ResolutionContext context)
        {
            if (!source.Movies.Any()) return string.Empty;

            var lastMovie = source.Movies.MaxBy(d => d.ReleaseYear);
            return lastMovie.Name;

        }
    }
}

