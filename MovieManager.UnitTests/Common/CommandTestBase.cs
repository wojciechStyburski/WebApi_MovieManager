namespace MovieManager.UnitTests.Common;

public class CommandTestBase : IDisposable
{
    protected readonly MovieManagerDbContext _context;
    protected readonly Mock<MovieManagerDbContext> _contextMock;

    public CommandTestBase()
    {
        _contextMock = MovieDbContextFactory.Create();
        _context = _contextMock.Object;
    }

    public void Dispose()
    {
        MovieDbContextFactory.Destroy(_context);
    }
}