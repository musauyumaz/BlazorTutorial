using MealOrdering.Client.Models.Common;
using MealOrdering.Client.Models.ViewModels.Auths;
using System.Net.Http.Headers;

namespace MealOrdering.Client.Services.Abstractions;

public interface IAuthService
{
    Task<BaseResponse<LoginResponseViewModel>> LoginAsync(LoginUserViewModel loginUserViewModel);
    Task SetAuthorization(AuthenticationHeaderValue authenticationHeaderValue);
}
