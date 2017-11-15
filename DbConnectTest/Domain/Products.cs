using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbConnectTest.Domain
{
    public class Products
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public double BasePrice { get; set; }

        public bool IsVisible { get; set; }

        public bool IsDeleted { get; set; }
    }
}
