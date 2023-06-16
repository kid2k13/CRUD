using myProject.Models.Order;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject._Repositories
{
    public class OrderItemRepository : BaseRepository, IOrderItemRepository
    {

        public OrderItemRepository(string connectionString) : base(connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateOrderItem(OrderItemModel orderItem)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO OrderItems (OrderID, ProductID, Quantity) VALUES (@OrderID, @ProductID, @Quantity)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderItem.OrderID);
                command.Parameters.AddWithValue("@ProductID", orderItem.ProductID);
                command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public OrderItemModel GetOrderItemById(int orderItemId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM OrderItems WHERE OrderItemID = @OrderItemID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderItemID", orderItemId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    OrderItemModel orderItem = new OrderItemModel
                    {
                        OrderItemID = (int)reader["OrderItemID"],
                        OrderID = (int)reader["OrderID"],
                        ProductID = (int)reader["ProductID"],
                        Quantity = (int)reader["Quantity"]
                    };

                    return orderItem;
                }

                return null;
            }
        }

        public void UpdateOrderItem(OrderItemModel orderItem)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE OrderItems SET OrderID = @OrderID, ProductID = @ProductID, Quantity = @Quantity WHERE OrderItemID = @OrderItemID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderItem.OrderID);
                command.Parameters.AddWithValue("@ProductID", orderItem.ProductID);
                command.Parameters.AddWithValue("@Quantity", orderItem.Quantity);
                command.Parameters.AddWithValue("@OrderItemID", orderItem.OrderItemID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteOrderItem(int orderItemId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM OrderItems WHERE OrderItemID = @OrderItemID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderItemID", orderItemId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public List<OrderItemModel> GetOrderItemsByOrderId(int orderId)
        {
            List<OrderItemModel> orderItems = new List<OrderItemModel>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM OrderItems WHERE OrderID = @OrderID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    OrderItemModel orderItem = new OrderItemModel
                    {
                        OrderItemID = (int)reader["OrderItemID"],
                        OrderID = (int)reader["OrderID"],
                        ProductID = (int)reader["ProductID"],
                        Quantity = (int)reader["Quantity"]
                    };

                    orderItems.Add(orderItem);
                }
            }

            return orderItems;
        }


    }
}
