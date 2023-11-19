using EF_Core___CRUD_Assignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EF_Core___CRUD_Assignment
{
    public partial class Form2 : Form
    {
        
        public Form2(Order existingOrder = null)
        {
            InitializeComponent();
            dbContext = new NorthWindContext();
            if (existingOrder != null)
            {
                this.existingOrder = existingOrder;
                
                btnAddUpdate.Text = "Güncelle"; 

                
                comboBox1.SelectedItem = existingOrder.Employee?.FirstName;
                dateTimePicker1.Value = (DateTime)existingOrder.OrderDate;
                comboBox2.SelectedItem = dbContext.Shippers.FirstOrDefault(s => s.ShipperId == existingOrder.ShipVia)?.CompanyName;
                textBox1.Text = existingOrder.ShipCity;
            }

        }


        NorthWindContext dbContext;
        private Order existingOrder;


        private void btnAddUpdate_Click(object sender, EventArgs e)
        {

            
            if (existingOrder != null)
            {
                existingOrder.Employee = dbContext.Employees.FirstOrDefault(emp => emp.FirstName == comboBox1.SelectedItem.ToString());
                existingOrder.OrderDate = dateTimePicker1.Value;
                existingOrder.ShipVia = dbContext.Shippers.FirstOrDefault(shipper => shipper.CompanyName == comboBox2.SelectedItem.ToString())?.ShipperId;
                existingOrder.ShipCity = textBox1.Text;

                dbContext.SaveChanges();
                MessageBox.Show("Sipariş güncellendi.");

                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
          
            else
            {
                
                Order newOrder = new Order
                {
                    Employee = dbContext.Employees.FirstOrDefault(emp => emp.FirstName == comboBox1.SelectedItem.ToString()),
                    OrderDate = dateTimePicker1.Value,
                    ShipVia = dbContext.Shippers.FirstOrDefault(shipper => shipper.CompanyName == comboBox2.SelectedItem.ToString())?.ShipperId,
                    ShipCity = textBox1.Text
                };

                dbContext.Orders.Add(newOrder);
                dbContext.SaveChanges();
                MessageBox.Show("Yeni sipariş eklendi.");

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        
    }
    
}
