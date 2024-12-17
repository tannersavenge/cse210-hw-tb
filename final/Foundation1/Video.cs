using System;
using System.Collections.Generic;
using System.Transactions;

namespace Project1{  
    public class Video{
        private int _length;
        private string _author;
        private string _title;
        private List<Comment> _comments;
        public string Title => _title;         
        public string Author => _author;
        public int Length => _length;

        public Video(string title, string author, int length){
            _title = title; 
            _author = author;
            _length = length;
            _comments = new List<Comment>();
        } 
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }
        public int GetCommentCount() 
        {
            return _comments.Count; 
        }
        public void DisplayInfo(){
            Console.WriteLine($"Title: {_title}"); 
            Console.WriteLine($"Author: {_author}");
            Console.WriteLine($"Length: {_length} seconds");
            Console.WriteLine($"Comments: {GetCommentCount()}"); //There is no argument given that corresponds to the required parameter 'comment' of 'Video.GetCommentCount(Comment)'
            Console.WriteLine("Comments:");
            foreach (var comment in _comments){
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}