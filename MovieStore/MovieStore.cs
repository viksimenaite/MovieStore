using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    abstract class MovieStore
    {
        protected abstract Boolean IsAppropriateAge(Client client, Movie movie);
        protected abstract double DeterminePrice(Movie movie);
        protected abstract double GetDiscount(Client client, Movie movie);
        protected abstract double CountFees(Movie movie);

        public double Estimate(Client client, Movie movie)
        {
            if (IsAppropriateAge(client, movie))
            {
                client.TotalNoOfOrders++;
                movie.TotalNoOfPurchases++;
                return (DeterminePrice(movie) + CountFees(movie)) * (1 - GetDiscount(client, movie));
            }
            else
            {
                return -1;
            }

        }
    }
}
