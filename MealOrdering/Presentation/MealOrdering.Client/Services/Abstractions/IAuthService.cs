using MealOrdering.Client.Models.Common;
using MealOrdering.Client.Models.ViewModels.Auths;

namespace MealOrdering.Client.Services.Abstractions;

public interface IAuthService
{
    Task<BaseResponse<LoginResponseViewModel>> LoginAsync(LoginUserViewModel loginUserViewModel);
}
