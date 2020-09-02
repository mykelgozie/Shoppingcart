using Onlinestore.Database;
using Onlinestore.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Onlinestore.Lib
{
    // query class
    public  class QueryDataClass
    {
        

        public static int QueryAllData( DataGridView table , string sqlstring)
        {

            // create column in datgridview
            table.ColumnCount = 3;
            // auto size column
            table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //column properties
            table.Columns[0].Name = "Id";
            table.Columns[1].Name = "Product";
            table.Columns[2].Name = "Price";
            table.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            // textbox
            DataGridViewTextBoxColumn textboxColumn = new DataGridViewTextBoxColumn();
            // textbox header
            textboxColumn.HeaderText = "Quantity";
            // textbox name
            textboxColumn.Name = "text";
            // add textbox to datagridview
            table.Columns.Add(textboxColumn);
            // create new button
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            // button header
            btn.HeaderText = "Action";
            // button name 
            btn.Name = "button";
            // button text
            btn.Text = "Add To Cart ";
            btn.UseColumnTextForButtonValue = true;
            // hide row id 
            table.Columns["Id"].Visible = false;
            // addd button to datagrid
            table.Columns.Add(btn);
            // database connection
            database.DataBaseConnection();
            // query database 
            var conn = database.QueryDatabase(sqlstring);
            var result = conn.ExecuteReader();
            var count = 0;
            while (result.Read())
            {
                // count result
                count++;
                var id = result.GetInt32(0);
                var product = result.GetString(1);
                var price = result.GetDecimal(2);
                // populate datagrid
                table.Rows.Add(id, product, price);
            }
            return count;

        }

        // load product to cart 
        public static void LoadChartProduct(DataGridView box , TextBox text)
        {
            decimal payment = 0;
            foreach (var item in ChartClass.shoppingChart)
            {
                // total price of product 
                var totalPrice = item.Quantity * item.ProductPrice;
                payment += totalPrice;
                // display available product
                box.Rows.Add(item.Id, item.ProductName, item.Quantity, totalPrice.ToString(), item.DateAdded);

            }
            // display total price 
            text.Text = payment.ToString();



        }


    }
}
