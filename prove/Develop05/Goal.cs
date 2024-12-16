using System;

namespace EternalQuestGoal{
    public abstract class Goal{
        private string _name;
        private int _points;
        public string Name => _name;
        public int Points => _points;
        public bool IsComplete{
            get;
            set;
        }
        public Goal(string name, int points){
            _name = name;
            _points = points;
            IsComplete = false;
        }

         public abstract int RecordEvent();
        public abstract string GetProgress();

        public virtual string GetStringRepresentation(){
            return $"{GetType().Name}:{_name},{_points},{IsComplete}";
        }
         public static Goal CreateGoalFromString(string data){
            var parts = data.Split(':');
            var details = parts[1].Split(',');
            string type = parts[0];
            string name = details[0];
            int points = int.Parse(details[1]);
            bool isComplete = bool.Parse(details[2]);

            return type switch{
                "SimpleGoal" => new SimpleGoal(name, points) { IsComplete = isComplete },
                "EternalGoal" => new EternalGoal(name, points),
                "ChecklistGoal" => ChecklistGoal.CreateChecklistFromString(details),
                _ => throw new Exception("Unknown goal type")
            };
         }
         

    }
}