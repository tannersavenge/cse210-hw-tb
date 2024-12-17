using System;

namespace Project4{
    public class Swimming : Activity{
        private int _laps;
        private const double LapDistanceMeters = 50; // apparently a map is 50 meters who knew not me
        public Swimming(DateTime date, int durationInMinutes, int laps): base(date, durationInMinutes){
            _laps = laps;
        }
        public override double GetDistance(){
            return (_laps * LapDistanceMeters / 1000) * 0.62; // making it to get to miles
        }
        public override double GetSpeed(){
            return (GetDistance() / DurationInMinutes) * 60;
        }
        public override double GetPace(){
           return DurationInMinutes / GetDistance();
        }
        public override string GetSummary(){
            return $"{base.GetSummary()} - Distance is : {GetDistance():0.0} miles,Your Speed is: {GetSpeed():0.0} mph,your Pace is: {GetPace():0.0} min/mile";
        }
    }
}