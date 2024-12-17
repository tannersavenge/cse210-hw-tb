using System;

namespace Project1{
    public class Comment{
        private string _name;
        private string _text;
        public string Name => _name;
        public string Text => _text; //The name '_text' does not exist in the current context
        public Comment(string name, string text){
            _name = name;
            _text = text; //The name '_text' does not exist in the current context
        }

    }

}