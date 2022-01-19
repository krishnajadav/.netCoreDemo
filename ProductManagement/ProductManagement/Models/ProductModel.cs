using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Models
{
    public class ProductModel
    {
        public int Product_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_SKU { get; set; }
        public string Product_Description { get; set; }
        public decimal Product_Price { get; set; }
        public bool Is_Active { get; set; }
        public DateTime Created_Date { get; set; }
        public int Product_Category_ID { get; set; }
        public string Product_Category { get; set; }
    }
}
