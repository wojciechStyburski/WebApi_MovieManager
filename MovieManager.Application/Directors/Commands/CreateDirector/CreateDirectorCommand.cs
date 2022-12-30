namespace MovieManager.Application.Directors.Commands.CreateDirector;

public class CreateDirectorCommand : IRequest<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string CountryOfBirth { get; set; }
    public string CityOfBirth { get; set; }
    public string Education { get; set; }
    public string Career { get; set; }
    public string Summary { get; set; }
    public DateTime? DateOfDeath { get; set; }
}