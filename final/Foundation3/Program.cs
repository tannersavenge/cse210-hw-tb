using System;

namespace Project3{

    //https://www.guru99.com/c-sharp-inheritance-polymorphism.html
    //https://dotnettutorials.net/lesson/polymorphism-csharp/
    //https://www.c-sharpcorner.com/article/encapsulation-inheritance-and-polymorphism-in-c-sharp/
    //https://dev.to/iamcymentho/understanding-event-driven-architecture-in-c-with-real-life-scenarios-4h7g
    class Program{
        static void Main(string[] args){
            var address1 = new Address("123 random st", "Jackson", "MI", "USA"); 
            var address2 = new Address("456 hi st", "kansas", "MI", "USA");
            var address3 = new Address("789 whitchita st", "Austin", "Texas", "USA");
            
            var lecture = new Lecture( "Advancing databases", "A lecture on databases", new DateTime(2024, 4, 1),"10:00 AM", address1, "Dr. Keanu", 100);

            var reception = new Reception("Garcias Reception", "A wedding reception inside",  new DateTime(2024, 12, 5), "7:00 PM",address2, "rsvp@wedding.com");

            var outdoorGathering = new OutdoorGathering("Summer Barbecue", "A neighborhood Barbecue",  new DateTime(2024, 4, 3), "3:00 PM",address3, "Sunny");
            var events = new List<Event> { lecture, reception, outdoorGathering };
            Console.WriteLine("Event Details:\n");
            foreach (var ev in events){
                Console.WriteLine("Standard Details:");
                Console.WriteLine(ev.GetStandardDetails());
                Console.WriteLine("\nFull Details:");
                Console.WriteLine(ev.GetFullDetails());
                Console.WriteLine("\nShort Description:");
                Console.WriteLine(ev.GetShortDescription());
                Console.WriteLine(new string('-', 50));
            }
            Console.WriteLine("\nIf you like this event planner thing give me 100 please");
        }
    }
}
