using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myProject.Views
{
    public interface IMainView
    {
        event EventHandler ShowCustomerView;
        event EventHandler ShowProductView;
        event EventHandler ShowOrderView;
    }
}
