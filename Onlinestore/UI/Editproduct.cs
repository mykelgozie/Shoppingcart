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
    public partial class Editproduct : Form
    {
        private int page_id;
        public Editproduct(int id)
        {
            InitializeComponent();
            page_id = id;
            database.DataBaseConnection();
            // query string 
            var sql = $"SELECT * FROM Product WHERE Id = {page_id}";
            var conn = database.QueryDatabase(sql);
            var result = conn.ExecuteReader();
            while (result.Read())
            {
                
                 textBox3.Text =   result.GetString(1).ToString();
                 textBox1.Text =   result.GetDecimal(2).ToString();
                 textBox2.Text = result.GetString(3).ToString();

            }



        }

        private void Editproduct_Load(object sender, EventArgs e)
        {
          
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            database.DataBaseConnection();

            var productName = UtilityClass.CheckIfEmpty(textBox3.Text);
            var productPrice = Convert.ToDecimal(textBox1.Text);
            var addedBy = UtilityClass.CheckIfEmpty(textBox2.Text);
            // query string 
            var sql = $"UPDATE Product SET Product_Name = '{productName}', Cost_Price = '{productPrice}', Added_by= '{addedBy}' WHERE Id = '{page_id}' ";
            var conn = database.QueryDatabase(sql);
            var result = conn.ExecuteReader();
            MessageBox.Show("Item Edited");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
