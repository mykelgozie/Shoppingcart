using Onlinestore.Database;
using Onlinestore.Interface;
using Onlinestore.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Onlinestore.UI
{
    public partial class Checkout : Form
    {
        public IProcesProduct cart;
        public Checkout(IProcesProduct process)
        {
            InitializeComponent();
            cart = process;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chartItem()
        {
            QueryDataClass.LoadChartProduct(dataGridView2 , textBox2);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void Checkout_Load(object sender, EventArgs e)
        {   
            // load grid
            dataGridView2.ColumnCount = 5;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // rows heading 
            dataGridView2.Columns[0].Name = "Product Name";
            dataGridView2.Columns[1].Name = "Product Name";
            dataGridView2.Columns[3].Name = "Quantity";
            dataGridView2.Columns[2].Name = "Total Price";
            dataGridView2.Columns[4].Name = "DateAdded";
            // create button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "button";
            btn.Text = "Delete Item ";
            btn.UseColumnTextForButtonValue = true;
            // add button 
            dataGridView2.Columns.Add(btn);
            // load cart product
            QueryDataClass.LoadChartProduct(dataGridView2, textBox2);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          var id = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            // delete product from chart 
            cart.DeleteProductFromChart(id);
            // display Message 
            MessageBox.Show("Prodcut Deleted");
            // clear grid 
            dataGridView2.Rows.Clear();
            // load cart product
            QueryDataClass.LoadChartProduct(dataGridView2, textBox2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

            foreach (var item in ChartClass.shoppingChart)
            {
                // database connection 
                database.DataBaseConnection();
                // get time 
                DateTime dt = DateTime.Parse(item.DateAdded);
                // query string 
                var sql = $"INSERT INTO cartItem (product_Id, Quantity, Order_Date)" + $" VALUES ('{item.Id}', '{item.Quantity}', '{dt}')";
                // query datbase 
                var conn = database.QueryDatabase(sql);
                conn.ExecuteNonQuery();
                // display message 
                MessageBox.Show("Item Saved Succesfully");
                 // close aplication
                Application.Exit();
            }


            }
            catch (Exception)
            {

                MessageBox.Show("Operation Error");
            }


        }
    }
}
