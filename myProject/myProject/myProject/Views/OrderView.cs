using myProject._Repositories;
using myProject.Models.Order;
using myProject.Models.Product;
using myProject.Pesenters;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace myProject.Views
{
    public interface IOrderView
    {
        void PopulateOrderDetails(int orderId);
    }

    public partial class OrderView : Form, IOrderView
    {
        OrderPresenter orderPresenter;

        public OrderView()
        {
            InitializeComponent();

            // Retrieve the connection string from the configuration file
            string connectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

            // Create an instance of the OrderRepository with the connection string
            OrderRepository orderRepository = new OrderRepository(connectionString);

            // Create an instance of the OrderItemRepository with the connection string
            OrderItemRepository orderItemRepository = new OrderItemRepository(connectionString);

            // Create an instance of the OrderPresenter and pass the repositories
            orderPresenter = new OrderPresenter(orderRepository, orderItemRepository);
        }

        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        }

        public void PopulateOrderDetails(int orderId)
        {
            // Clear any existing rows in the dataGridView1
            dataGridView1.Rows.Clear();

            // Retrieve the order details
            OrderModel order = orderPresenter.GetOrderById(orderId);

            if (order != null)
            {
                // Add the order item details to the dataGridView1
                foreach (var orderItem in order.OrderItems)
                {
                    // Get the product details using the orderItem's ProductID
                    ProductModel product = orderPresenter.GetProductById(orderItem.ProductID);

                    if (product != null)
                    {
                        // Get the product name, price, and calculate the total amount for the order item
                        string productName = product.Name;
                        decimal price = product.Price;
                        decimal totalAmount = orderItem.Quantity * price;

                        // Add a new row to the dataGridView1 with the order item details
                        dataGridView1.Rows.Add(order.OrderDate, productName, price, totalAmount);
                    }
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
        }

        private void label17_Click(object sender, EventArgs e)
        {
        }
    }
}
