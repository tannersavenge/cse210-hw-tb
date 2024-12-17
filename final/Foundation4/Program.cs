using System;
using System.Collections.Generic;

namespace Project4{
    class Program
    {
        static void Main(string[] args)
        {
             var activities = new List<Activity>{
                new Running(new DateTime(2024, 12, 11), 30, 3.0), new Cycling(new DateTime(2024, 12, 2), 45, 15.5), new Swimming(new DateTime(2024, 12, 14), 60, 20)  
            };

            Console.WriteLine("Your Activity Tracker");
            foreach (var activity in activities){
                Console.WriteLine(activity.GetSummary());
            }

        }
    }
}
