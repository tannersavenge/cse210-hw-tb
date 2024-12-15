using System;

namespace Journaltask{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            bool run=true;
            while(run){
                Console.WriteLine("\nJournal Program");
                Console.WriteLine("1. Write a New Entry");
                Console.WriteLine("2. Display All Entries");
                Console.WriteLine("3. Save Journal to File");
                Console.WriteLine("4. Load Journal from File");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice){
                    case "1":
                        Console.WriteLine("enter your journal entry: ");
                        string content = Console.ReadLine();
                        journal.AddEntry(content);
                        break;
                    case "2":
                        journal.displayEntries();
                        break;
                    case "3":
                        Console.WriteLine("Enter the name of the file you want to save a great example of this is ( ex: iLoveJournaling.txt)");
                        string saveFile = Console.ReadLine();
                        journal.SaveToFile(saveFile);
                        break;
                    case "4":
                        Console.WriteLine("give me the file you want to add to or load ( ex: iLoveJournaling.txt");
                        string loadFile = Console.ReadLine();
                        journal.LoadFromFile(loadFile);
                        break;
                    case "5":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("You didn't choose an option that works try again.");
                        break;

                }
            }
            Console.WriteLine("Thanks for using me have an amazing day!");
        }
    }
}