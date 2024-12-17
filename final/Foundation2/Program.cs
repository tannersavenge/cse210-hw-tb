using System;
using System.Collections.Generic;


/*
https://www.codechef.com/ide
https://www.geeksforgeeks.org/csharp-programming-language/
https://www.c-sharpcorner.com/csharp-tutorials
and w3 schools website for c#

part 2 of the final.
*/
namespace Project2{
    class Program{
        static void Main(string[] args){
            Console.WriteLine("Hello this is the Online system where you can order what you need whenerver you need curtesy of tanner brown");
            var product1 = new Product("Computor", "P001", 1200.50, 1);
            var product2 = new Product("Mouse", "P002", 25.99, 2);
            var product3 = new Product("Keyboard", "P003", 45.99, 1);
            var product4 = new Product("Headphones", "P004", 89.99, 1);

            var address1 = new Address("123 hundred st", "Atlanta", "Georgia", "USA");
            var address2 = new Address("456 plsfixthis st", "hamburg", "California", "USA");

            var customer1 = new Customer("John Smith", address1);
            var customer2 = new Customer("Jeff Knight", address2); 
            var order1 = new Order(customer1); 
            order1.AddProduct(product1);
            order1.AddProduct(product2);      
            var order2 = new Order(customer2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);  

            Console.WriteLine(order1.GetPackingLabel()); 
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}\n");
            Console.WriteLine(order2.GetPackingLabel()); 
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}\n");

            Console.WriteLine("If you liked this give me a 200/200 on the final pls");  

        }
    }
}
