using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using myProject.Models.Product;

namespace myProject._Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        // Constructor
        public ProductRepository(string connectionString) : base(connectionString)
        {
            this.connectionString = connectionString;
        }

        // Method to add a product
        public void Add(ProductModel productModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Products (ProductName, Price) VALUES (@name, @price)";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = productModel.Name;
                command.Parameters.Add("@price", SqlDbType.Decimal).Value = productModel.Price;
                command.ExecuteNonQuery();
            }
        }

        // Method to delete a product
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM Products WHERE ProductID = @id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        // Method to edit a product
        public void Edit(ProductModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"UPDATE Products
                                        SET ProductName = @name, Price = @price
                                        WHERE ProductID = @id";
                command.Parameters.AddWithValue("@name", model.Name);
                command.Parameters.AddWithValue("@price", model.Price);
                command.Parameters.AddWithValue("@id", model.Id);
                command.ExecuteNonQuery();
            }
        }

        // Method to get all products
        public IEnumerable<ProductModel> GetAll()
        {
            var productList = new List<ProductModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Products ORDER BY ProductID DESC";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productModel = new ProductModel();
                        productModel.Id = (int)reader["ProductID"];
                        productModel.Name = reader["ProductName"].ToString();
                        productModel.Price = (decimal)reader["Price"];
                        productList.Add(productModel);
                    }
                }
            }
            return productList;
        }

        // Method to search products by value
        public IEnumerable<ProductModel> GetByValue(string value)
        {
            var productList = new List<ProductModel>();
            int productId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string productName = value;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM Products
                                        WHERE ProductID = @id OR TRIM(ProductName) COLLATE SQL_Latin1_General_CP1_CI_AS LIKE @name + '%'
                                        ORDER BY ProductID DESC";
                command.Parameters.Add("@id", SqlDbType.Int).Value = productId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = productName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productModel = new ProductModel();
                        productModel.Id = (int)reader["ProductID"];
                        productModel.Name = reader["ProductName"].ToString();
                        productModel.Price = (decimal)reader["Price"];
                        productList.Add(productModel);
                    }
                }
            }

            return productList;
        }
    }
}
