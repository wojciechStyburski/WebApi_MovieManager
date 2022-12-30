namespace MovieManager.Infrastructure.ExternalSources.OMDb;

public partial class OmdbClient : IOmdbClient
{
    private string _baseUrl = "https://www.omdbapi.com";
    private readonly HttpClient _httpClient;
    private Lazy<JsonSerializerSettings> _settings;
    private string _apiKey = "4f5be4db";

    public OmdbClient(IHttpClientFactory factory)
    {
        _httpClient = factory.CreateClient("OmdbClient");
        _baseUrl = _httpClient.BaseAddress.ToString();
        _settings = new Lazy<JsonSerializerSettings>(() =>
        {
            var settings = new JsonSerializerSettings();
            UpdateJsonSerializerSettings(settings);
            return settings;
        });
    }

    protected JsonSerializerSettings JsonSerializerSettings { get { return _settings.Value; } }
    partial void UpdateJsonSerializerSettings(JsonSerializerSettings settings);

    public string BaseUrl
    {
        get { return _baseUrl; }
        set { _baseUrl = value; }
    }

    public async Task<string> GetMovie(string searchFilter, CancellationToken cancellationToken)
    {
        var urlBuilder = new StringBuilder();
        urlBuilder.Append(BaseUrl != null ? BaseUrl.TrimEnd('/') : "").Append($"?apikey={_apiKey}");
        urlBuilder.Append("&t=").Append(searchFilter);
        var client = _httpClient;
        try
        {
            using var request = new HttpRequestMessage();
            request.Method = new HttpMethod("GET");
            var url = urlBuilder.ToString();
            request.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Invalid api call exception");
            }

            var responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return responseData;
        }
        catch (Exception ex)
        {
            throw new Exception($"Api call exception: {ex.Message}");
        }
    }

}