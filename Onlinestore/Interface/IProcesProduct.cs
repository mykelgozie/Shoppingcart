using System;
using System.Collections.Generic;
using System.Text;

namespace Onlinestore.Interface
{
    // Iprocess Interface
    public interface  IProcesProduct
    {
        // add to cart 
       public void AddToChart(int id, string name, decimal price, int quantity, string date);

        // delete from cart
        public void DeleteProductFromChart(string value);
    }
}
