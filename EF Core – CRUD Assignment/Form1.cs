using EF_Core___CRUD_Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core___CRUD_Assignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dbContext = new NorthWindContext();
        }


        NorthWindContext dbContext;

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> employees = dbContext.Employees.Select(e => e.FirstName).ToList();
            lstKisiler.Items.AddRange(employees.ToArray());


            List<string> shippers = dbContext.Shippers.Select(s => s.CompanyName).ToList();
            lstTasima.Items.AddRange(shippers.ToArray());

            listView1.Columns.Clear();
            listView1.Columns.Add("Order ID", 80);
            listView1.Columns.Add("Order Date", 120);
            listView1.Columns.Add("Ship City", 100);



            this.MouseClick += Form1_MouseClick;

        }

        private void btnGetOrderList_Click(object sender, EventArgs e)
        {


            string selectedEmployee = lstKisiler.SelectedItem?.ToString();
            string selectedShipper = lstTasima.SelectedItem?.ToString();

            List<Employee> employees = dbContext.Employees.Include(emp => emp.Orders).ToList();
            List<Shipper> shippers = dbContext.Shippers.Include(shipper => shipper.Orders).ToList();

            listView1.Items.Clear();

            bool isEmployeeSelected = !string.IsNullOrEmpty(selectedEmployee);
            bool isShipperSelected = !string.IsNullOrEmpty(selectedShipper);

            bool isAnySelectionMade = isEmployeeSelected || isShipperSelected;

            foreach (var employee in employees)
            {
                foreach (var order in employee.Orders)
                {
                    bool isOrderValid = true;

                    if (isEmployeeSelected && !employee.FirstName.Equals(selectedEmployee))
                    {
                        isOrderValid = false;
                    }

                    if (isShipperSelected)
                    {
                        if (!order.ShipVia.HasValue)
                        {
                            isOrderValid = false;
                        }
                        else
                        {
                            Shipper orderShipper = shippers.FirstOrDefault(shipper => shipper.ShipperId == order.ShipVia.Value);

                            if (orderShipper == null || !orderShipper.CompanyName.Equals(selectedShipper))
                            {
                                isOrderValid = false;
                            }
                        }
                    }

                    if (isAnySelectionMade && !isOrderValid)
                    {
                        continue;
                    }

                    ListViewItem item = new ListViewItem(order.OrderId.ToString());
                    item.SubItems.Add(order.OrderDate.ToString());
                    item.SubItems.Add(order.ShipCity);
                    listView1.Items.Add(item);

                }
            }





        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            ClearListBoxSelections(this.Controls);
        }


        private void ClearListBoxSelections(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is ListBox listBox)
                {
                    listBox.ClearSelected();
                }
                else if (control.HasChildren)
                {
                    ClearListBoxSelections(control.Controls);
                }
            }
        }

        private void lstKisiler_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = lstKisiler.IndexFromPoint(e.Location);
                if (index == ListBox.NoMatches)
                {
                    lstKisiler.ClearSelected();
                }
            }
        }

        private void lstTasima_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = lstTasima.IndexFromPoint(e.Location);
                if (index == ListBox.NoMatches)
                {
                    lstTasima.ClearSelected();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                ListOrders();
            }




        }

        private void ListOrders()
        {
            List<Order> orders = dbContext.Orders.ToList();

            listView1.Items.Clear();

            foreach (var order in orders)
            {

                string shipperCompanyName = order.ShipVia.HasValue
                    ? dbContext.Shippers.FirstOrDefault(s => s.ShipperId == order.ShipVia.Value)?.CompanyName : "N/A";

                ListViewItem item = new ListViewItem(order.OrderId.ToString());
                item.SubItems.Add(order.Employee?.FirstName ?? "N/A");
                item.SubItems.Add(order.OrderDate.ToString());
                item.SubItems.Add(order.ShipCity);
                item.SubItems.Add(shipperCompanyName);
                listView1.Items.Add(item);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Order selectedOrder = GetSelectedOrder();
            if (selectedOrder != null)
            {
                Form2 form2 = new Form2(selectedOrder);
                form2.ShowDialog();

                
                if (form2.DialogResult == DialogResult.OK)
                {
                    
                    ListOrders();
                }
                else
                {
                    MessageBox.Show("Lütfen güncellenecek bir sipariþ seçin.");
                }
            }
        }

        private Order GetSelectedOrder()
        {
           
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                int orderId = int.Parse(selectedItem.Text);

               
                Order selectedOrder = dbContext.Orders.Include(o => o.Employee).
                    Include(o =>o.ShipViaNavigation) .FirstOrDefault(o => o.OrderId == orderId);

                return selectedOrder;
            }

            return null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Order selectedorder = GetSelectedOrder();
            if(selectedorder !=null)
            {
                dbContext.Orders .Remove(selectedorder);
                dbContext.SaveChanges();
                MessageBox.Show("Sipariþ Silindi");
                ListOrders();
            }
        }
    }

}