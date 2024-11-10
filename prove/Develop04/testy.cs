using System;
using System.Collections.Generic;
using System.Threading;

public class MindfulnessActivity
{
    private string name;
    private string description;
    private int duration;

    public MindfulnessActivity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    // Method to set the duration of the activity in seconds

    public void SetDuration(int duration)
    {
        this.duration = duration;
    }

    // Method to start the activity with a standard message

    public void StartActivity()
    {
        Console.Clear();
        Console.WriteLine($"Starting {name} Activity");
        Console.WriteLine(description);
        Console.Write("Please enter the duration (in secconds) for this activity: "); 
        duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        AnimatePause(3);  // Pause for 3 seconds before starting the activity
    }

    // Method to end the activity with a standard message
    public void EndActivity()x
    {
        Console.WriteLine("Awesome! You've completed the activity."); 
        Console.WriteLine($"Activity completed: {name}");
        Console.WriteLine($"Duration: {duration} seconds");
        AnimatePause(3);  // Pause for 3 seconds before finishing
    }

    // Method to handle a simple animation (spinner) during pauses
    protected void AnimatePause(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);  
        }
        Console.WriteLine();  
    }
    public int GetDuration()
    {
        return duration;
    }
}

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Method to guide the user through a breathing exercise
    public void PerformBreathing()
    {
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

        EndActivity();
    }

    // Helper method to create a countdown timer
    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000); // Wait for 1 second
        }
        Console.WriteLine();
    }
}

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
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

    public ReflectionActivity() : base("Reflection",
        "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    // Method to guide the user through the reflection exercise
    public void PerformReflection()
    {
        StartActivity();

        int duration = GetDuration();
        int timePassed = 0;

        Random random = new Random();

        string chosenPrompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"Consider the following prompt:\n{chosenPrompt}");
        Console.WriteLine("When you have it in mind, press Enter to continue...");
        Console.ReadLine();

        while (timePassed < duration)
        {
            string question = questions[random.Next(questions.Count)];
            Console.WriteLine(question);
            Countdown(5); // Pause for 5 seconds

            timePassed += 5;
        }

        EndActivity();
    }

    // Helper method to create a countdown timer
    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

public class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt peace this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> listedItems;

    public ListingActivity() : base("Listing", 
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
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

        EndActivity();
    }

    private void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

public class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("Please choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.PerformBreathing();
                    break;

                case "2":
                    

                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.PerformListing();
                    break;

                case "4":
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}
