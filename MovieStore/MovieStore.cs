using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    abstract class MovieStore
    {
        protected abstract Boolean IsAppropriateAge(Client client, Movie movie);
        protected abstract double DeterminePrice(Movie movie);
        protected abstract double ApplyDiscount(Client client, Movie movie);

        public void GetMovie()
        {

        }
    }
}
