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


    private void Countdown(int seconds)
    {
        int remainingSeconds = seconds;
        
        // Initialize a timer with a 1-second interval
        Timer timer = new Timer(1000);  // 1000 ms = 1 second
        
        // Define the event handler for each tick of the timer
        timer.Elapsed += (sender, e) =>
        {
            if (remainingSeconds > 0)
            {
                Console.Write(remainingSeconds + " ");
                remainingSeconds--;
            }
            else
            {
                timer.Stop();
                Console.WriteLine();
            }
        };
        timer.Start();
        while (timer.Enabled) { } 
    }
}

public class ReflectionActivity : WhyBeMindful {
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something selfless."
    };
    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

     private List<string> listedItems;

      public ListingActivity() : base("Listing", "This activity will help you think on the good things in your life by having you list as many things as you canabout a specific topic.") {
        listedItems = new List<string>();
    }

    public void PerformListing()
    {

        StartActivity();
        int duration = GetDuration();
        Random random = new Random();
        string chosenPrompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"Consider the following prompt:\n{chosenPrompt}");
        Console.WriteLine("You will have a few seconds to begin preparing your thoughts.");
        Countdown(5);

    Console.WriteLine("Start listing items. Type each item and press Enter:");
        
    DateTime startTime = DateTime.Now;
    while ((DateTime.Now - startTime).TotalSeconds < duration)
}






