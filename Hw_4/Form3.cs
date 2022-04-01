using Hw_4.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hw_4
{
    public partial class Form3 : Form
    {
        public Product Products { get; private set; }

        public Form3(List<Supplier> suppliers, List<Category> categories, List<Product> products)
        {
            InitializeComponent();

            suppliersComboBox.DataSource = suppliers;
            suppliersComboBox.DisplayMember = "CompanyName";
            suppliersComboBox.ValueMember = "SupplierID";

            categoriesComboBox.DataSource = categories;
            categoriesComboBox.DisplayMember = "CategoryName";
            categoriesComboBox.ValueMember = "CategoryID";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Products = new Product();
            Products.ProductName = productTextBox.Text;
            Products.SupplierID = Convert.ToInt32(suppliersComboBox.SelectedValue);
            Products.CategoryID = Convert.ToInt32(categoriesComboBox.SelectedValue);
            Products.UnitPrice = Convert.ToDecimal(priceTextBox.Text);
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
