using System;

namespace Project4{
    public class Running : Activity{
        private double _distance;
        public Running(string date, int duration, double distance): base(date, duration){
            _distance = distance;
        }
        public override double GetDistance(){
            if (_unit == "miles"){
                return _distance;
            }else{
                return _distance * 1.60934;
            }
        }
        public override double GetSpeed(){
            return (_distance / Duration) * 60;
        }
        public override double GetPace(){
            return Duration / _distance;
        }        
    }
}