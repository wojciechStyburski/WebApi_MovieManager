namespace MovieManager.UnitTests.Director.Commands.CreateDirector;

public class CreateDirectorCommandHandlerTests : CommandTestBase
{
    private readonly CreateDirectorCommandHandler _handler;

    public CreateDirectorCommandHandlerTests()
    {
        _handler = new CreateDirectorCommandHandler(_context);
    }

    [Fact]
    public async Task handle_given_valid_request_should_insert_director()
    {
        var command = new CreateDirectorCommand()
        {
            FirstName = "Jan",
            LastName = "Kowalski",
            DateOfBirth = new DateTime(1991, 5, 30),
            CityOfBirth = "Kraków"
        };

        var result = await _handler.Handle(command, CancellationToken.None);

        var dir = await _context.Directors.FirstAsync(x => x.Id == result, CancellationToken.None);

        dir.ShouldNotBeNull();
    }
}