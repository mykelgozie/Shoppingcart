using Onlinestore.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Onlinestore.Lib
{
    //process chart 
    public class ProcessproductClass : IProcesProduct
    {

        // add product to chart list
        public  void AddToChart(int id , string name, decimal price, int quantity, string date)
        {
            // new instance of product class
            var product = new ProductClass();
            product.Id = id;
            product.ProductName = name;
            product.ProductPrice = price;
            product.Quantity = quantity;
            product.DateAdded = date;
            ChartClass.shoppingChart.Add(product);
        }

        // delete prodcut from chart list
        public void DeleteProductFromChart(string value)
        {
            // loop through product 
            for (int i = 0; i < ChartClass.shoppingChart.Count; i++)
            {
                if (ChartClass.shoppingChart[i].Id == Int32.Parse(value))
                {
                    ChartClass.shoppingChart.RemoveAt(i);
                }
            }
        }

      
    }
}
