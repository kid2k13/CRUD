using myProject.Models.Product;
using System.Windows.Forms;
using System.Xml.Linq;

namespace myProject.Views
{
    public partial class ProductView : Form, IProductView
    {
        //fields
        private string message;
        private bool isSuccessful;
        private object txtCustomerID;
        private bool isEdit;
        public ProductView()
        {
            InitializeComponent();
            btnProdClose.Click += delegate { this.Close(); };
        }

        private void AssociateAndRaiseViewEvents()
        {
            //search
            btnProdSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            textBoxProdSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Edit
            btnProdAdd.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
            };
            //Save changes
            btnProdAdd.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(ProdMessage);
            };
            //Delete
            btnProdDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected product?", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(ProdMessage);
                }
            };
        }

        public string ProductID
        {
            get { return textBoxProdID.Text; }
            set { textBoxProdID.Text = value; }
        }
        public string ProductPrice
        {
            get { return textBoxProdPrice.Text; }
            set { textBoxProdPrice.Text = value; }
        }
        public string ProdSearchValue
        {
            get { return textBoxProdSearch.Text; }
            set { textBoxProdSearch.Text = value; }
        }
        public bool ProdIsEdit
        {
            get => throw new NotImplementedException(); set => throw new NotImplementedException();
        }
        private bool isssSuccessful;
        public bool ProdIsSuccessful
        {
            get { return isssSuccessful; }
            set { isssSuccessful = value; }
        }
        public string ProdMessage
        {
            get { return message; }
            set { message = value; }
        }
        string IProductView.ProductName
        {
            get { return textBoxProdName.Text; }
            set { textBoxProdName.Text = value; }
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;

        public void SetProductListBindingSource(BindingSource customerList)
        {
            dataGridViewProd.DataSource = customerList;
        }

        //singleton pattern
        private static ProductView instance;
        public static ProductView GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new ProductView();
                instance.MdiParent = parentContainer;
                instance.FormBorderStyle = FormBorderStyle.None;
                instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
