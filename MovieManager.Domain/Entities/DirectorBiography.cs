namespace MovieManager.Domain.Entities;

public class DirectorBiography
{
    public Guid Id { get; set; }
    public DateTime DateOfBirth{ get; set; }
    public string CountryOfBirth { get; set; }
    public string CityOfBirth { get; set; }
    public string Education { get; set; }
    public string Career { get; set; }
    public string Summary { get; set; }
    public DateTime? DateOfDeath { get; set; }
    public Guid DirectorId { get; set; }
    public Director Director { get; set; }
}