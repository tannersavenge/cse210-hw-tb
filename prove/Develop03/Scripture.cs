using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer{
    public class Scripture{
        public Reference Reference{
            get;
            set;
        }
        private List<Word> Words{
            get;
            set;
        }
        public string Text{
            get;
            private set;

        }
        public Scripture(Reference reference, string text){
            Reference = reference;
            Text = text;
            
            Words = new List<Word>();
            foreach (string Word in text.Split(" ")){
                Words.Add(new Word(Word));
            }
        }
        public void HideRandomWords(){
            Random random = new Random();
            int WordsToHide = Math.Min(3, Words.Count);

            for (int i = 0; i < WordsToHide; i++){
                var visibleWords = Words.Where(h => !h.IsHidden).ToList();
                if(visibleWords.Count == 0 ){
                    break;
                }
                Word wordToHide = visibleWords[random.Next(visibleWords.Count)];
                wordToHide.Hide();

            }
        }
        public bool AreAllWordsHidden(){
            return Words.All(h => h.IsHidden);
        }
        public int GetTheVisibleWordCount(){
            return Words.Count(h => !h.IsHidden);
        }
        public void ShowHint(){
            var hiddenWords =Words.Where(h => h.IsHidden).ToList();
            if (hiddenWords.Count > 0){
                
                hiddenWords[0].RevealHint();
            }else{
                Console.WriteLine("No hidden words left.");
            }
        }
        public void Display(){
            string scriptureText = string.Join(" ", Words);
            Console.WriteLine($"{Reference}/n {scriptureText}");
        }
    }
}