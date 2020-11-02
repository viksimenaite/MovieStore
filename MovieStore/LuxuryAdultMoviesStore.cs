﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    class LuxuryAdultMoviesStore : MovieStore
    {
        private readonly double familyDiscount = 0.25;
        private readonly double loyalDiscount = 0.15;
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

            if ((DateTime.Today.Year - movie.ReleaseDate.Year) > 60) //if movie is vintage
            {
                price += 4.3;
            }
            return price + 10.2;
        }
        protected override double ApplyDiscount(Client client, Movie movie)
        {
            double price = movie.BasePrice;
            if (client.TotalNoOfOrders > 30) //loyal client
            {
                price *= (1 - loyalDiscount);
            }
            return price;
        }

    }
}
