using System;
using System.Collections.Generic;

namespace MovieStore
{
    class Program
    {
        static void Main(string[] args)
        {
            MovieStore movieStore = new FamilyMovieStore();
            Client client = new Client("Tom", "Smith", "tommy2000", "123", new DateTime(2015, 5, 1), new DateTime(2000, 2, 9));

            List<Movie> movieList = new List<Movie>
            {
                new Movie("Up", new DateTime(2009, 1, 1), MPAARating.PG, 10.1),
                new Movie("Willy Wonka and the Chocolate Factory", new DateTime(1971, 1, 1), MPAARating.PG_13, 12.3),
                new Movie("Alone", new DateTime(2020, 2, 1), MPAARating.R, 10.1)
            };

        Console.WriteLine("Welcome to the movie store!\r\n");

            int count = 1;
            while (true)
            {
                Console.WriteLine("\r\nWe are offering the following movies:");

                foreach (Movie movie in movieList)
                {
                    Console.WriteLine(count.ToString() + ". " + movie.Name);
                    count++;
                }
                count = 1;

                Console.WriteLine("\r\nEnter the number of the movie you would like to get:");

                int index = GetIntInput(movieList.Count);

                double moviePrice = movieStore.Estimate(client, movieList[index - 1]);
                if (moviePrice > 0)
                {
                    Console.WriteLine("\r\nThe price of the movie \"" + movieList[index - 1].Name + "\" is: " + Math.Round(moviePrice, 2, MidpointRounding.AwayFromZero) + " eur\r\n");
                }
                else
                {
                    Console.WriteLine("\r\nSorry, this movie is not suitable for you\r\n");
                }
               
                Console.WriteLine("Would you like to exit the program?");
                Console.WriteLine("1 - yes\r\n2 - no");
                Console.WriteLine("Enter your answer:");
                if (GetIntInput(2) == 1)
                {
                    break;
                }

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
