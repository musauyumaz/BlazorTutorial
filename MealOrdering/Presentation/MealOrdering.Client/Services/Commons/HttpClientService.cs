using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace MealOrdering.Client.Services.Commons;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public HttpClientService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<TResponse> DeleteAsync<TResponse>(RequestParameter requestParameter, string id)
    {
        StringBuilder urlBuilder = new StringBuilder();
        urlBuilder.Append(Url(requestParameter));
        urlBuilder.Append(!string.IsNullOrEmpty(id) ? "/" + id : "");
        HttpResponseMessage httpResponseMessage = await _httpClient.DeleteAsync(urlBuilder.ToString());
        return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>();
    }

    public async Task<TResponse> GetAsync<TResponse>(RequestParameter requestParameter, string id = null)
    {
        JsonSerializerOptions options = new();
        options.PropertyNameCaseInsensitive = true;
        StringBuilder urlBuilder = new StringBuilder();
        urlBuilder.Append(Url(requestParameter));
        urlBuilder.Append(!string.IsNullOrEmpty(id) ? id : "");
        return await _httpClient.GetFromJsonAsync<TResponse>(urlBuilder.ToString(), options);
    }

    public async Task<TResponse> PostAsync<TRequest, TResponse>(RequestParameter requestParameter, TRequest body)
    {
        string url = Url(requestParameter);
        HttpResponseMessage httpResponseMessage = await _httpClient.PostAsJsonAsync(url, body);
        return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>();
    }
    public async Task<TResponse> PutAsync<TRequest, TResponse>(RequestParameter requestParameter, TRequest body)
    {
        string url = Url(requestParameter);
        HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url, body);
        return await httpResponseMessage.Content.ReadFromJsonAsync<TResponse>();
    }

    private string Url(RequestParameter requestParameter)
    {
        StringBuilder urlBuilder = new StringBuilder();
        //urlBuilder.Append(!string.IsNullOrEmpty(requestParameter.BaseUrl) ? requestParameter.BaseUrl : _configuration.GetValue<string>("BaseUrl"));
        urlBuilder.Append(!string.IsNullOrEmpty(requestParameter.BaseUrl) ? requestParameter.BaseUrl : "https://localhost:7287/api/");
        urlBuilder.Append(requestParameter.Controller + "/");
        urlBuilder.Append(!string.IsNullOrEmpty(requestParameter.Action) ? requestParameter.Action : "");
        urlBuilder.Append(!string.IsNullOrEmpty(requestParameter.QueryString) ? "?" + requestParameter.QueryString : "");
        return !string.IsNullOrEmpty(requestParameter.FullEndPoint) ? requestParameter.FullEndPoint : urlBuilder.ToString();
    }
}
