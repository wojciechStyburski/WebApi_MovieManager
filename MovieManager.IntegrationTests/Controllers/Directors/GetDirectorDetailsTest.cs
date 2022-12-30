
namespace MovieManager.IntegrationTests.Controllers.Directors;

public class GetDirectorDetailsTest : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public GetDirectorDetailsTest(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    /*
    [Fact]
    public async Task given_director_id_returns_director_detail()
    {
        var client = await _factory.GetAuthClientAsync();
        var id = Guid.Parse("3A94D38C-DEC5-4EB8-A6B9-7AE2E49EFFB3");
        var respone = await client.GetAsync($"/api/directors/{id}");
        respone.EnsureSuccessStatusCode();

        var directorViewModel = await Utilities.GetResponseContentTask<DirectorDetailViewModel>(respone);

        directorViewModel.ShouldNotBeNull();
 
    }*/
}