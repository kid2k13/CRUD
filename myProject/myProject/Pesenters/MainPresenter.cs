using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using myProject.Views;
using myProject._Repositories;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using myProject.Models.Customer;
using myProject.Models.Product;

namespace myProject.Pesenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string sqlConnectionString;
        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowCustomerView += ShowCustomersView;
            this.mainView.ShowProductView += ShowProductsView;
        }
        private void ShowCustomersView(object sender, EventArgs e)
        {
            ICustomerView view = CustomerVIew.GetInstance((MainView)mainView);
            ICustomerRepository repository = new CustomerRepository(sqlConnectionString);
            new CustomerPresenter(view, repository);
        }

        private void ShowProductsView(object sender, EventArgs e)
        {
            IProductView view = ProductView.GetInstance((MainView)mainView);
            IProductRepository repository = new ProductRepository(sqlConnectionString);
            new ProductPresenter(view, repository);
        }
    }
}
