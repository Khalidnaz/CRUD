using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbConnectTest.Domain;
using DbConnectTest.Service;

namespace DbConnectTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService pservice = new ProductService();

            Products prod = pservice.GetById(32);
            Console.WriteLine("------------------------------------");
            Console.WriteLine($"Selected by Id 32: {prod.ProductName} - {prod.ProductDescription}");

            //foreach loop in the list
            IEnumerable<Products> prod2 = pservice.GetAllProducts();
            Console.WriteLine("------------------------------------");

            foreach (var item in prod2)
            {
                Console.WriteLine($" {item.ProductName} - {item.ProductDescription}");
            }

            Console.ReadLine();

        }
    }
}
