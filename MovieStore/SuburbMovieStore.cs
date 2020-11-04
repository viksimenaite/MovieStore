using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    class SuburbMovieStore : AllAgeGroupsMovieStore
    {
        private readonly double kidsDiscount = 0.10;
        private readonly double loyalDiscount = 0.15;
        private readonly double PVM = 0.21;

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
        protected override double GetDiscount(Client client, Movie movie)
        {
            double discount = 0;
            if (client.TotalNoOfOrders > 10) //loyal client
            {
                discount = loyalDiscount;
            }

            if (client.CalculateAge() < 16) // discount for kids
            {
                discount += kidsDiscount;
            }

            return discount;
        }

        protected override double CountFees(Movie movie)
        {
            return movie.BasePrice * PVM;
        }

        protected override bool IsLegal(Movie movie)
        {
            return true;
        }
        protected override bool IsAlreadyInTheMarket(Movie movie) //it takes 1 year to reach a suburb store
        {
            DateTime availableDate = movie.ReleaseDate.AddYears(1);
            if (DateTime.Today.Year < availableDate.Year)
            {
                return false;
            }
            else if (DateTime.Today.Month < availableDate.Month)
            {
                return false;
            }
            else if ((DateTime.Today.Month == availableDate.Month && DateTime.Today.Day < availableDate.Day))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
