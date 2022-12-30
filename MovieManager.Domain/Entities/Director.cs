namespace MovieManager.Domain.Entities;

public class Director
{
    public Guid Id { get; set; }
    public PersonName DirectorName { get; set; }
    public ICollection<Movie> Movies { get; } = new List<Movie>();
    public DirectorBiography DirectorBiography { get; set; }
}