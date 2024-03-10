using MealOrdering.Client.Models.Common;
using MealOrdering.Client.Models.ViewModels.Users;
using MealOrdering.Client.Services.Abstractions;

namespace MealOrdering.Client.Services.Concretes
{
    public class UserService(IHttpClientService _httpClientService) : IUserService
    {
        public async Task<BaseResponse<UserViewModel>> AddUserAsync(AddUserViewModel addUserViewModel)
            => await _httpClientService.PostAsync<AddUserViewModel, BaseResponse<UserViewModel>>(new RequestParameter("Users", "Add"), addUserViewModel);

        public async Task<BaseResponse<UserViewModel>> DeleteUserAsync(string id)
            => await _httpClientService.DeleteAsync<BaseResponse<UserViewModel>>(new("Users", "Delete"), id);

        public async Task<BaseResponse<List<UserViewModel>>> GetAllUserListAsync(int page, int size)
            => await _httpClientService.GetAsync<BaseResponse<List<UserViewModel>>>(new("Users", "GetAll"));

        public async Task<BaseResponse<UserViewModel>> GetUserByIdAsync(string id)
            => await _httpClientService.GetAsync<BaseResponse<UserViewModel>>(new("Users", "Get"), id);

        public async Task<BaseResponse<UserViewModel>> UpdateUserAsync(UpdateUserViewModel updateUserViewModel)
            => await _httpClientService.PutAsync<UpdateUserViewModel, BaseResponse<UserViewModel>>(new("Users", "Update"), updateUserViewModel);
    }
}
