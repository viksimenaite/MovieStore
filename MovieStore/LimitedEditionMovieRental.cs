using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    abstract class LimitedEditionMovieRental : MovieRental
    {
        protected override DateTime DetermineBaseRentalPeriod(Movie movie)
        {
            return DateTime.Today.AddDays(3);
        }

        protected override int DetermineBonusOfRentalPeriod(Client client, Movie movie)
        {
            int bonusDays = 0;
            if (client.TotalNoOfOrders > 30) //loyal client
            {
                bonusDays = 2;
            }
            return bonusDays;
        }

        protected override int DetermineReductionOfRentalPeriod(Movie movie)
        {
            int reducedDays = 0;
            if ((DateTime.Today.Year - movie.ReleaseDate.Year) == 1)
            {
                reducedDays = 2;
            }
            return reducedDays;
        }
    }
}
