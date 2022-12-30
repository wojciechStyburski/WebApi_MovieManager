namespace MovieManager.Infrastructure;

public static class InfrastructureExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MovieManagerDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("MovieManagerConnectionString"));
        });

        services.AddScoped<IMovieManagerDbContext, MovieManagerDbContext>();

        services.AddScoped<IDateTime, DateTimeService>();

        services.AddScoped<IFileStore, FileStore.FileStore>();
        services.AddScoped<IFileWrapper, FileWrapper>();
        services.AddScoped<IDirectoryWrapper, DirectoryWrapper>();

        services.AddHttpClient("OmdbClient", options =>
        {
            options.BaseAddress = new Uri(configuration.GetSection("OmdbUrl").Value);
            options.Timeout = new TimeSpan(0, 0, 10);
            options.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }).ConfigurePrimaryHttpMessageHandler(sp => new HttpClientHandler());
        
        services.AddScoped<IOmdbClient, OmdbClient>();

        return services;
    }
}