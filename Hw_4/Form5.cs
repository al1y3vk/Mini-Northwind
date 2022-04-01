using Hw_4.Model;
using System;
using System.Windows.Forms;

namespace Hw_4
{
    public partial class Form5 : Form
    {
        public Employee Employees { get; private set; }

        public Form5()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Employees = new Employee();
            Employees.LastName = lastNameTextBox.Text;
            Employees.FirstName = firstNameTextBox.Text;
            Employees.BirthDate = birthDateCalendar.SelectionRange.Start;
            Employees.HireDate = hireDateCalendar.SelectionRange.Start;
            Employees.Address = addressTextBox.Text;
            Employees.City = cityTextBox.Text;
            Employees.Country = countryTextBox.Text;
            Employees.HomePhone = homePhoneTextBox.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}