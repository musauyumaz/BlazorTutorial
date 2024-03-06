using MealOrdering.Client.Models.Common;

namespace MealOrdering.Client.Services.Abstractions;

public interface IHttpClientService<TResponse> where TResponse : class, new()
{
    Task<TResponse> GetAsync<TResponse>(RequestParameter requestParameter, string id = null);
    Task<TResponse> PostAsync<TRequest, TResponse>(RequestParameter requestParameter, TRequest body);
    Task<TResponse> PutAsync<TRequest, TResponse>(RequestParameter requestParameter, TRequest body);
    Task<TResponse> DeleteAsync<TResponse>(RequestParameter requestParameter, string id);
}
