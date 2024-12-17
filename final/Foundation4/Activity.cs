using System;

namespace Project4{
    public abstract class Activity{
        private DateTime _date; 
        private int _duration;
        protected string _unit = "miles";
        public DateTime Date => _date;
        public int Duration => _duration;
         public Activity(DateTime date, int duration) 
        {
            _date = date;
            _duration = duration;
        }
        public abstract double GetDistance(); 
        public abstract double GetSpeed(); 
        public abstract double GetPace();
        public virtual string GetSummary(){
            return $"{Date} ({Duration} min)";
        }
        public void SetUnit(string unit)
        {
            _unit = unit; 
        }
    }
}