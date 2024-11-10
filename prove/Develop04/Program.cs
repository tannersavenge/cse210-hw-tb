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
        this.name = name;
        this.description = description;
    }
    public int GetDuration(){
        return duration;
    }
    public void SetDuration(int duration){
        this.duration = duration;
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

public class ReflectionActivity : WhyBeMindful
{
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

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience.") {}

    public void PerformReflection()
    {
        StartActivity();

        Random random = new Random();
        string chosenPrompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"Consider the following prompt:\n{chosenPrompt}");
        Console.WriteLine("When you have it in mind, press Enter to continue...");
        Console.ReadLine();

        int elapsedTime = 0;
        while (elapsedTime < GetDuration())
        {
            string question = questions[random.Next(questions.Count)];
            Console.WriteLine(question);
            Countdown(5);
            elapsedTime += 5;
        }

        EndTheActivity();
    }

    private void Countdown(int seconds)
    {
        int remainingSeconds = seconds;

        Timer timer = new Timer(1000);

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
public class ListingActivity : WhyBeMindful{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt peace this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> listedItems;

    public ListingActivity() : base("Listing", "This activity will help you think on the good things in your life by having you list as many things as you can about a specific topic.") 
    {
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
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                listedItems.Add(item);
            }
        }
        Console.WriteLine($"You listed {listedItems.Count} items:");
        foreach (string item in listedItems)
        {
            Console.WriteLine($"- {item}");
        }

        EndTheActivity();
    }

    private void Countdown(int seconds)
    {
        int remainingSeconds = seconds;

        Timer timer = new Timer(1000);

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

public class Program{
    static void Main(string[] args){
        while (true){
            Console.Clear();
            Console.WriteLine("Welcome to the why be mindful program");
            Console.WriteLine("please select and activity");
            Console.WriteLine("1. the breathing activity");
            Console.WriteLine("2. reflection activity");
            Console.WriteLine("3. listing activity");
            Console.WriteLine("4. Exit the code");
            Console.WriteLine("Put in your activity number 1-4");
            string choice = Console.ReadLine();

        }
        // i had to google the switcvh thing it really helped
        switch(choice){
            case "1":
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.PerformBreathing();
                break;
            case "2":
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                reflectionActivity.PerformReflection();
                break;

            case "3":
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.PerformListing();
                break;

            case "4":
                Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                return;

            default:
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                DelayUsingTimer(2000);
                break;
        }
    }
}




