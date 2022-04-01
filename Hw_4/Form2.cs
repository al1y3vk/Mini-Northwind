using Hw_4.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hw_4
{
    public partial class Form2 : Form
    {
        public Order Orders { get; private set; }
        public Order_Detail Details { get; private set; }

        public Form2(List<Customer> customers, List<Employee> employees, List<Supplier> suppliers, List<Product> products)
        { 
            InitializeComponent();

            customerIDComboBox.DataSource = customers;
            customerIDComboBox.DisplayMember = "CompanyName";
            customerIDComboBox.ValueMember = "CustomerID";

            employeeIDComboBox.DataSource = employees;
            employeeIDComboBox.DisplayMember = "FirstName";
            employeeIDComboBox.ValueMember = "EmployeeID";

            shipViaComboBox.DataSource = suppliers;
            shipViaComboBox.DisplayMember = "CompanyName";
            shipViaComboBox.ValueMember = "SupplierID";

            productsComboBox.DataSource = products;
            productsComboBox.DisplayMember = "ProductName";
            productsComboBox.ValueMember = "ProductID";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Orders = new Order();
            Orders.CustomerID = Convert.ToString(customerIDComboBox.SelectedValue);
            Orders.EmployeeID = Convert.ToInt32(employeeIDComboBox.SelectedValue);
            Orders.OrderDate = orderDateCalendar.SelectionRange.Start;
            Orders.ShipVia = Convert.ToInt32(shipViaComboBox.SelectedValue);

            Product p = productsComboBox.SelectedItem as Product;

            Details = new Order_Detail();
            Details.ProductID = p.ProductID;
            Details.UnitPrice = p.UnitPrice.Value;
            Details.Quantity = Convert.ToInt16(quantityTextBox.Text);
            Details.Discount = 0.50F;
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}