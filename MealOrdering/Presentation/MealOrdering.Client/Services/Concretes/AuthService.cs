using MealOrdering.Client.Models.Common;
using MealOrdering.Client.Models.ViewModels.Auths;
using MealOrdering.Client.Services.Abstractions;
using MealOrdering.Client.Services.Commons;
using System.Net.Http.Headers;

namespace MealOrdering.Client.Services.Concretes
{
    public class AuthService(IHttpClientService _httpClientService) : IAuthService
    {
        public async Task<BaseResponse<LoginResponseViewModel>> LoginAsync(LoginUserViewModel loginUserViewModel)
        {
            return await _httpClientService.PostAsync<LoginUserViewModel, BaseResponse<LoginResponseViewModel>>(new("Auths") { }, loginUserViewModel);
        }

        public async Task SetAuthorization(AuthenticationHeaderValue authenticationHeaderValue)
        {
            _httpClientService.Client.DefaultRequestHeaders.Authorization = authenticationHeaderValue;
        }
    }
}
