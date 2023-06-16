namespace myProject.Views
{
    partial class CustomerVIew
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            panel1 = new Panel();
            btnClose = new Button();
            tabControl1 = new TabControl();
            tabPageCustomerList = new TabPage();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            dataGridView1 = new DataGridView();
            label2 = new Label();
            tabPageCustomerDetails = new TabPage();
            txtPhone = new TextBox();
            txtemail = new TextBox();
            txtName = new TextBox();
            txtID = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageCustomerList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabPageCustomerDetails.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(93, 25);
            label1.TabIndex = 0;
            label1.Text = "Customer";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnClose);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 47);
            panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.Location = new Point(767, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(29, 33);
            btnClose.TabIndex = 7;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageCustomerList);
            tabControl1.Controls.Add(tabPageCustomerDetails);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 47);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 403);
            tabControl1.TabIndex = 2;
            // 
            // tabPageCustomerList
            // 
            tabPageCustomerList.Controls.Add(btnDelete);
            tabPageCustomerList.Controls.Add(btnEdit);
            tabPageCustomerList.Controls.Add(btnAdd);
            tabPageCustomerList.Controls.Add(btnSearch);
            tabPageCustomerList.Controls.Add(txtSearch);
            tabPageCustomerList.Controls.Add(dataGridView1);
            tabPageCustomerList.Controls.Add(label2);
            tabPageCustomerList.Location = new Point(4, 24);
            tabPageCustomerList.Name = "tabPageCustomerList";
            tabPageCustomerList.Padding = new Padding(3);
            tabPageCustomerList.Size = new Size(792, 375);
            tabPageCustomerList.TabIndex = 0;
            tabPageCustomerList.Text = "Customer List";
            tabPageCustomerList.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDelete.Location = new Point(709, 127);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEdit.Location = new Point(709, 98);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAdd.Location = new Point(709, 69);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add new";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.Location = new Point(628, 27);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Location = new Point(20, 27);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(602, 23);
            txtSearch.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(20, 56);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(683, 311);
            dataGridView1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(20, 3);
            label2.Name = "label2";
            label2.Size = new Size(60, 21);
            label2.TabIndex = 0;
            label2.Text = "Search:";
            label2.Click += label2_Click;
            // 
            // tabPageCustomerDetails
            // 
            tabPageCustomerDetails.Controls.Add(txtPhone);
            tabPageCustomerDetails.Controls.Add(txtemail);
            tabPageCustomerDetails.Controls.Add(txtName);
            tabPageCustomerDetails.Controls.Add(txtID);
            tabPageCustomerDetails.Controls.Add(label6);
            tabPageCustomerDetails.Controls.Add(label5);
            tabPageCustomerDetails.Controls.Add(label4);
            tabPageCustomerDetails.Controls.Add(label3);
            tabPageCustomerDetails.Controls.Add(btnCancel);
            tabPageCustomerDetails.Controls.Add(btnSave);
            tabPageCustomerDetails.Location = new Point(4, 24);
            tabPageCustomerDetails.Name = "tabPageCustomerDetails";
            tabPageCustomerDetails.Padding = new Padding(3);
            tabPageCustomerDetails.Size = new Size(792, 375);
            tabPageCustomerDetails.TabIndex = 1;
            tabPageCustomerDetails.Text = "Customer Details";
            tabPageCustomerDetails.UseVisualStyleBackColor = true;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(51, 149);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(230, 23);
            txtPhone.TabIndex = 9;
            txtPhone.TextChanged += textBox5_TextChanged;
            // 
            // txtemail
            // 
            txtemail.Location = new Point(330, 94);
            txtemail.Name = "txtemail";
            txtemail.Size = new Size(444, 23);
            txtemail.TabIndex = 8;
            // 
            // txtName
            // 
            txtName.Location = new Point(51, 94);
            txtName.Name = "txtName";
            txtName.Size = new Size(230, 23);
            txtName.TabIndex = 7;
            // 
            // txtID
            // 
            txtID.Location = new Point(51, 44);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(76, 23);
            txtID.TabIndex = 6;
            txtID.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(51, 131);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 5;
            label6.Text = "Phone Number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(51, 76);
            label5.Name = "label5";
            label5.Size = new Size(97, 15);
            label5.TabIndex = 4;
            label5.Text = "Customer Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(330, 76);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(51, 26);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 2;
            label3.Text = "Customer ID:";
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(133, 202);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(52, 202);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // CustomerVIew
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Name = "CustomerVIew";
            Text = "CustomerVIew";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageCustomerList.ResumeLayout(false);
            tabPageCustomerList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabPageCustomerDetails.ResumeLayout(false);
            tabPageCustomerDetails.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tabPageCustomerList;
        private TextBox txtSearch;
        private DataGridView dataGridView1;
        private Label label2;
        private TabPage tabPageCustomerDetails;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnSearch;
        private TextBox txtPhone;
        private TextBox txtemail;
        private TextBox txtName;
        private TextBox txtID;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button btnCancel;
        private Button btnSave;
        private Button btnClose;
    }
}