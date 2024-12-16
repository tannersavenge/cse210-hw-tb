using System;
using System.Security.Cryptography.X509Certificates;

namespace EternalQuestGoal{
    public class SimpleGoal : Goal{
        public SimpleGoal(string name, int points) : base(name, points) {
                public override int RecordEvent(){
                    if (!IsComplete){
                    IsComplete = true;
                    return Points;
                }
            return 0;
            }
        public override string GetProgress(){
            return IsComplete ? "[X]" : "[ ]";
        }

        }
    }
    
}