using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    class ChineseMovieStore : MovieStore
    {
        private readonly double loyalDiscount = 0.15;
        private readonly double kidsDiscount = 0.05;
        private readonly double PVM = 0.21;

        protected override bool IsAppropriateAge(Client client, Movie movie)
        {
            return true; // all movies are suitable for all ages in China
        }

        protected override double DeterminePrice(Movie movie)
        {
            double price = movie.BasePrice;
            if (movie.TotalNoOfPurchases > 1500) //if movie is popular
            {
                price += 1.5;
            }

            if ((DateTime.Today.Year - movie.ReleaseDate.Year) > 60) //if a movie is vintage
            {
                price += 2.8;
            }
            return price;
        }
        protected override double GetDiscount(Client client, Movie movie)
        {
            double discount = 0;
            if (client.TotalNoOfOrders > 30) //loyal client
            {
                discount = loyalDiscount;
            }else if (client.CalculateAge() < 16)
            {
                discount = kidsDiscount;
            }
            return discount;
        }

        protected override double CountFees(Movie movie)
        {
            if(movie.BasePrice < 22.0) //packages from China with a value of up to EUR 22 are not subject to VAT (PVM) since 2021
            {
                return 0.0;
            }
            else
            {
                return movie.BasePrice * PVM;
            }
            
        }

        protected override Boolean IsLegal(Movie movie) //China does not have a rating system. Only films that are passed as "suitable for all ages" are released
        {
            return movie.AgeRating == MPAARating.G || movie.AgeRating == MPAARating.PG;
        }
        protected override Boolean IsAlreadyInTheMarket(Movie movie) //it takes  8 months to reach a suburb store
        {
            DateTime availableDate = movie.ReleaseDate.AddMonths(8);
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
