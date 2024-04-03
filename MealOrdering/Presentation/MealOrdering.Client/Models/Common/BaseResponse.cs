namespace MealOrdering.Client.Models.Common;

public class BaseResponse<T> where T :  new()
{
    public T Data { get; set; }
    public string Message { get; set; }
    public bool IsSucceeded { get; set; }
}
