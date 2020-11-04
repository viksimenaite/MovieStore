using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    class AdultsLuxuryLongPeriodMovieRental : LongPeriodMovieRental
    {
        private readonly double loyalDiscount = 0.10;

        protected override bool IsAppropriateAge(Client client, Movie movie)
        {
            int clientAge = client.CalculateAge();
            return clientAge >= 18;
        }

        protected override double DeterminePrice(Movie movie)
        {
            double price = movie.BasePrice;
            if (movie.TotalNoOfPurchases > 1500) //if movie is popular
            {
                price += 8.5;
            }
            return price + 10.2;
        }
        protected override double GetDiscount(Client client, Movie movie)
        {
            double discount = 0;
            if (client.TotalNoOfOrders > 20) //loyal client
            {
                discount = loyalDiscount;
            }
            return discount;
        }

        protected override double CountFees(Movie movie)
        {
            return 0.0; //shady store
        }

        protected override bool IsLegal(Movie movie)
        {
            return true;
        }
        protected override bool IsAlreadyInTheMarket(Movie movie)
        {
            if (DateTime.Today.Year < movie.ReleaseDate.Year)
            {
                return false;
            }
            else if (DateTime.Today.Month < movie.ReleaseDate.Month)
            {
                return false;
            }
            else if ((DateTime.Today.Month == movie.ReleaseDate.Month && DateTime.Today.Day < movie.ReleaseDate.Day))
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
