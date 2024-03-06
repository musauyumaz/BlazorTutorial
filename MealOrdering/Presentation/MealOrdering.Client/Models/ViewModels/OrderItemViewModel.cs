namespace MealOrdering.Client.Models.ViewModels
{
    public class OrderItemViewModel
    {
        public string Id { get; set; }
        public string CreatedUserId { get; set; }
        public string OrderId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string OrderName { get; set; }
        public string CreatedUserFullName { get; set; }
    }
}
