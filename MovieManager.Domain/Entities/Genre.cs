namespace MovieManager.Domain.Entities;

public class Genre
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Movie> Movies { get; } = new List<Movie>();
}