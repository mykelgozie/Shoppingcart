using System;
using System.Collections.Generic;
using System.Text;

namespace Onlinestore.Lib
{
    public class ProductClass
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public  decimal ProductPrice { get; set; }
        public  string AddedBy { get; set; }
        public int Quantity { get; set; }
        public string DateAdded { get; set; } = null;
    }
}
