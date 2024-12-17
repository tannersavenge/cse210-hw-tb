using System;

namespace Project4{
    public class Cycling : Activity{
        private double _speed; // Speed in mph or kph

        public Cycling(string date, int duration, double speed): base(date, duration){
            _speed = speed;
        }

        public override double GetDistance(){
            return (_speed * Duration) / 60;
        }

        public override double GetSpeed(){
            if (_unit == "miles"){
                return _speed;
            }else{
                return _speed * 1.60934; // this is the kilometers converter
            }
        }
        public override double GetPace(){
            return 60 / _speed;
        }

        public override string GetSummary(){
            return $"{base.GetSummary()} - Cycling: Distance {GetDistance():F1} {_unit}, Speed {GetSpeed():F1} {_unit}/h, Pace {GetPace():F1} min per {_unit}";
        }
    }
}