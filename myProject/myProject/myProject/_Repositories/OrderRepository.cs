using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using myProject.Models.Order;

namespace myProject._Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {

        public OrderRepository(string connectionString) : base(connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateOrder(OrderModel order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Orders (CustomerID, OrderDate) VALUES (@CustomerID, @OrderDate); SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);

                connection.Open();
                int orderId = Convert.ToInt32(command.ExecuteScalar());

                foreach (var orderItem in order.OrderItems)
                {
                    string orderItemQuery = "INSERT INTO OrderItems (OrderID, ProductID, Quantity) VALUES (@OrderID, @ProductID, @Quantity)";
                    SqlCommand orderItemCommand = new SqlCommand(orderItemQuery, connection);
                    orderItemCommand.Parameters.AddWithValue("@OrderID", orderId);
                    orderItemCommand.Parameters.AddWithValue("@ProductID", orderItem.ProductID);
                    orderItemCommand.Parameters.AddWithValue("@Quantity", orderItem.Quantity);

                    orderItemCommand.ExecuteNonQuery();
                }
            }
        }

        public OrderModel GetOrderById(int orderId)
        {
            OrderModel order = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT o.OrderID, o.CustomerID, o.OrderDate, c.CustomerName, oi.OrderItemID, oi.ProductID, oi.Quantity, p.ProductName, p.Price " +
                               "FROM Orders o " +
                               "JOIN Customers c ON o.CustomerID = c.CustomerID " +
                               "JOIN OrderItems oi ON o.OrderID = oi.OrderID " +
                               "JOIN Products p ON oi.ProductID = p.ProductID " +
                               "WHERE o.OrderID = @OrderID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (order == null)
                    {
                        order = new OrderModel
                        {
                            OrderID = Convert.ToInt32(reader["OrderID"]),
                            CustomerID = Convert.ToInt32(reader["CustomerID"]),
                            OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                            CustomerName = reader["CustomerName"].ToString(),
                            OrderItems = new List<OrderItemModel>()
                        };
                    }

                    OrderItemModel orderItem = new OrderItemModel
                    {
                        OrderItemID = Convert.ToInt32(reader["OrderItemID"]),
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        ProductName = reader["ProductName"].ToString(),
                        Price = Convert.ToDecimal(reader["Price"])
                    };

                    order.OrderItems.Add(orderItem);
                }

                reader.Close();
            }

            return order;
        }

        public void UpdateOrder(OrderModel order)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Orders SET CustomerID = @CustomerID, OrderDate = @OrderDate WHERE OrderID = @OrderID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                command.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                command.Parameters.AddWithValue("@OrderID", order.OrderID);

                connection.Open();
                command.ExecuteNonQuery();

                // Delete existing order items
                string deleteItemsQuery = "DELETE FROM OrderItems WHERE OrderID = @OrderID";
                SqlCommand deleteItemsCommand = new SqlCommand(deleteItemsQuery, connection);
                deleteItemsCommand.Parameters.AddWithValue("@OrderID", order.OrderID);
                deleteItemsCommand.ExecuteNonQuery();

                // Insert updated order items
                foreach (var orderItem in order.OrderItems)
                {
                    string orderItemQuery = "INSERT INTO OrderItems (OrderID, ProductID, Quantity) VALUES (@OrderID, @ProductID, @Quantity)";
                    SqlCommand orderItemCommand = new SqlCommand(orderItemQuery, connection);
                    orderItemCommand.Parameters.AddWithValue("@OrderID", order.OrderID);
                    orderItemCommand.Parameters.AddWithValue("@ProductID", orderItem.ProductID);
                    orderItemCommand.Parameters.AddWithValue("@Quantity", orderItem.Quantity);

                    orderItemCommand.ExecuteNonQuery();
                }
            }
        }

        public void DeleteOrder(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Delete order items associated with the order
                string deleteItemsQuery = "DELETE FROM OrderItems WHERE OrderID = @OrderID";
                SqlCommand deleteItemsCommand = new SqlCommand(deleteItemsQuery, connection);
                deleteItemsCommand.Parameters.AddWithValue("@OrderID", orderId);

                connection.Open();
                deleteItemsCommand.ExecuteNonQuery();

                // Delete the order
                string query = "DELETE FROM Orders WHERE OrderID = @OrderID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderID", orderId);

                command.ExecuteNonQuery();
            }
        }
    }
}
