using System;

namespace Project4{
    public class Activity{
        private string _date;
        private int _duration;
        protected string _unit = "miles";
        public string Date => _date;
        public int Duration => _duration;
        public Activity(string date, int duration){
            _date = date;
            _duration = duration;
        }
        public virtual double GetDistance(){
            return 0;
        }

        public virtual double GetSpeed(){
            return 0; 
        }
        public virtual string GetSummary(){
            return $"{Date} ({Duration} min)";
        }
        public void SetUnit(string unit)
        {
            _unit = unit; 
        }
    }
}