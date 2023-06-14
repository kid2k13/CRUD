using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using myProject.Models;

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
                command.CommandText = "insert into Customervalues (@CustomerName, @Email, @PhoneNumber)";
                command.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = customerModel.Name;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = customerModel.Email;
                command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = customerModel.Phone;
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
                command.CommandText = "delete from Customer where CustomerID=@CustomerID";
                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }
        public void Edit(CustomerModel customerModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Pet 
                                    set CustomerName=@CustomerName,Email= @Email,PhoneNumber= @PhoneNumber 
                                    where CustomerID=@CustomerID";
                command.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = customerModel.Name;
                command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = customerModel.Email;
                command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = customerModel.Phone;
                command.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customerModel.Id;
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
                command.CommandText = "Select *from Customers order by CustomerID desc";
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
