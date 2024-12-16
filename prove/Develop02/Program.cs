//https://stackoverflow.com/questions/8037070/whats-the-fastest-way-to-read-a-text-file-line-by-line
//https://stackoverflow.com/questions/7569904/easiest-way-to-read-from-and-write-to-files
//https://www.c-sharpcorner.com/csharp-tutorials
//https://stackoverflow.com/questions/7387085/how-to-read-an-entire-file-to-a-string-using-c

/*
This is tanner the author creator or inventor whichever you want to call it I followed all requirments and
i went a step further by doing the error handleing and added a system where the prompts are randomly asked.
The list is also set up in a way that i could add a multitide of prompts and it wouldnt ruin the code.
*/

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
                        journal.AddEntry();
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