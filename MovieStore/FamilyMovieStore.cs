﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieStore
{
    class FamilyMovieStore: AllAgeGroupsMovieStore
    {
        private readonly double familyDiscount = 0.25;
        private readonly double loyalDiscount = 0.35;
        private readonly double PVM = 0.21;

        protected override double DeterminePrice(Movie movie)
        {
            double price = movie.BasePrice; //base price
            if (movie.TotalNoOfPurchases > 1000) //if movie is popular
            {
                price += 2.5;
            }

            if (DateTime.Today.Year == movie.ReleaseDate.Year) //if movie is released this year
            {
                price += 2;
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
            else if (movie.AgeRating.Equals(MPAARating.G)) // discount for family-friendly movies
            {
                discount = familyDiscount;
            }

            return discount;
        }

        protected override double CountFees(Movie movie)
        {
            return movie.BasePrice * PVM;
        }

        protected override Boolean IsLegal(Movie movie)
        {
            return true;
        }
        protected override Boolean IsAlreadyInTheMarket(Movie movie) //is available on the market after 2 months after release day
        {
            DateTime availableDate = movie.ReleaseDate.AddMonths(2);
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
