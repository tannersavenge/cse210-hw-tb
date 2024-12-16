using System;

namespace EternalQuestGoal{
    public class CheckGoal : Goal{
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;
        public CheckGoal(string name, int points, int targetCount, int bonusPoints)  : base(name, points){
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
            _currentCount = 0;
        }
        public override int RecordEvent()
        {
            if (!IsComplete){
                _currentCount++;
                if (_currentCount >= _targetCount){
                    IsComplete = true;
                    return Points + _bonusPoints;
                }
                return Points;
            }
            return 0;
        }
        public override string GetProgress(){
             return $"[{_currentCount}/{_targetCount}]";
        }
        public override string GetStringRepresentation(){
            return $"{base.GetStringRepresentation()},{_targetCount},{_currentCount},{_bonusPoints}";
        }

        public static CheckGoal CreateCheckFromString(string[] details){
            string name = details[0];
            int points = int.Parse(details[1]);
            bool isComplete = bool.Parse(details[2]);
            int targetCount = int.Parse(details[3]);
            int currentCount = int.Parse(details[4]);
            int bonusPoints = int.Parse(details[5]);
            
             CheckGoal checkGoal = new CheckGoal(name, points, targetCount, bonusPoints){
                IsComplete = isComplete
            };
            checkGoal.SetCurrentCount(currentCount); 

            return checkGoal;
         }
          public void SetCurrentCount(int count){
            _currentCount = count;
        }
    }
}