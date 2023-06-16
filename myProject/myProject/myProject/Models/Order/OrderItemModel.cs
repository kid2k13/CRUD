using myProject.Models.Product;

namespace myProject.Models.Order
{
    public class OrderItemModel
    {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public ProductModel Product { get; set; } // Added property

        public decimal TotalAmount => Quantity * Price;
    }
}