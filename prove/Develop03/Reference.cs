using System;

namespace ScriptureMemorizer{
    public class Reference{
        public string Book{
            get;
            set;
        }
        public string StartVerse{
            get;
            set;
        }
        public string EndVerse{
            get;
            set;
        }
        public Reference(string book, string startVerse, string endVerse = null){
            Book = book;
            StartVerse = startVerse;
            EndVerse = endVerse;

        }
        public override string ToString()
        {
            if (EndVerse == null){
                return $"{Book} {StartVerse}";

            }else{
                return $"{Book} {StartVerse}-{EndVerse}";
            }
        }

    }

}