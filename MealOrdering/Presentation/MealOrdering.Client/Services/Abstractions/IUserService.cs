using MealOrdering.Client.Models.Common;
using MealOrdering.Client.Models.ViewModels.Users;

namespace MealOrdering.Client.Services.Abstractions
{
    public interface IUserService
    {
        Task<BaseResponse<UserViewModel>> GetAllUserListAsync(int page, int size);
        Task<BaseResponse<UserViewModel>> GetUserByIdAsync(string id);
        Task<BaseResponse<UserViewModel>> AddUserAsync(AddUserViewModel addUserViewModel);
        Task<BaseResponse<UserViewModel>> UpdateUserAsync(UpdateUserViewModel updateUserViewModel);
        Task<BaseResponse<UserViewModel>> DeleteUserAsync(string id);
    }
}
