using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myProject.Views;
using System.Data.SqlClient;
using myProject.Models.Customer;
using myProject.Models.Product;

namespace myProject.Pesenters
{
    public class ProductPresenter
    {
        //Fields
        private IProductView view;
        private IProductRepository repository;
        private BindingSource productBindingSource;
        private IEnumerable<ProductModel> productList;

        //constructor
        public ProductPresenter(IProductView view, IProductRepository repository)
        {
            this.productBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchProduct;
            this.view.AddNewEvent += AddNewProduct;
            this.view.EditEvent += LoadSelectedProductToEdit;
            this.view.DeleteEvent += DeleteSelectedProduct;
            //Set pets bindind source
            this.view.SetProductListBindingSource(productBindingSource);
            //Load pet list view
            LoadAllProductList();
            //Show view
            this.view.Show();
        }

        //Methods
        private void LoadAllProductList()
        {
            productList = repository.GetAll();
            productBindingSource.DataSource = productList;//Set data source.
        }
        private void SearchProduct(object? sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.ProdSearchValue);
            if (emptyValue == false)
                productList = repository.GetByValue(this.view.ProdSearchValue);
            else productList = repository.GetAll();
            productBindingSource.DataSource = productList;
        }

        private void CancelAction(object? sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void SaveProduct(object? sender, EventArgs e)
        {
            var model = new ProductModel();
            model.Id = Convert.ToInt32(view.ProductID);
            model.Name = view.ProductName;
            model.Price = Convert.ToDecimal(view.ProductPrice);
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.ProdIsEdit)//Edit model
                {
                    repository.Edit(model);
                    view.ProdMessage = "Product edited successfuly";
                }
                else //Add new model
                {
                    repository.Add(model);
                    view.ProdMessage = "Product added sucessfully";
                }
                view.ProdIsSuccessful = true;
                LoadAllProductList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                // Handle the exception and display an error message
                view.ProdIsSuccessful = false;
                view.ProdMessage = "An error occurred: " + ex.Message;
                Console.WriteLine("An error occurred during the add operation: " + ex.Message);
            }
        }

        private void CleanviewFields()
        {
            view.ProductID = "0";
            view.ProductName = "";
            view.ProductPrice = "";
        }

        private void DeleteSelectedProduct(object? sender, EventArgs e)
        {
            try
            {
                var product = (ProductModel)productBindingSource.Current;
                repository.Delete(product.Id);
                view.ProdIsSuccessful = true;
                view.ProdMessage = "Customer deleted successfully";
                LoadAllProductList();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 547) // SQL Server error number for foreign key constraint violation
                {
                    view.ProdIsSuccessful = false;
                    view.ProdMessage = "Unable to delete the customer. This customer has a history of orders and cannot be deleted.";
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


        private void LoadSelectedProductToEdit(object? sender, EventArgs e)
        {
            var product = (ProductModel)productBindingSource.Current;
            view.ProductID = product.Id.ToString();
            view.ProductName = product.Name;
            view.ProductPrice = product.Price.ToString();
            view.ProdIsEdit = true;
        }

        private void AddNewProduct(object? sender, EventArgs e)
        {
            view.ProdIsEdit = false;
        }

    }
}
