using System;
using System.Collections.Generic;

namespace Project2{
    public class Order{
        private List<Product> _products;
        private Customer _customer;
        public Order(Customer customer){
            _customer = customer;
            _products = new List<Product>();
        }
        public void AddProduct(Product product){
            _products.Add(product);
        }

        public double CalculateTotalCost(){
            double total = 0;
            foreach (var product in _products){
                total += product.GetTotalPrice();
            }
            if (_customer.LivesInUSA()){
                total += 5;
            }
            else{
                total += 35;
            }
            return total


             public string GetPackingLabel(){
                string label = "Packing Label:\n";
                foreach (var product in _products){
                    label += $"{product}\n";
                }
                return label
            }
            public string GetShippingLabel(){
                return $"Shipping Label:\n{_customer}";
            }
             

         }
    }
}