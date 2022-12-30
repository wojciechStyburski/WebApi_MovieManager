namespace MovieManager.Domain.Entities;

public class Movie
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int ReleaseYear { get; set; }
    public Guid DirectorId { get; set; }
    public Director Director { get; set; }
    public ICollection<Genre> Genres { get; } = new List<Genre>();
}