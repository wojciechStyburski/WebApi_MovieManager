namespace MovieManager.Application.Directors.Commands.DeleteDirector;

public class DeleteDirectorCommand : IRequest
{
    public Guid DirectorId { get; set; }
}