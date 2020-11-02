using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    class SuburbMovieStore : AllAgeGroupsMovieStore
    {
        private readonly double kidsDiscount = 0.10;
        private readonly double loyalDiscount = 0.15;

        protected override double DeterminePrice(Movie movie)
        {
            double price = movie.BasePrice; //base price
            if (movie.TotalNoOfPurchases > 80) //if movie is popular
            {
                price += 1.5;
            }

            if ((DateTime.Today.Year - movie.ReleaseDate.Year) < 2) //if movie is quite new
            {
                price += 1;
            }
            return price;
        }
        protected override double ApplyDiscount(Client client, Movie movie)
        {
            double price = movie.BasePrice;
            if (client.TotalNoOfOrders > 10) //loyal client
            {
                price *= loyalDiscount;
            }
            else if (client.CalculateAge() < 16) // discount for kids
            {
                price *= (1 - kidsDiscount);
            }

            return price;
        }
    }
}
