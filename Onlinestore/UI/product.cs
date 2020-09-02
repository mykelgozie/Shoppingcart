using Onlinestore.Database;
using Onlinestore.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Onlinestore.UI
{
    public partial class product : Form
    {
        public product()
        {
            InitializeComponent();
        }

        private void product_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // add nes product button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
          
            // prodcutname
            var productName = UtilityClass.CheckIfEmpty(textBox1.Text);
            // price
            var productPrice = UtilityClass.CheckIfEmpty(textBox2.Text);
            // date 
            var date = dateTimePicker1.Value;
            // added by 
            var addedBy = UtilityClass.CheckIfEmpty(textBox3.Text);
            // get only date value tostring
            var dateValue = date.Date.ToShortDateString();
            database.DataBaseConnection();
            // sql string 
            var sql = $"INSERT INTO Product(product_Name, cost_Price, Added_By, Date_Added)" + $" VALUES ('{productName}', '{productPrice}', '{addedBy}', '{dateValue}')";
            // query database 
            var conn = database.QueryDatabase(sql);
            conn.ExecuteNonQuery();
            MessageBox.Show("Product Added");
            // set text box empty
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid Operation");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
