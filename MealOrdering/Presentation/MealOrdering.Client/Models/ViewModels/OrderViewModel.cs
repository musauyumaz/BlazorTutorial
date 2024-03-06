namespace MealOrdering.Client.Models.ViewModels
{
    public class OrderViewModel
    {
        public string Id { get; set; }
        public string CreateUserId { get; set; }
        public string SupplierId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUserFullName { get; set; }
        public string SupplierName { get; set; }
    }
}
