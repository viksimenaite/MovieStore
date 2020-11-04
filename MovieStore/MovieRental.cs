using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    abstract class MovieRental
    {
        protected abstract Boolean IsAppropriateAge(Client client, Movie movie);
        protected abstract Boolean IsLegal(Movie movie);
        protected abstract Boolean IsAlreadyInTheMarket(Movie movie);

        protected abstract double DeterminePrice(Movie movie);
        protected abstract double GetDiscount(Client client, Movie movie);
        protected abstract double CountFees(Movie movie);

        protected abstract DateTime DetermineBaseRentalPeriod(Movie movie);
        protected abstract int DetermineReductionOfRentalPeriod(Movie movie);//by days
        protected abstract int DetermineBonusOfRentalPeriod(Client client, Movie movie);//by days

        public double EstimatePrice(Client client, Movie movie)
        {
            if (IsAppropriateAge(client, movie) && IsLegal(movie) && IsAlreadyInTheMarket(movie))
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

        public DateTime EstimateRentalPeriod(Client client, Movie movie)
        {
            DateTime rentalPeriod = DetermineBaseRentalPeriod(movie).AddDays(DetermineBonusOfRentalPeriod(client, movie)).AddDays((-1) * DetermineReductionOfRentalPeriod(movie));
            if (rentalPeriod > DateTime.Today)
            {
                return rentalPeriod;
            }
            else
            {
                return DateTime.MinValue;
            }

        }
    }
}
