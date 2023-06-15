using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myProject.Models.Customer
{
    public interface ICustomerView
    {
        //Properties - Fields
        string CustomerID { get; set; }
        string CustomerName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }
        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }
        //Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;
        //Methods
        void SetCustomerListBindingSource(BindingSource customerList);
        void Show();
    }
}
