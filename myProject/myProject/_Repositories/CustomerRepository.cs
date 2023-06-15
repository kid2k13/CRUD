using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using myProject.Models.Customer;

namespace myProject._Repositories
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        //Constructor
        public CustomerRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        //Method
        public void Add(CustomerModel customerModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Customers (CustomerName, Email, PhoneNumber) VALUES (@name, @email, @phone)";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = customerModel.Name;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = customerModel.Email;
                command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = customerModel.Phone;
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Customers where CustomerID=@Id";
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }
        public void Edit(CustomerModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"UPDATE Customers
                        SET CustomerName = @name, Email = @email, PhoneNumber = @phone
                        WHERE CustomerID = @id";
                command.Parameters.AddWithValue("@name", model.Name);
                command.Parameters.AddWithValue("@email", model.Email);
                command.Parameters.AddWithValue("@phone", model.Phone);
                command.Parameters.AddWithValue("@id", model.Id);

                command.ExecuteNonQuery();
            }
        }


        public IEnumerable<CustomerModel> GetAll()
        {
            var petList = new List<CustomerModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Customers ORDER BY CustomerID DESC";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customerModel = new CustomerModel();
                        customerModel.Id = (int)reader[0];
                        customerModel.Name = reader[1].ToString();
                        customerModel.Email = reader[2].ToString();
                        customerModel.Phone = reader[3].ToString();
                        petList.Add(customerModel);
                    }
                }
            }
            return petList;
        }

        public IEnumerable<CustomerModel> GetByValue(string value)
        {
            var customerList = new List<CustomerModel>();
            int customerID = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string customerName = value;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM Customers
                        WHERE CustomerID = @id OR TRIM(CustomerName) COLLATE SQL_Latin1_General_CP1_CI_AS LIKE @name + '%'
                        ORDER BY CustomerID DESC";
                command.Parameters.Add("@id", SqlDbType.Int).Value = customerID;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = customerName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var customerModel = new CustomerModel();
                        customerModel.Id = (int)reader["CustomerID"];
                        customerModel.Name = reader["CustomerName"].ToString();
                        customerModel.Email = reader["Email"].ToString();
                        customerModel.Phone = reader["PhoneNumber"].ToString();
                        customerList.Add(customerModel);
                    }
                }
            }

            return customerList;
        }
    }
}
