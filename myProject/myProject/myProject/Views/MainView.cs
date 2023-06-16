using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myProject.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            btnCustomer.Click += delegate { ShowCustomerView?.Invoke(this, EventArgs.Empty); };
            btnProd.Click += delegate { ShowProductView?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler ShowCustomerView;
        public event EventHandler ShowProductView;
        public event EventHandler ShowOrderView;
    }
}
