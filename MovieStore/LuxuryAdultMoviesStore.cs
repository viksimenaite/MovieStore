using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    class LuxuryAdultMoviesStore : MovieStore
    {
        private readonly double loyalDiscount = 0.15;
        private readonly double PVM = 0.21;

        protected override bool IsAppropriateAge(Client client, Movie movie)
        {
            int clientAge = client.CalculateAge();

            if (clientAge >= 18)
            {
                return true;
            }else
            {
                return false;
            }
 
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

    }
}
