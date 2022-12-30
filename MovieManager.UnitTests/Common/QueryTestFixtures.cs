namespace MovieManager.UnitTests.Common;

public class QueryTestFixtures : IDisposable
{
    public MovieManagerDbContext Context { get; set; }
    public IMapper Mapper { get; private set; }

    public QueryTestFixtures()
    {
        Context = MovieDbContextFactory.Create().Object;

        var configurationMapper = new MapperConfiguration(config =>
        {
            config.AddProfile<MappingProfile>();
        });

        Mapper = configurationMapper.CreateMapper();
    }

    public void Dispose()
    {
        MovieDbContextFactory.Destroy(Context);
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixtures>
    {

    }
}