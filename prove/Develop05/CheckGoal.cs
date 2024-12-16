namespace EternalQuestGoal{
    public class ChecklGoal : Goal{
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;
        public ChecklGoal(string name, int points, int targetCount, int bonusPoints)  : base(name, points){
            _targetCount = targetCount;
            _bonusPoints = bonusPoints
        }
    }
}