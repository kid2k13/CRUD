using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myProject.Models.Product
{
    public interface IProductView
    {
        //Properties - Fields
        string ProductID { get; set; }
        string ProductName { get; set; }
        string ProductPrice { get; set; }
        string ProdSearchValue { get; set; }
        bool ProdIsEdit { get; set; }
        bool ProdIsSuccessful { get; set; }
        string ProdMessage { get; set; }
        //Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        //Methods
        void SetProductListBindingSource(BindingSource customerList);
        void Show();
    }
}
