using System;

namespace Project1{
    class Program
    {
        static void Main(string[] args)
        {
            var video1 = new Video("how to rizz up chicks", "James Charles", 600);
            var video2 = new Video("Why luigi mangione is innocent", "Luigi Mangione", 480);
            var video3 = new Video("How are you doing today you amazing TA", "Aidan Reeves", 42000);

            // the comment text was ai generated just the comments 
            video1.AddComment(new Comment("Chris", "This was really helpful!"));
            video1.AddComment(new Comment("Alex", "Great explanation!"));
            video1.AddComment(new Comment("Taylor", "Thanks for sharing!"));
            video2.AddComment(new Comment("Jordan", "I love this recipe."));
            video2.AddComment(new Comment("Morgan", "Can’t wait to try this!"));
            video2.AddComment(new Comment("Sam", "Looks delicious!"));
            video3.AddComment(new Comment("Jamie", "So relaxing!"));
            video3.AddComment(new Comment("Casey", "Perfect for beginners."));
            video3.AddComment(new Comment("Drew", "Loved the tips!"));

            var videos = new List<Video> { video1, video2, video3 };

            bool run = true;
            while(run){
                Console.Clear();
                Console.WriteLine("YouTube Video Manager");
                Console.WriteLine("1. Display Videos");
                Console.WriteLine("2. Sort Videos by Title");
                Console.WriteLine("3. Sort Videos by Author");
                 Console.WriteLine("4. Sort Videos by Length");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option (The number): ");
                string choice = Console.ReadLine();

                switch (choice){
                    case "1":
                        DisplayVideos(videos);
                        break;
                    case "2":
                        videos.Sort((v1, v2) => v1.Title.CompareTo(v2.Title));
                        Console.WriteLine("Videos sorted by Title.");
                        break;
                    case "3":
                        videos.Sort((v1, v2) => v1.Author.CompareTo(v2.Author)); // Sort by Author
                        Console.WriteLine("Videos sorted by Author.");
                        break;
                    case "4":
                        videos.Sort((v1, v2) => v1.Length.CompareTo(v2.Length)); // Sort by Length
                        Console.WriteLine("Videos sorted by Length.");
                        break;
                    case "5":
                        run = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
            }

        }
        private static void DisplayVideos(List<Video> videos){
            foreach (var video in videos){
                video.DisplayInfo();
            }
        }
    }
}
