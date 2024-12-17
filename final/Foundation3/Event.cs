using System;

namespace Project3{
    public abstract class Event{
        private string _title;
        private string _description;
        private DateTime _date;
        private string _time;
        private Address _address;
        public string Title => _title;
        public string Description => _description;
        public DateTime Date => _date;
        public string Time => _time;
        public Address Location => _address;

        protected Event(string title, string description, DateTime date, string time, Address address){
            _title = title;
            _description = description;
            _date = date;
            _time = time;
            _address = address;
        }

        public virtual string GetStandardDetails(){
            return $"Title: {_title}\nDescription: {_description}\nDate: {_date.ToShortDateString()}\nTime: {_time}\nLocation: {_address}";
        }

        public abstract string GetFullDetails();
         public virtual string GetShortDescription(){
            return $"{GetType().Name}: {_title} on {_date.ToShortDateString()}";
        }
    }
}
