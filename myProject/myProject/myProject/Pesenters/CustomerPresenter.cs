using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myProject.Views;
using System.Data.SqlClient;
using myProject.Models.Customer;

namespace myProject.Pesenters
{
    public class CustomerPresenter
    {
        //Fields
        private ICustomerView view;
        private ICustomerRepository repository;
        private BindingSource customerBindingSource;
        private IEnumerable<CustomerModel> customerList;

        //constructor
        public CustomerPresenter(ICustomerView view, ICustomerRepository repository)
        {
            this.customerBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchCustomer;
            this.view.AddNewEvent += AddNewCustomer;
            this.view.EditEvent += LoadSelectedCustomerToEdit;
            this.view.DeleteEvent += DeleteSelectedCustomer;
            this.view.SaveEvent += SaveCustomer;
            this.view.CancelEvent += CancelAction;
            //Set pets bindind source
            this.view.SetCustomerListBindingSource(customerBindingSource);
            //Load pet list view
            LoadAllCustomerList();
            //Show view
            this.view.Show();
        }

        //Methods
        private void LoadAllCustomerList()
        {
            customerList = repository.GetAll();
            customerBindingSource.DataSource = customerList;//Set data source.
        }
        private void SearchCustomer(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                customerList = repository.GetByValue(this.view.SearchValue);
            else customerList = repository.GetAll();
            customerBindingSource.DataSource = customerList;
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void SaveCustomer(object? sender, EventArgs e)
        {
            var model = new CustomerModel();
            model.Id = Convert.ToInt32(view.CustomerID);
            model.Name = view.CustomerName;
            model.Email = view.Email;
            model.Phone = view.PhoneNumber;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)//Edit model
                {
                    repository.Edit(model);
                    view.Message = "Customer edited successfuly";
                }
                else //Add new model
                {
                    repository.Add(model);
                    view.Message = "Customer added sucessfully";
                }
                view.IsSuccessful = true;
                LoadAllCustomerList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                // Handle the exception and display an error message
                view.IsSuccessful = false;
                view.Message = "An error occurred: " + ex.Message;
                Console.WriteLine("An error occurred during the add operation: " + ex.Message);
            }
        }

        private void CleanviewFields()
        {
            view.CustomerID = "0";
            view.CustomerName = "";
            view.Email = "";
            view.PhoneNumber = "";
        }

        private void DeleteSelectedCustomer(object? sender, EventArgs e)
        {
            try
            {
                var customer = (CustomerModel)customerBindingSource.Current;
                repository.Delete(customer.Id);
                view.IsSuccessful = true;
                view.Message = "Customer deleted successfully";
                LoadAllCustomerList();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // SQL Server error number for foreign key constraint violation
                {
                    view.IsSuccessful = false;
                    view.Message = "Unable to delete the customer. This customer has a history of orders and cannot be deleted.";
                }
                else
                {
                    // Handle other database exceptions or rethrow the exception
                    // with the original error message for general error handling.
                    throw;
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions or rethrow for general error handling.
                throw;
            }
        }


        private void LoadSelectedCustomerToEdit(object? sender, EventArgs e)
        {
            var customer = (CustomerModel)customerBindingSource.Current;
            view.CustomerID = customer.Id.ToString();
            view.CustomerName = customer.Name;
            view.Email = customer.Email;
            view.PhoneNumber = customer.Phone;
            view.IsEdit = true;
        }

        private void AddNewCustomer(object? sender, EventArgs e)
        {
            view.IsEdit = false;
        }

    }
}
