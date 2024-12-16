using System;

namespace ScriptureMemorizer{
    public class Word{
        public string Text{
            get;
            set;
        }
        public bool IsHidden{
            get;
            set;
        }
        public Word(string text){
            Text = text;
            IsHidden = false;
        }
        public void Hide(){
            IsHidden = true;
        }
        public void RevealHint(){
            Console.WriteLine($"Hint: {Text[0]}..");
        }
        public override string ToString()
        {
            if(IsHidden){
                return new string('_', Text.Length);
            }else{
                return Text;
            }
        }
    }
}