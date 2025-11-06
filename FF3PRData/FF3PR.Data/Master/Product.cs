using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FF3PR.Data.Master
{
    public class Product
    {
        public Product(Product product) 
        { 
            id = product.id;
            content_id = product.content_id;
            group_id = product.group_id;
            coefficient = product.coefficient;
            purchase_limit = product.purchase_limit;
        }

        public Product() { }

        public int id { get; set; }
        public int content_id { get; set; }
        public int group_id { get; set; }
        public int coefficient { get; set; }
        public int purchase_limit { get; set; }
    }
}
