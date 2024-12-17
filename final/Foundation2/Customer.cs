using System;

namespace Project2{
    public class Customer{
        private string _name;
        private Address _address;
        public string Name => _name;
        public Address CustomerAddress => _address;
        public Customer(string name, Address address){
            _name = name;
            _address = address;
        }

        public bool LivesInUSA(){
            return _address.IsInUSA();
        }
         public override string ToString(){
            return $"{_name}\n{_address}";
        }
    }
}