using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    class KidsLowPriceLimitedEditionMovieRental : LimitedEditionMovieRental
    {
        private readonly double kidsDiscount = 0.10;
        private readonly double loyalDiscount = 0.15;
        private readonly double PVM = 0.21;

        protected override double CountFees(Movie movie)
        {
            return movie.BasePrice * PVM;
        }

        protected override double DeterminePrice(Movie movie)
        {
            double price = movie.BasePrice; //base price
            if (movie.TotalNoOfPurchases > 100) //if movie is popular
            {
                price += 0.5;
            }
            return price;
        }

        protected override double GetDiscount(Client client, Movie movie)
        {
            double discount = 0;
            if (client.TotalNoOfOrders > 20) //loyal client
            {
                discount = loyalDiscount;
            }

            if (client.CalculateAge() < 12) // discount for kids
            {
                discount += kidsDiscount;
            }

            return discount;
        }

        protected override bool IsLegal(Movie movie)
        {
            return true;
        }
        protected override bool IsAlreadyInTheMarket(Movie movie) 
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

        protected override bool IsAppropriateAge(Client client, Movie movie)
        {
            return true;
        }
    }
}
