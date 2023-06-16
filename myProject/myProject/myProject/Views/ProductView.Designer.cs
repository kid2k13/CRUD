namespace myProject.Views
{
    partial class ProductView
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
            panel1 = new Panel();
            btnProdClose = new Button();
            labelProd = new Label();
            groupBoxProd = new GroupBox();
            textBoxProdID = new TextBox();
            btnProdSearch = new Button();
            labelProdPrice = new Label();
            labelProdName = new Label();
            textBoxProdPrice = new TextBox();
            textBoxProdName = new TextBox();
            btnProdDelete = new Button();
            btnProdEdit = new Button();
            btnProdAdd = new Button();
            textBoxProdSearch = new TextBox();
            labelProdSearch = new Label();
            dataGridViewProd = new DataGridView();
            panel1.SuspendLayout();
            groupBoxProd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProd).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnProdClose);
            panel1.Controls.Add(labelProd);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 47);
            panel1.TabIndex = 0;
            // 
            // btnProdClose
            // 
            btnProdClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnProdClose.Location = new Point(771, 9);
            btnProdClose.Name = "btnProdClose";
            btnProdClose.Size = new Size(23, 23);
            btnProdClose.TabIndex = 11;
            btnProdClose.Text = "X";
            btnProdClose.UseVisualStyleBackColor = true;
            // 
            // labelProd
            // 
            labelProd.AutoSize = true;
            labelProd.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            labelProd.Location = new Point(12, 9);
            labelProd.Name = "labelProd";
            labelProd.Size = new Size(100, 30);
            labelProd.TabIndex = 0;
            labelProd.Text = "Products";
            // 
            // groupBoxProd
            // 
            groupBoxProd.Controls.Add(textBoxProdID);
            groupBoxProd.Controls.Add(btnProdSearch);
            groupBoxProd.Controls.Add(labelProdPrice);
            groupBoxProd.Controls.Add(labelProdName);
            groupBoxProd.Controls.Add(textBoxProdPrice);
            groupBoxProd.Controls.Add(textBoxProdName);
            groupBoxProd.Controls.Add(btnProdDelete);
            groupBoxProd.Controls.Add(btnProdEdit);
            groupBoxProd.Controls.Add(btnProdAdd);
            groupBoxProd.Controls.Add(textBoxProdSearch);
            groupBoxProd.Controls.Add(labelProdSearch);
            groupBoxProd.Controls.Add(dataGridViewProd);
            groupBoxProd.Dock = DockStyle.Fill;
            groupBoxProd.Location = new Point(0, 47);
            groupBoxProd.Name = "groupBoxProd";
            groupBoxProd.Size = new Size(800, 403);
            groupBoxProd.TabIndex = 1;
            groupBoxProd.TabStop = false;
            groupBoxProd.Text = "Product List and Details";
            // 
            // textBoxProdID
            // 
            textBoxProdID.Location = new Point(117, 123);
            textBoxProdID.Name = "textBoxProdID";
            textBoxProdID.ReadOnly = true;
            textBoxProdID.Size = new Size(23, 23);
            textBoxProdID.TabIndex = 11;
            textBoxProdID.Text = "0";
            textBoxProdID.TextAlign = HorizontalAlignment.Center;
            // 
            // btnProdSearch
            // 
            btnProdSearch.Location = new Point(162, 51);
            btnProdSearch.Name = "btnProdSearch";
            btnProdSearch.Size = new Size(75, 23);
            btnProdSearch.TabIndex = 10;
            btnProdSearch.Text = "Search";
            btnProdSearch.UseVisualStyleBackColor = true;
            // 
            // labelProdPrice
            // 
            labelProdPrice.AutoSize = true;
            labelProdPrice.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelProdPrice.Location = new Point(6, 202);
            labelProdPrice.Name = "labelProdPrice";
            labelProdPrice.Size = new Size(105, 21);
            labelProdPrice.TabIndex = 9;
            labelProdPrice.Text = "Product Price:";
            // 
            // labelProdName
            // 
            labelProdName.AutoSize = true;
            labelProdName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelProdName.Location = new Point(0, 150);
            labelProdName.Name = "labelProdName";
            labelProdName.Size = new Size(113, 21);
            labelProdName.TabIndex = 8;
            labelProdName.Text = "Product Name:";
            // 
            // textBoxProdPrice
            // 
            textBoxProdPrice.Location = new Point(117, 200);
            textBoxProdPrice.Name = "textBoxProdPrice";
            textBoxProdPrice.Size = new Size(163, 23);
            textBoxProdPrice.TabIndex = 7;
            // 
            // textBoxProdName
            // 
            textBoxProdName.Location = new Point(117, 152);
            textBoxProdName.Name = "textBoxProdName";
            textBoxProdName.Size = new Size(163, 23);
            textBoxProdName.TabIndex = 6;
            // 
            // btnProdDelete
            // 
            btnProdDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnProdDelete.Location = new Point(172, 247);
            btnProdDelete.Name = "btnProdDelete";
            btnProdDelete.Size = new Size(64, 34);
            btnProdDelete.TabIndex = 5;
            btnProdDelete.Text = "Delete";
            btnProdDelete.UseVisualStyleBackColor = true;
            // 
            // btnProdEdit
            // 
            btnProdEdit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnProdEdit.Location = new Point(91, 247);
            btnProdEdit.Name = "btnProdEdit";
            btnProdEdit.Size = new Size(64, 34);
            btnProdEdit.TabIndex = 4;
            btnProdEdit.Text = "Edit";
            btnProdEdit.UseVisualStyleBackColor = true;
            // 
            // btnProdAdd
            // 
            btnProdAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnProdAdd.Location = new Point(10, 247);
            btnProdAdd.Name = "btnProdAdd";
            btnProdAdd.Size = new Size(64, 34);
            btnProdAdd.TabIndex = 3;
            btnProdAdd.Text = "Add";
            btnProdAdd.UseVisualStyleBackColor = true;
            // 
            // textBoxProdSearch
            // 
            textBoxProdSearch.Location = new Point(117, 22);
            textBoxProdSearch.Name = "textBoxProdSearch";
            textBoxProdSearch.Size = new Size(163, 23);
            textBoxProdSearch.TabIndex = 2;
            // 
            // labelProdSearch
            // 
            labelProdSearch.AutoSize = true;
            labelProdSearch.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            labelProdSearch.Location = new Point(46, 24);
            labelProdSearch.Name = "labelProdSearch";
            labelProdSearch.Size = new Size(65, 21);
            labelProdSearch.TabIndex = 1;
            labelProdSearch.Text = "Search:";
            // 
            // dataGridViewProd
            // 
            dataGridViewProd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewProd.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewProd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProd.Location = new Point(286, 22);
            dataGridViewProd.Name = "dataGridViewProd";
            dataGridViewProd.RowTemplate.Height = 25;
            dataGridViewProd.Size = new Size(502, 369);
            dataGridViewProd.TabIndex = 0;
            // 
            // ProductView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBoxProd);
            Controls.Add(panel1);
            Name = "ProductView";
            Text = "ProductView";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBoxProd.ResumeLayout(false);
            groupBoxProd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProd).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labelProd;
        private GroupBox groupBoxProd;
        private Button btnProdDelete;
        private Button btnProdEdit;
        private Button btnProdAdd;
        private TextBox textBoxProdSearch;
        private Label labelProdSearch;
        private DataGridView dataGridViewProd;
        private Label labelProdPrice;
        private Label labelProdName;
        private TextBox textBoxProdPrice;
        private TextBox textBoxProdName;
        private Button btnProdClose;
        private Button btnProdSearch;
        private TextBox textBoxProdID;
    }
}