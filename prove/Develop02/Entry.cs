using System;

namespace Journaltask{
    public class Entry{
        public string Date{
            get;
            set;
        }
        public string Prompt{
            get;
            set;
        }
        public string Content{
            get;
            set;
        }
        public Entry(string date,string prompt, string content){
            Date = date;
            Prompt = prompt;
            Content = content;
        }

        public override string ToString(){
            return $"Date: {Date}/nPrompt: {Prompt}/n Content: {Content}/n";
        }
    }
}