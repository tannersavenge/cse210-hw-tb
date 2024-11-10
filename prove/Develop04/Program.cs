using System;
using System.Collections.Generic;
using System.Reflection;
using System.Timers;

public class WhyBeMindful
{
    private int duration;
    private string name;
    private string description;
 

    public WhyBeMindful(string name, string description){
        this.name;
        this.description = description;
    }

    public void SetDuration(int duration){
        this.duration = duration
    }

    public void StartActivity(){
        Console.Clear();
        Console.WriteLine($"starting {name} Activity");
        Console.WriteLine(description);
        Console.Write("please enter how many seconds you want this activity to last");
        duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Get ready to start");
        AnimatePause(3);
    }

    public void EndTheActivity(){
        Console.WriteLine("Great job your all done");
        Console.WriteLine($"Great you completed the {name} ");
        Console.WriteLine($"this activity was {duration} seconds long");
        AnimatePause(3);
    }

    // the amount of time i spent realizing i had to use protected was insane
    protected void AnimatePauseWithTimer(int seconds){ 
    int elapsedSeconds = 0;
    using (var timer = new System.Timers.Timer(1000)){
        timer.Elapsed += (sender, e) =>
        {
            Console.Write(".");
            elapsedSeconds++;
            if (elapsedSeconds >= seconds)
            {
                timer.Stop();
                Console.WriteLine();
            }
        };
        timer.Start();
        while (timer.Enabled) { } 
        }
    }
}

public class BreathingActivity : WhyBeMindful {
    public BreathingActivity() : base("Breathing", "This activity will help you relax by helping you through breathing in and out slowly. Just focus on your breathing."){}

public void PerformBreathing(){
    StartActivity();
    int duration = GetDuration();
    int elapsedTime = 0;

    while (elapsedTime < duration)
        {
            Console.WriteLine("Breathe in...");
            Countdown(3); // Small inefficiency in repeated code "Countdown(3)"

            Console.WriteLine("Breathe out...");
            Countdown(3);

            elapsedTime += 6;
        }

        EndTheActivity();
    }
}




}



