using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Onlinestore.Database
{
    // database connection class
    public class database
    {
        // datastring 
        public static string dataBaseString = "Data Source=.;Initial Catalog=shop;Integrated Security=True";
        // connection 
        public static SqlConnection connection;
        //  excute command
        public static SqlCommand command;

        // database connection
        public static void DataBaseConnection()
        {
            // 
            connection = new SqlConnection(dataBaseString);

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                // displkay error message 
                MessageBox.Show(" Cant Connect to database");
            }
        }

        // pass sql query string 
        public static SqlCommand QueryDatabase(string sqlQuery)
        {
            command = new SqlCommand(sqlQuery, connection);
            return command;
        }




    }
}
