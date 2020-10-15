using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Text;

namespace CinemaApp.ModelToView
{
    public class MovieToView
    {
        public int MovieID { get; set; }
        public string Title { get; set; }

        public int ReleaseYear { get; set; }

        public string Genre { get; set; }

        public TimeSpan Duration { get; set; }

        public MovieToView(int movieIdToSet, string titleToSet,int releaseYearToSet, string genreToSet,TimeSpan durationToSet)
        {
            MovieID = movieIdToSet;
            Title = titleToSet;
            ReleaseYear = releaseYearToSet;
            Genre = genreToSet;
            Duration = durationToSet;
        }
    }
}
