using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;

/*
https://learn.microsoft.com/en-us/dotnet/api/system.random?view=net-9.0
https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-9.0
https://learn.microsoft.com/en-us/dotnet/api/system.io.file?view=net-9.0
https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements
https://stackoverflow.com/questions/8037070/whats-the-fastest-way-to-read-a-text-file-line-by-line
https://stackoverflow.com/questions/7569904/easiest-way-to-read-from-and-write-to-files
https://www.c-sharpcorner.com/csharp-tutorials
https://stackoverflow.com/questions/7387085/how-to-read-an-entire-file-to-a-string-using-c

and with some debug help from like github ai

this code is not perfect but its works well keep pressing 1 at the begining to get started.

I exceeded requirments by adding the saving and loading process by showing a hint and letting the user add there own scripture i hvae done this

*/

namespace ScriptureMemorizer{
    class Program
    {
        static void Main(string[] args)
        {
            List<Scripture> scriptureLibrary = LoadScriptureLibrary();
            Random random = new Random();
            Scripture selectedScripture = null;
            bool run = true;
            while(run){
                Console.Clear();
                if (selectedScripture == null && scriptureLibrary.Count > 0){
                    selectedScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];
                }
                if (selectedScripture != null){
                    selectedScripture.Display();
                }
                if (selectedScripture != null && selectedScripture.AreAllWordsHidden()){
                    Console.WriteLine("Great Job! You have fully memorized the scripture.");
                    selectedScripture = null; // Reset to allow another scripture selection
                    continue;
                }

                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Hide Words");
                Console.WriteLine("2. Get Hint");
                Console.WriteLine("3. Add New Scripture");
                Console.WriteLine("4. Save Scriptures");
                Console.WriteLine("5. Quit");
                string input = Console.ReadLine();

                switch (input){
                    case "1":
                        if (selectedScripture != null){
                            selectedScripture.HideRandomWords();
                        }
                        break;
                    case "2":
                        if (selectedScripture != null){
                            selectedScripture.ShowHint();
                            Console.ReadLine(); 
                        }
                        break;
                    case "3":
                        AddNewScripture(scriptureLibrary);
                        break;
                    case "4":
                        SaveScriptureLibrary(scriptureLibrary);
                        break;
                    case "5":
                        Console.WriteLine("thank you for using the scripture memorizer if you really like it give me a hundred please.");
                        return;
                    default:
                        Console.WriteLine("Try to pick an option given");
                        break;
                }
            }
        }
        private static List<Scripture> LoadScriptureLibrary(){
            List<Scripture> library = new List<Scripture>();
             library.Add(new Scripture(
                new Reference("John", "3:16"),
                "For God so loved the world that he gave his only begotten Son, that whoever believes in him shall not perish but have eternal life."));
            
            library.Add(new Scripture(
                new Reference("Proverbs", "3:5-6"),
                "Trust in the Lord with all your heart might mind and strength and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."));
            
            library.Add(new Scripture(
                new Reference("2 Nephi", "2:25"),
                "Adam fell that men might be; and men are, that they might have joy."));
            
            library.Add(new Scripture(
                new Reference("Alma", "37:6"),
                "By small and simple things are great things brought to pass; and small means in many instances doth confound the wise."));
            
            if (File.Exists("scriptures.txt")){
                foreach (string line in File.ReadAllLines("scriptures.txt")){
                    var parts = line.Split("|");
                    if (parts.Length >= 3){
                        string book = parts[0];
                        string startVerse = parts[1];
                        string text = parts[2];
                        library.Add(new Scripture(new Reference(parts[0], parts[1]), parts[2]));
                    }
                }
            }
            return library;

        }
        private static void SaveScriptureLibrary(List<Scripture> library){
            using (StreamWriter writer = new StreamWriter("scriptures.txt")){
                    foreach (var scripture in library){
                        writer.WriteLine($"{scripture.Reference.Book}|{scripture.Reference.StartVerse}|{scripture.Reference.EndVerse}|{scripture.Text}");
                    }
            }
            Console.WriteLine("You saved the scripture.");
        }
        private static void AddNewScripture(List<Scripture> library){
            Console.WriteLine("What book is it bible, Book of Mormon, Pearl of great price etc.");
            string book = Console.ReadLine();
            Console.WriteLine("What verse are you startinh at.");
            string startVerse = Console.ReadLine();
            Console.WriteLine("Give me the full verse.");
            string text = Console.ReadLine();

            library.Add(new Scripture(new Reference(book, startVerse), text));
            Console.WriteLine("Great you added a scripture.");

        }
    }
}