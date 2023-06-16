namespace myProject.Models.Order
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } // Added property

        public List<OrderItemModel> OrderItems { get; set; } = new List<OrderItemModel>();
        public decimal TotalAmount => OrderItems.Sum(item => item.TotalAmount);
    }
}