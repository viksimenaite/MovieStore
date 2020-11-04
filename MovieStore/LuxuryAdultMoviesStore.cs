using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    class LuxuryAdultMoviesStore : MovieStore
    {
        private readonly double loyalDiscount = 0.15;

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
                price += 5.5;
            }

            if ((DateTime.Today.Year - movie.ReleaseDate.Year) > 60) //if a movie is vintage
            {
                price += 4.3;
            }
            return price + 10.2;
        }
        protected override double GetDiscount(Client client, Movie movie)
        {
            double discount = 0;
            if (client.TotalNoOfOrders > 30) //loyal client
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
        protected override bool IsAlreadyInTheMarket(Movie movie) //is available on the market on the release day
        {
            if (DateTime.Today.Year < movie.ReleaseDate.Year)
            {
                return false;
            }else if (DateTime.Today.Month < movie.ReleaseDate.Month)
            {
                return false;
            }else if ((DateTime.Today.Month == movie.ReleaseDate.Month && DateTime.Today.Day < movie.ReleaseDate.Day))
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
