using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStore
{
    abstract class AllAgeGroupsMovieStore : MovieStore
    {
        protected override bool IsAppropriateAge(Client client, Movie movie)
        {
            bool isAppropriate = false;
            int clientAge = client.CalculateAge();

            switch (movie.AgeRating)
            {
                case MPAARating.G:
                    isAppropriate = true;
                    break;
                case MPAARating.PG:
                    isAppropriate = true;
                    break;
                case MPAARating.PG_13:
                    if (clientAge >= 13)
                    {
                        isAppropriate = true;
                    }
                    break;
                case MPAARating.R:
                    if (clientAge >= 17)
                    {
                        isAppropriate = true;
                    }
                    break;
                case MPAARating.NC_17:
                    if (clientAge >= 18)
                    {
                        isAppropriate = true;
                    }
                    break;
                default:
                    throw new ArgumentException("Unknown age rating.");
            }
            return isAppropriate;
        }
    }
}
