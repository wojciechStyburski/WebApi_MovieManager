namespace MovieManager.Application.Directors.Queries.GetDirectors;

public class DirectorDto : IMapFrom<Director>
{
    public string FullName { get; set; }

    public void Mapping(Profile profile)
    {
        profile
            .CreateMap<Director, DirectorDto>()
            .ForMember(d => d.FullName, map => map.MapFrom(src => src.DirectorName.ToString()));
    }
}