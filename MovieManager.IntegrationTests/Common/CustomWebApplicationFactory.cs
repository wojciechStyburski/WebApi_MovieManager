using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace MovieManager.IntegrationTests.Common;

public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        try
        {
            builder.UseSerilog();

            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<MovieManagerDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                services.AddScoped<IMovieManagerDbContext>(provider => provider.GetService<MovieManagerDbContext>()!);

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedService = scope.ServiceProvider;
                var context = scopedService.GetRequiredService<MovieManagerDbContext>();
                var logger = scopedService.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                context.Database.EnsureCreated();

                try
                {
                    Utilities.InitializeDbForTests(context);
                }
                catch (Exception ex)
                {
                    logger.LogError($"Seeding database error with message {ex.Message}");
                }
            }).UseEnvironment("Test");
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<HttpClient> GetAuthClientAsync()
    {
        var client = CreateClient();
        var token = await GetAccessTokenAsync(client, "alice", "Pass123$");
        client.SetBearerToken(token);

        return client;
    }

    private async Task<string> GetAccessTokenAsync(HttpClient client, string username, string password)
    {
        var discoveryDocument = await client.GetDiscoveryDocumentAsync("https://localhost:5001");

        if (discoveryDocument.IsError)
            throw new Exception(discoveryDocument.Error);

        var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest()
        {
            Address = "https://localhost:5001/connect/token",
            ClientId = "postman",
            ClientSecret = "secret",
            Scope = "api1",
            UserName = username,
            Password = password
            
        });

        if (response.IsError)
            throw new Exception(response.ErrorDescription);

        return response.AccessToken;
    }
}