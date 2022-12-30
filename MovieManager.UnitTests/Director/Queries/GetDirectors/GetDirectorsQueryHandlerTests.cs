namespace MovieManager.UnitTests.Director.Queries.GetDirectors;

[Collection("QueryCollection")]
public class GetDirectorsQueryHandlerTests
{
    private readonly MovieManagerDbContext _context;
    private readonly IMapper _mapper;

    public GetDirectorsQueryHandlerTests(QueryTestFixtures fixtures)
    {
        _context = fixtures.Context;
        _mapper = fixtures.Mapper;
    }

    [Fact]
    public async Task can_get_directors_collection()
    {
        var handler = new GetDirectorsQueryHandler(_context, _mapper);
        var result = await handler.Handle(new GetDirectorsQuery(), CancellationToken.None);

        result.ShouldBeOfType<DirectorsViewModel>();
        result.Directors.Count().ShouldBe(2);
    }
}