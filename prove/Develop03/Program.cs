using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;

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
                    Console.WriteLine("Congratulations! You have fully memorized the scripture.");
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
                        saveScriptureLibrary(scriptureLibrary);
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
            List

        }
    }
}