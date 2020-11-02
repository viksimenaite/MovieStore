using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieStore
{
    class FamilyMovieStore: AllAgeGroupsMovieStore
    {
        private readonly double familyDiscount = 0.25;
        private readonly double loyalDiscount = 0.35;

        protected override double DeterminePrice(Movie movie)
        {
            double price = movie.BasePrice; //base price
            if (movie.TotalNoOfPurchases > 1000) //if movie is popular
            {
                price += 2.5;
            }

            if (DateTime.Today.Year == movie.ReleaseDate.Year) //if movie is released this year
            {
                price += 2;
            }
            return price;
        }
        protected override double ApplyDiscount(Client client, Movie movie)
        {
            double price = movie.BasePrice;
            if (client.TotalNoOfOrders > 20) //loyal client
            {
                price *= loyalDiscount;
            }
            else if (movie.AgeRating.Equals(MPAARating.G)) // discount for family-friendly movies
            {
                price *= (1 - familyDiscount);
            }

            return price;
        }

    }
}
