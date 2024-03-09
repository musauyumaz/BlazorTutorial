using MealOrdering.Client.Models.Common;
using MealOrdering.Client.Models.ViewModels;
using MealOrdering.Client.Models.ViewModels.Users;
using MealOrdering.Client.Services.Abstractions;

namespace MealOrdering.Client.Services.Concretes
{
    public class UserService : IUserService
    {
        public Task<BaseResponse<UserViewModel>> AddUserAsync(AddUserViewModel addUserViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<UserViewModel>> DeleteUserAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<UserViewModel>> GetAllUserListAsync(int page, int size)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<UserViewModel>> GetUserByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResponse<UserViewModel>> UpdateUserAsync(UpdateUserViewModel updateUserViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
