namespace myProject.Models.Order
{
    public interface IOrderRepository
    {
        void CreateOrder(OrderModel order);

        OrderModel GetOrderById(int orderId);

        void UpdateOrder(OrderModel order);

        void DeleteOrder(int orderId);
    }
}