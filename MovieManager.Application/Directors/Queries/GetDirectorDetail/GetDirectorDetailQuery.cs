namespace MovieManager.Application.Directors.Queries.GetDirectorDetail;

public class GetDirectorDetailQuery : IRequest<DirectorDetailViewModel>
{
    public Guid DirectorId { get; set; }
}