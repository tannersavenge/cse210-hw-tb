using System;
using System.Collections.Generic;

namespace Project2{
    public class Product{
        private string _name;
        private string _productId;
        private double _pricePerUnit;
        private int _quantity;
        public string Name => _name;
        public string ProductId => _productId;
        public double PricePerUnit => _pricePerUnit;
        public int Quantity => _quantity; // The name '_quantity' does not exist in the current context
        
        public Product(string name, string productId, double pricePerUnit, int quantity){
            _name = name;
            _productId = productId;
            _pricePerUnit = pricePerUnit;
            _quantity = quantity; //The name '_quantity' does not exist in the current context
        }

        public double GetTotalPrice(){
            return _pricePerUnit * _quantity; //The name '_quantity' does not exist in the current context
        }
        public override string ToString(){
            return $"{_name} (ID: {_productId}) - ${_pricePerUnit} x {_quantity}"; //The name '_quantity' does not exist in the current context
        }
    }
}