using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
namespace EternalQuestGoal{
    class Program{
        private static int _totalPoints = 0;
        private static List<Goal> _goals = new List<Goal>(); 
        static void Main(string[] args)
        {
            LoadData();
            bool run = true;
            while (run){
                //Console.Clear();
                DisplayStatus();

                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. Record Event");
                Console.WriteLine("3. Show Points");
                Console.WriteLine("4. Save and Quit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice){
                    case "1":
                        CreateNewGoal();
                        break;
                    case "2":
                        RecordEvent();
                        break;
                    case "3":
                        ListGoals();
                        break;
                    case "4":
                        SaveData();
                        break;
                    default:
                        Console.WriteLine("Try to use an option that is possible");
                        Console.ReadLine();
                        break;
                }
            }
        }
        private static void DisplayStatus(){
            Console.WriteLine($"You have a total amount of point of {_totalPoints}");
            Console.WriteLine();
        }

        private static void CreateNewGoal(){
            Console.WriteLine("Select Goal Type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Check Goal");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Console.WriteLine("Enter your goal name: ");
            string name = Console.ReadLine();

            Console.WriteLine("How many points is that goal worth");
            int points = int.Parse(Console.ReadLine());


             Goal goal = choice switch
            {
                "1" => new SimpleGoal(name, points), "2" => new EternalGoal(name, points), "3" => CreateCheckGoal(name, points),  //The name 'CreateCheckGoal' does not exist in the current context
                _ => throw new Exception("not a good goal type")
            };

             _goals.Add(goal);
            Console.WriteLine("Awesome you made a new goal.");

        }
        private static CheckGoal CreateCheckGoal(string name, int points)
        {
            Console.Write("Enter target count: ");
            int targetCount = int.Parse(Console.ReadLine());

            Console.Write("Enter bonus points: ");
            int bonusPoints = int.Parse(Console.ReadLine());

            return new CheckGoal(name, points, targetCount, bonusPoints);
        }
        private static void RecordEvent()
        {
            ListGoals();
            Console.Write("Select a goal to record (enter the number): ");
            int index = int.Parse(Console.ReadLine()) - 1;
            if (index >= 0 && index < _goals.Count) 
            {
                int pointsEarned = _goals[index].RecordEvent(); 
                _totalPoints += pointsEarned;
                Console.WriteLine($"You got  {pointsEarned} amount of points points! Press Enter to keep going.");
                Console.ReadLine();
            }else{
                Console.WriteLine("Choose an actual goal or please recheck your spelling");
                Console.ReadLine();
            }

        }
        private static void ListGoals(){
            Console.WriteLine("\nGoals:");
            for (int i = 0; i < _goals.Count; i++){ 
                Console.WriteLine($"{i + 1}. {_goals[i].GetProgress()} {_goals[i].Name}"); 
            }
            Console.WriteLine();
        }

         private static void SaveData()
        {
            using (StreamWriter writer = new StreamWriter("goals.txt")){
                writer.WriteLine(_totalPoints);
                foreach (var goal in _goals){ //The name '_goals' does not exist in the current context
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("You saved your update. please press Enter to exit.");
            Console.ReadLine();
        }

        private static void LoadData(){
            if (File.Exists("goals.txt")){
                string[] lines = File.ReadAllLines("goals.txt");
                _totalPoints = int.Parse(lines[0]);
                for (int i = 1; i < lines.Length; i++){
                    _goals.Add(Goal.CreateGoalFromString(lines[i])); //The name '_goals' does not exist in the current context
                }
            }
        }


    }
}