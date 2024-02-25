using MealOrdering.Client.CustomComponents.Modals;
using Radzen;

namespace MealOrdering.Client.Utils
{
    public class ModalManager(DialogService _dialogService)
    {
        public async Task ShowMessageAsync(string title, string message, int duration = 0)
        {
            Dictionary<string, object>? dictionary = new();
            dictionary.Add("Message", message);

            await _dialogService.OpenAsync<ShowMessagePopupComponent>(title, dictionary);

            if (duration > 0)
            {
                await Task.Delay(duration);
                _dialogService.Close(true);
            }

        }

        public async Task<bool> ConfirmationAsync(string title, string message)
        {
            Dictionary<string, object>? dictionary = new();
            dictionary.Add("Message", message);
            bool? modalResult = await _dialogService.Confirm(message, title);
            return modalResult ?? false;
        }
    }
}
