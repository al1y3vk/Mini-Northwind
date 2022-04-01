using Hw_4.Model;
using System;
using System.Windows.Forms;

namespace Hw_4
{
    public partial class Form4 : Form
    {
        public Customer Customers { get; private set; }

        public Form4()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Customers = new Customer();
            Customers.CustomerID = idTextBox.Text;
            Customers.CompanyName = companyTextBox.Text;
            Customers.ContactName = contactTextBox.Text;
            Customers.ContactTitle = titleTextBox.Text;
            Customers.Address = addressTextBox.Text;
            Customers.City = cityTextBox.Text;
            Customers.Country = countryTextBox.Text;
            Customers.Phone = phoneTextBox.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;  
        }
    }
}