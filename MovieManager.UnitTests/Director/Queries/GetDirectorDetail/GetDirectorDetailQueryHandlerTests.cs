namespace MovieManager.UnitTests.Director.Queries.GetDirectorDetail;

[Collection("QueryCollection")]
public class GetDirectorDetailQueryHandlerTests
{
    private readonly MovieManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetDirectorDetailQueryHandlerTests(QueryTestFixtures fixtures)
    {
        _context = fixtures.Context;
        _mapper = fixtures.Mapper;
    }

    [Fact]
    public async Task can_get_director_detail_by_id()
    {
        var handler = new GetDirectorDetailQueryHandler(_context, _mapper);
        var directorId = Guid.Parse("9A3BA877-22F0-4245-B5FA-47CD4F45FD77");
        var directorId2 = Guid.Parse("51A340E7-C0B9-465C-89D9-2C931B712514");
        var result = await handler.Handle(new GetDirectorDetailQuery() { DirectorId = directorId }, CancellationToken.None);

        result.ShouldBeOfType<DirectorDetailViewModel>();
        result.FullName.ShouldBe("Wojciech Smarzowski");
    }
}