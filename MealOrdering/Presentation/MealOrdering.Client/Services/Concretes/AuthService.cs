using MealOrdering.Client.Models.Common;
using MealOrdering.Client.Models.ViewModels.Auths;
using MealOrdering.Client.Services.Abstractions;
using MealOrdering.Client.Services.Commons;

namespace MealOrdering.Client.Services.Concretes
{
    public class AuthService(IHttpClientService _httpClientService) : IAuthService
    {
        public async Task<BaseResponse<LoginResponseViewModel>> LoginAsync(LoginUserViewModel loginUserViewModel)
        {
            return await _httpClientService.PostAsync<LoginUserViewModel, BaseResponse<LoginResponseViewModel>>(new("Auths") { }, loginUserViewModel);
        }
    }
}
