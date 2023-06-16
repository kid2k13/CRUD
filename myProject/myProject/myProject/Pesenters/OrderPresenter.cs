using myProject.Models.Order;
using myProject.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject.Pesenters
{
    public class OrderPresenter
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderItemRepository orderItemRepository;

        public OrderPresenter(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository)
        {
            this.orderRepository = orderRepository;
            this.orderItemRepository = orderItemRepository;
        }

        public void CreateOrder(OrderModel order)
        {
            // Perform any necessary validation or business logic operations
            // before creating the order

            // Call the order repository to create the order
            orderRepository.CreateOrder(order);

            // Create order items (if any)
            foreach (var orderItem in order.OrderItems)
            {
                orderItemRepository.CreateOrderItem(orderItem);
            }
        }

        public OrderModel GetOrderById(int orderId)
        {
            // Call the order repository to fetch the order
            var order = orderRepository.GetOrderById(orderId);

            // Fetch order items (if any)
            if (order != null)
            {
                foreach (var orderItem in order.OrderItems)
                {
                    var item = orderItemRepository.GetOrderItemById(orderItem.OrderItemID);
                    if (item != null)
                    {
                        orderItem.Product = item.Product;
                    }
                }
            }

            return order;
        }

        public void UpdateOrder(OrderModel order)
        {
            // Perform any necessary validation or business logic operations
            // before updating the order

            // Call the order repository to update the order
            orderRepository.UpdateOrder(order);

            // Update order items (if any)
            foreach (var orderItem in order.OrderItems)
            {
                orderItemRepository.UpdateOrderItem(orderItem);
            }
        }

        public void DeleteOrder(int orderId)
        {
            // Perform any necessary validation or business logic operations
            // before deleting the order

            // Call the order repository to delete the order
            orderRepository.DeleteOrder(orderId);
        }
        public List<OrderItemModel> GetOrderItems(int orderId)
        {
            return orderItemRepository.GetOrderItemsByOrderId(orderId);
        }

        internal ProductModel GetProductById(int productID)
        {
            throw new NotImplementedException();
        }
    }

}
