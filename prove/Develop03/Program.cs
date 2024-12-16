using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;


namespace ScriptureMemorizer{
    class Program
    {
        static void Main(string[] args)
        {
            List<Scripture> scriptureLibrary = LoadScriptureLibrary();
            Random random = new Random();
            Scripture selectedScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];
            bool run = true;
            while(run){
                Console.Clear();
                if (selectedScripture.AreAllWordsHidden()){
                    Console.WriteLine("Great Job! You have fully memorized the scripture.");
                    break;
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
                        selectedScripture.HideRandomWords();
                        break;
                    case "2":
                        selectedScripture.ShowHint();
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
            if (File.Exists("scriptures.txt")){
                foreach (string line in File.ReadAllLines("scriptures.txt")){
                    var parts = line.Split("|");
                    if (parts.Length == 3){
                        library.Add(new Scripture(new Reference(parts[0], parts[1]), parts[2]));
                    }
                }
            }else{
                library.Add(new Scripture(new Reference("John", "3:16"), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
                library.Add(new Scripture(new Reference("Proverbs", "3:5-6"), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."));
                library.Add(new Scripture(new Reference("Psalm", "23:1"), "The Lord is my shepherd; I shall not want."));   
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