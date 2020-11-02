using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    class Movie
    {
        private String name;
        private DateTime releaseDate;
        private int totalNoOfPurchases; // number of orders since release date
        private MPAARating ageRating;
        private double basePrice;

        public Movie(String name, DateTime releaseDate, MPAARating ageRating, double basePrice)
        {
            this.name = name;
            this.releaseDate = releaseDate;
            this.totalNoOfPurchases = 0;
            this.ageRating = ageRating;
            this.basePrice = basePrice;
        }

        public string Name { get => name; set => name = value; }
        public DateTime ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public int TotalNoOfPurchases { get => totalNoOfPurchases; set => totalNoOfPurchases = value; }
        public double BasePrice { get => basePrice; set => basePrice = value; }
        internal MPAARating AgeRating { get => ageRating; set => ageRating = value; }
    }
}
