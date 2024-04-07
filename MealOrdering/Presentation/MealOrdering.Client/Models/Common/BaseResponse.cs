namespace MealOrdering.Client.Models.Common;

public record BaseResponse<T>(T Data, string Message, bool IsSucceeded);
