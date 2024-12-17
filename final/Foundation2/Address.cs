using System;

namespace Project2{
        public class Address{
            private string _streetAddress;
            private string _city;
            private string _state;
            private string _country;

            public Address(string streetAddress, string city, string state, string country){
                _streetAddress = streetAddress;
                _city = city;
                _state = state;
                _country = country;
            }
            public bool IsInUSA(){
                return _country.ToLower() == "usa";
            }
            public override string ToString(){
                return $"{_streetAddress}, {_city}, {_state}, {_country}";
            }

        }
}