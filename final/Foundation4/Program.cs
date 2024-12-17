using System;
using System.Collections.Generic;

/*
    I looked into the swimming and exceeded the requirments by having more specific calculations for swimming
    Using encapsulation and abstraction with a reusable design to easily add a multitude of more new activities
    with little code improvement.
*/

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
