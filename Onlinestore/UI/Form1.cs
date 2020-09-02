using Onlinestore.Database;
using Onlinestore.Interface;
using Onlinestore.Lib;
using Onlinestore.UI;
using Onlinestore.util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Onlinestore
{
    // form class
    public partial class Form1 : Form
    {
        public IProcesProduct cart;

        // offset start position 
        public int Start { get; set; } = 0;

        // number of rows 
        public int Next { get; set; } = 5;
        public Form1(IProcesProduct process)
        {
            InitializeComponent();
            cart = process;
        }
        //label button
        private void label1_Click(object sender, EventArgs e)
        {

        }
        // form loader
        private void Form1_Load(object sender, EventArgs e)
        {
            // check start position
            if (Start == 0)
            {
                button3.Enabled = false;
            }
            // query string
            var sqlString = $"select* from Product order by Product_Name offset {Start} rows fetch next {Next} rows only;";
            // reload result 
            QueryDataClass.QueryAllData(dataGridView1, sqlString);


        }

       
        // next button
        private void button4_Click(object sender, EventArgs e)
        {
            // set next button visible
            button3.Enabled = true;
            //clear disaplay
            dataGridView1.Rows.Clear();
            // create pagination
            Start = Start + 5;
            // query string
            var sqlString = $"select* from Product order by Product_Name offset {Start} rows fetch next {Next} rows only;";
            var count = QueryDataClass.QueryAllData(dataGridView1, sqlString);
            // enable prvious button 
            if (count == 0)
            {
                button4.Enabled = false;
            }

        }

        // datagrid view event 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
     
            // select Id value 
            var id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //select  product name value
            var name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //Select product price 
            var price = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //Select quantity
            var quantity = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            // get date value
            var dateAdded = DateTime.Now.ToString("yyyy-MM-dd");
            // check if value is not assigned 
            var valueId = UtilityClass.CheckIfIntEmpty(int.Parse(id));
            // new product object
            cart.AddToChart(valueId, name, Convert.ToDecimal(price), int.Parse(quantity), dateAdded);
            // display message
            MessageBox.Show("Item added sucessfully");

            }
            catch (Exception)
            {
                // display error
                MessageBox.Show("Operation Error ");
            }

        }

      

        // add product button 
        private void button6_Click(object sender, EventArgs e)
        {
            product page = new product();
            page.ShowDialog();
            database.DataBaseConnection();
        }

        // edit button
        private void button1_Click(object sender, EventArgs e)
        {
           // selected row Id 
            var id = dataGridView1.SelectedCells[0].Value.ToString();
            // convert Id to interger
            var idInt = Int32.Parse(id);
            // move to next page
            Editproduct Editpage= new Editproduct(idInt);
            Editpage.ShowDialog();
         
        }
        // check out button
        private void button5_Click(object sender, EventArgs e)
        {
         

            // check if chartclass has no value 
            if (ChartClass.shoppingChart.Count > 0)
            {
                // new apge 
                Checkout page = new Checkout(cart);
                page.ShowDialog();
            }

            // display message
            MessageBox.Show("No Item In Chart");

        }

        // delete button 
        private void button2_Click(object sender, EventArgs e)
        {
            // get id of selected item 
            var id = dataGridView1.SelectedCells[0].Value.ToString();
            int value = int.Parse(id);
            // database connection 
            database.DataBaseConnection();
            // query string 
            var sqlString =$"DELETE FROM Product WHERE Id = {value}";
            // query database 
            var result = database.QueryDatabase(sqlString);
             result.ExecuteNonQuery();
             // clear display result    
            dataGridView1.Rows.Clear();
            // display new result 
           QueryDataClass.QueryAllData(dataGridView1,sqlString);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        // select by price radio button
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        // select by name radio button
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // clear display result 
             dataGridView1.Rows.Clear();
            string word = "";
            // check if string is empty 
            UtilityClass.CheckIfEmpty(textBox2.Text);
            // radio button product name is checked 
            if (radioButton1.Checked)
            {
                word = textBox2.Text.Trim();
                var sqlquery = $"SELECT * FROM Product WHERE Product_Name = '{word}'";
                QueryDataClass.QueryAllData(dataGridView1, sqlquery);
            }

            // if radio button price is checked 
            if (radioButton2.Checked)
            {
                word = textBox2.Text;
                var price = Convert.ToDecimal(word);
                var sqlquery = $"SELECT * FROM Product WHERE Cost_Price = '{price}'";
                QueryDataClass.QueryAllData(dataGridView1, sqlquery);


            }

        }
        // previous button 
        private void button3_Click(object sender, EventArgs e)
        {
            // clear display
            dataGridView1.Rows.Clear();
            // check if sart is more than 0
            if (Start > 0)
            {
                Start = Start - 5;
                var sqlString = $"select* from Product order by Product_Name offset {Start} rows fetch next {Next} rows only;";
                var count = QueryDataClass.QueryAllData(dataGridView1, sqlString);
            }
            else if(Start == 0 )
            {
                // disable previous button 
                button3.Enabled = false;
                // Enable next button
                button4.Enabled = true;
            }
        }
    }
}
