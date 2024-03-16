using MealOrdering.Client.Models.Common;
using MealOrdering.Client.Models.ViewModels.Users;
using MealOrdering.Client.Services.Abstractions;
using Microsoft.AspNetCore.Components;

namespace MealOrdering.Client.Pages.Users
{
    public class UserListProcess : ComponentBase
    {
        [Inject]
        IUserService UserService { get; set; }
        public List<UserViewModel> UserViewModels { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await LoadListAsync();
        }

        protected async Task LoadListAsync()
        {
            BaseResponse<List<UserViewModel>>? serviceResponse = await UserService.GetAllUserListAsync(2, 3);
            if (serviceResponse.IsSucceeded)
                UserViewModels = serviceResponse.Data;
            {
                
            }
        }
    }
}
