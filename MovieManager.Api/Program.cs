var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .Enrich.FromLogContext()
        .Enrich.WithMachineName()
        .Enrich.WithProcessId()
        .Enrich.WithThreadId()
        .WriteTo.Console()
        .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
        .WriteTo.Seq("http://localhost:5341");
});

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowedOrigins", config =>
    {
        config.AllowAnyOrigin();
    });
});


if (builder.Environment.IsEnvironment("Test"))
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("MovieManagerConnectionString"));
    });

    builder.Services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();
    builder.Services.AddIdentityServer().AddApiAuthorization<ApplicationUser, ApplicationDbContext>(options =>
    {
        options.ApiResources.Add(new ApiResource("api1"));
        options.ApiScopes.AddRange(new ApiScope("api1"));
        options.Clients.Add(new Client()
        {
            ClientId = "postman",
            AllowedGrantTypes = {GrantType.ResourceOwnerPassword},
            ClientSecrets = {new Secret("secret".Sha256())},
            AllowedScopes = {"openid", "profile", "MoveManager.ApiAPI", "api1"}
        });

    }).AddTestUsers(new List<TestUser>()
    {
        new()
        {
            SubjectId = "21C88F80-3539-4321-BCF1-2F8C565B2D3A",
            Username = "alice",
            Password = "Pass123$",
            Claims = new List<Claim>()
            {
                new(JwtClaimTypes.Email, "alice@user.com"),
                new(JwtClaimTypes.Name, "alice")
            }
        }
    });

    builder.Services
        .AddAuthentication("Bearer")
        .AddIdentityServerJwt();
}

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));

builder.Services
    .AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5001";
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateAudience = false,
        };
    });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows()
        {
            AuthorizationCode = new OpenApiOAuthFlow()
            {
                AuthorizationUrl = new Uri("https://localhost:5001/connect/authorize"),
                TokenUrl = new Uri("https://localhost:5001/connect/token"),
                Scopes = new Dictionary<string, string>()
                {
                    {"api1", "Full access"},
                    {"user", "User info"}
                }
            }
        }
    });
    options.OperationFilter<AuthorizeCheckOperationFilter>();
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "api1");
    });
});

//========================================================================================================================//

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.OAuthClientId("swagger");
        options.OAuth2RedirectUrl("https://localhost:7262/swagger/oauth2-redirect.html");
        options.OAuthUsePkce();
    });
}

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseCors();

app.UseAuthentication();

if (app.Environment.IsEnvironment("Test"))
    app.UseIdentityServer();

app.UseAuthorization();

app
    .MapControllers()
    .RequireAuthorization("ApiScope");

app.Run();

public partial class Program { } // this part