using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hw_4.Model;

namespace Hw_4
{
    public partial class Main : Form
    {
        NorthwindEntities context = new NorthwindEntities();

        public Main()
        {
            InitializeComponent();
            
            OrdersView.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "OrderID",
                    DataPropertyName = "OrderID",
                },

                new DataGridViewComboBoxColumn()
                {
                    HeaderText = "Customer",
                    DataSource = context.Customers.ToList(),
                    DisplayMember = "ContactName",
                    ValueMember = "CustomerID",
                    DataPropertyName = "CustomerID", ReadOnly = true
                },

                new DataGridViewComboBoxColumn()
                {
                    HeaderText = "Employee",
                    DataSource = context.Employees.ToList(),
                    DisplayMember = "FirstName",
                    ValueMember = "EmployeeID",
                    DataPropertyName = "EmployeeID", ReadOnly = true
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "OrderDate",
                    DataPropertyName = "OrderDate"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "ShippedDate",
                    DataPropertyName = "ShippedDate"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "ShipVia",
                    DataPropertyName = "ShipVia"
                }
            });

            OrdersView.AutoGenerateColumns = false;
            OrdersView.DataSource = context.Orders.OrderBy(o => o.OrderID).ToList();

            OrderDetailsView.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "OrderID",
                    DataPropertyName = "OrderID"
                },

                new DataGridViewComboBoxColumn() {
                    HeaderText = "Product",
                    DataSource = context.Products.ToList(),
                    DisplayMember = "ProductName",
                    ValueMember = "ProductID",
                    DataPropertyName = "ProductID", ReadOnly = true
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "UnitPrice",
                    DataPropertyName = "UnitPrice"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Quantity",
                    DataPropertyName = "Quantity"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Discount",
                    DataPropertyName = "Discount"
                }
            });
            OrderDetailsView.AutoGenerateColumns = false;
            OrderDetailsView.DataSource = context.Order_Details.OrderBy(o => o.OrderID).ToList();

            GoodsView.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "ProductID",
                    DataPropertyName = "ProductID",
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "ProductName",
                    DataPropertyName = "ProductName"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "SupplierID",
                    DataPropertyName = "SupplierID"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "CategoryID",
                    DataPropertyName = "CategoryID"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "UnitPrice",
                    DataPropertyName = "UnitPrice"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "UnitsInStock",
                    DataPropertyName = "UnitsInStock"
                }
            });
            GoodsView.AutoGenerateColumns = false;
            GoodsView.DataSource = context.Products.OrderBy(p => p.ProductID).ToList();

            CustomersView.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "CustomerID",
                    DataPropertyName = "CustomerID"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "CompanyName",
                    DataPropertyName = "CompanyName"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "ContactName",
                    DataPropertyName = "ContactName"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "ContactTitle",
                    DataPropertyName = "ContactTitle"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Address",
                    DataPropertyName = "Address"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "City",
                    DataPropertyName = "City"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Country",
                    DataPropertyName = "Country"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Phone",
                    DataPropertyName = "Phone"
                },
            });
            CustomersView.AutoGenerateColumns = false;
            CustomersView.DataSource = context.Customers.OrderBy(c => c.CustomerID).ToList();

            VendorsView.Columns.AddRange(new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "EmployeeID",
                    DataPropertyName = "EmployeeID"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "LastName",
                    DataPropertyName = "LastName"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "FirstName",
                    DataPropertyName = "FirstName"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "BirthDate",
                    DataPropertyName = "BirthDate"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "HireDate",
                    DataPropertyName = "HireDate"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Address",
                    DataPropertyName = "Address"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "City",
                    DataPropertyName = "City"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Country",
                    DataPropertyName = "Country"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "HomePhone",
                    DataPropertyName = "HomePhone"
                },

                new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Photo",
                    DataPropertyName = "Photo"
                },
            });
            VendorsView.AutoGenerateColumns = false;
            VendorsView.DataSource = context.Employees.OrderBy(e => e.EmployeeID).ToList();
        }

        private void addOrderButton_Click(object sender, EventArgs e)
        {
            List<Customer> customers = context.Customers.ToList();
            List<Employee> employees = context.Employees.ToList();
            List<Supplier> suppliers = context.Suppliers.ToList();
            List<Product> products = context.Products.ToList();

            Form2 f2 = new Form2(customers, employees, suppliers, products);
            var Result = f2.ShowDialog();

            if (Result == DialogResult.OK)
            {
                context.Orders.Add(f2.Orders);
                context.Order_Details.Add(f2.Details);
                context.SaveChanges();
                OrdersView.DataSource = context.Orders.ToList();
                OrderDetailsView.DataSource = context.Order_Details.ToList();
            }
            else if (Result == DialogResult.Cancel)
            {
                f2.Close();
            }
        }

        private void OrdersView_SelectionChanged(object sender, EventArgs e)
        {
            if (OrdersView.SelectedCells != null && OrdersView.SelectedCells.Count > 0)
            {
                int id = (int)OrdersView.SelectedCells[0].OwningRow.Cells[0].Value;

                List<Order_Detail> details = new List<Order_Detail>();
                details = context.Order_Details.Where(d => d.OrderID == id).ToList();
                details.Where(d => d.OrderID == id);
                OrderDetailsView.DataSource = details;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            List<Product> products = context.Products.ToList();
            List<Product> found = new List<Product>();

            foreach (Product d in products)
            {
                if (d.ProductName.Contains(searchTextBox.Text))
                {
                    found.Add(d);
                }
            }
            GoodsView.DataSource = found;
        }

        private void searchButton2_Click(object sender, EventArgs e)
        {
            List<Customer> customers = context.Customers.ToList();
            List<Customer> found = new List<Customer>();

            foreach (Customer s in customers)
            {
                if (s.ContactName.Contains(searchTextBox2.Text))
                {
                    found.Add(s);
                }
            }
            CustomersView.DataSource = found;
        }

        private void searchButton3_Click(object sender, EventArgs e)
        {
            List<Employee> employees = context.Employees.ToList();
            List<Employee> found = new List<Employee>();

            foreach (Employee s in employees)
            {
                if (s.FirstName.Contains(searchTextBox3.Text) || s.LastName.Contains(searchTextBox3.Text))
                {
                    found.Add(s);
                }
            }
            VendorsView.DataSource = found;
        }

        private void searchButton4_Click(object sender, EventArgs e)
        {
            List<Order_Detail> details = context.Order_Details.ToList();
            List<Order_Detail> found = new List<Order_Detail>();

            foreach (Order_Detail detail in details)
            {
                if (detail.Product.ProductName.Contains(orderSearchTextBox.Text)) //|| detail.UnitPrice.ToString().Contains(orderSearchTextBox.Text))
                {
                    found.Add(detail);
                }
            }
            OrderDetailsView.DataSource = found;
        }

        private void ordersSearchButton_Click(object sender, EventArgs e)
        {
            List<Order> orders = context.Orders.ToList();
            List<Order> found = new List<Order>();

            foreach (Order order in orders)
            {
                if (order.Customer.ContactName.Contains(ordersTextBox.Text)) //|| order.Employee.FirstName.Contains(ordersTextBox.Text))
                {
                    found.Add(order);
                }
            }
            OrdersView.DataSource = found;
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            List<Supplier> suppliers = context.Suppliers.ToList();
            List<Category> categories = context.Categories.ToList();
            List<Product> products = context.Products.ToList();

            Form3 f3 = new Form3(suppliers, categories, products);
            var result = f3.ShowDialog();

            if (result == DialogResult.OK)
            {
                context.Products.Add(f3.Products);
                context.SaveChanges();
                GoodsView.DataSource = context.Products.ToList();
            }

            else if (result == DialogResult.Cancel)
            {
                f3.Close();
            }
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            var result = f4.ShowDialog();

            if (result == DialogResult.OK)
            {
                context.Customers.Add(f4.Customers);
                context.SaveChanges();
                CustomersView.DataSource = context.Customers.ToList();
            }

            else if (result == DialogResult.Cancel)
            {
                f4.Close();
            }
        }

        private void addEmployeeButton_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            var result = f5.ShowDialog();

            if (result == DialogResult.OK)
            {
                context.Employees.Add(f5.Employees);
                context.SaveChanges();
                VendorsView.DataSource = context.Employees.ToList();
            }

            else if (result == DialogResult.Cancel)
            {
                f5.Close();
            }
        }

        private void searchEmployeeButton_Click(object sender, EventArgs e)
        {
            List<Order> orders = context.Orders.ToList();
            List<Order> found = new List<Order>();

            foreach (Order order in orders)
            {
                if (order.Employee.FirstName.Contains(employeeTextBox.Text))
                {
                    found.Add(order);
                }
            }
            OrdersView.DataSource = found;
        }

        private void searchPriceButton_Click(object sender, EventArgs e)
        {
            List<Order_Detail> details = context.Order_Details.ToList();
            List<Order_Detail> found = new List<Order_Detail>();

            foreach (Order_Detail detail in details)
            {
                if (detail.UnitPrice.ToString().Contains(priceTextBox.Text))
                {
                    found.Add(detail);
                }
            }
            OrderDetailsView.DataSource = found;
        }

        private void allDetailsButton_Click(object sender, EventArgs e)
        {
            OrderDetailsView.DataSource = context.Order_Details.OrderBy(o => o.OrderID).ToList();
        }
    }
}