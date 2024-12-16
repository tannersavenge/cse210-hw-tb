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
        public Scripture(Reference reference, string text){
            Reference = reference;
            Words = new List<Word>();
            foreach (string Word in text.Split(" ")){
                Words.Add(new Word(Word));
            }
        }
        public void HideRandomWords(){
            Random random = new Random();
            int WordsToHide = Math.Min(3, Words.Count);
        }
        
    }
}