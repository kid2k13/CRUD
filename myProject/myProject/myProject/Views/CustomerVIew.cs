using myProject.Models.Customer;
using myProject.Models.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myProject.Views
{
    public partial class CustomerVIew : Form, ICustomerView
    {
        //fields
        private string message;
        private bool isSuccessful;
        private object txtCustomerID;
        private bool isEdit;

        //constructor
        public CustomerVIew()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPageCustomerDetails);
            btnClose.Click += delegate { this.Close(); };
            // Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

        }
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Display the exception details
            MessageBox.Show($"An unhandled exception occurred: {e.ExceptionObject}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /*private void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            // Display the exception details
            MessageBox.Show($"An error occurred: {e.Exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }*/

        private void AssociateAndRaiseViewEvents()
        {
            //search
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Add new
            btnAdd.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageCustomerList);
                tabControl1.TabPages.Add(tabPageCustomerDetails);
                tabPageCustomerDetails.Text = "Add new pet";
            };
            //Edit
            btnEdit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageCustomerList);
                tabControl1.TabPages.Add(tabPageCustomerDetails);
                tabPageCustomerDetails.Text = "Edit pet";
            };
            //Save changes
            btnSave.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPageCustomerDetails);
                    tabControl1.TabPages.Add(tabPageCustomerList);
                }
                MessageBox.Show(Message);
            };
            //Cancel
            btnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPageCustomerDetails);
                tabControl1.TabPages.Add(tabPageCustomerList);
            };
            //Delete
            btnDelete.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected customer?", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }

        public string CustomerID
        {
            get { return txtID.Text; }
            set { txtID.Text = value; }
        }
        public string CustomerName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public string Email
        {
            get { return txtemail.Text; }
            set { txtemail.Text = value; }
        }
        public string PhoneNumber
        {
            get { return txtPhone.Text; }
            set { txtPhone.Text = value; }
        }
        public string SearchValue
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public bool IsEdit
        {
            get { return isEdit; }
            set { isEdit = value; }
        }
        private bool issSuccessful;

        public bool IsSuccessful
        {
            get { return issSuccessful; }
            set { issSuccessful = value; }
        }
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        //Events
        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        //Methods
        public void SetCustomerListBindingSource(BindingSource customerList)
        {
            dataGridView1.DataSource = customerList;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        //singleton pattern
        private static CustomerVIew instance;
        public static CustomerVIew GetInstance(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new CustomerVIew();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
