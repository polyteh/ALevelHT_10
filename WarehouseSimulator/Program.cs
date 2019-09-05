using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductLib;
using WarehouseLib;

namespace WarehouseSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // warehouse to store products
            Warehouse myWarehouse = new Warehouse("My appartment", 100);

            // few initial settings
            DateTime newDeliveryTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            //create new products
            Beer beerHoogarden = new Beer("Hoogarden", 60, newDeliveryTime, 60);
            Beer beerObolon = new Beer("Obolon", 20, newDeliveryTime, 20);
            Beer beerPauliner = new Beer("Pauliner", 50, newDeliveryTime, 180);
            //beerHoogarden.BottleVolume = 0.33;


            TV samsungTV = new TV("Samsung", 1000, newDeliveryTime);
            TV philipsTV = new TV("Philips", 1500, newDeliveryTime, 200);
            //myTV.SizeInInches = 42;


            // add created products to the warehouse
            myWarehouse.AddProduct(beerHoogarden);
            myWarehouse.AddProduct(beerObolon);
            myWarehouse.AddProduct(beerPauliner);
            myWarehouse.AddProduct(samsungTV);
            myWarehouse.AddProduct(philipsTV);


            // print initial product list from warehouse
            var IninialeProducts = myWarehouse.GetProduct();
            Console.WriteLine($"Initial products on {newDeliveryTime.ToShortDateString()}");
            foreach (var product in IninialeProducts)
            {
                Console.WriteLine($"Product {product.Name,20} can store until {product.ExpirationDate().ToShortDateString()}");
            }
            Console.WriteLine(new string('=', 20));


            // select all product which can be store on the warehouse AFTER specific date (TimeCheck1), some kind of product prediction
            DateTime TimeCheck1 = newDeliveryTime.AddDays(30);
            var AvaliableProducts = myWarehouse.GetProduct();
            IEnumerable<BaseProduct> productsForSpecificTime = from q in AvaliableProducts where q.DaysToExpirationFrom(TimeCheck1) > 0 select q;
            Console.WriteLine($"Product avaliability prediction on {TimeCheck1.ToShortDateString()}");
            foreach (var product in productsForSpecificTime)
            {
                Console.WriteLine($"Product {product.Name,20} can store {product.DaysToExpirationFrom(TimeCheck1),5} days more, until {product.ExpirationDate().ToShortDateString()}");
            }
            Console.WriteLine($"Only {productsForSpecificTime.Count(),2} products from initial {myWarehouse.GetNumberOfProducts(),2} will be avaliable");
            Console.WriteLine(new string('=', 20));


            // simulation of time shift to the date TimeCheck2; expired product will be remove from warehouse, only ACTUAL products for the time
            DateTime TimeCheck2 = new DateTime(2019, 10, 5);
            myWarehouse.UpdateToDate(TimeCheck2);
            var AvaliableProductsSimulation = myWarehouse.GetProduct();
            Console.WriteLine($"Product avaliability simulation for warehouse internal time {myWarehouse.GetCurTime().ToShortDateString()}");
            foreach (var product in AvaliableProductsSimulation)
            {
                Console.WriteLine($"Product {product.Name,20} can store until {product.ExpirationDate().ToShortDateString()}");
            }
            Console.WriteLine($"Only { myWarehouse.GetNumberOfProducts(),2} products are avaliable");

            Console.ReadKey();
        }
    }
}
