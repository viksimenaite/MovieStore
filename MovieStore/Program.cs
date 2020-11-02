using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MovieStore
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieStore movieStore = new FamilyMovieStore();
            Client client = new Client("Tom", "Smith", new DateTime(2015, 5, 1), new DateTime(2000, 2, 9));

            List<Movie> MovieList = new List<Movie>
            {
                new Movie("Charlotte's Web", new DateTime(2006, 1, 1), MPAARating.G, 10.1),
                new Movie("The Fault in Our Stars", new DateTime(2014, 1, 1), MPAARating.PG_13, 12.3),
                new Movie("Alone", new DateTime(2020, 2, 1), MPAARating.R, 10.1)
            };

            Console.WriteLine("Welcome to the movie store!\r\n");
            int count = 1;
            while (true)
            {
                Console.WriteLine("\r\nWe are offering the following movies:");

                foreach (Movie movie in MovieList)
                {
                    Console.WriteLine(count.ToString() + ". " + movie.Name);
                    count++;
                }
                count = 1;

                Console.WriteLine("\r\nEnter the number of the movie you would like to get:");

                int index = GetIntInput(MovieList.Count);

                Console.WriteLine("\r\nThe price of the movie \"" + MovieList[index-1].Name + "\" is: " + movieStore.Estimate(client, MovieList[index-1]) + " eur\r\n");

                Console.WriteLine("Would you like to exit the program?");
                Console.WriteLine("1 - yes\r\n2 - no");
                if (GetIntInput(2) == 1)
                {
                    break;
                }

            }

            static int GetIntInput(int bound)
            {
                int input;
                while (!int.TryParse(Console.ReadLine(), out input) || input > bound || input < 1)
                {
                    Console.WriteLine("\r\nYou've entered an invalid number. Try again:");
                }
                return input;
            }


            

        }
    }
}
