namespace myProject.Models.Order
{
    public interface IOrderItemRepository
    {
        void CreateOrderItem(OrderItemModel orderItem);

        OrderItemModel GetOrderItemById(int orderItemId);

        void UpdateOrderItem(OrderItemModel orderItem);

        void DeleteOrderItem(int orderItemId);
        List<OrderItemModel> GetOrderItemsByOrderId(int orderId);
    }
}