using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CinemaApp.Models
{
    [Table("Movie")]
    public class Movie
    {
        [PrimaryKey, AutoIncrement]
        public int MovieID { get; set; }

        [MaxLength(40)]
        public string Title { get;set; }

        public int ReleaseYear { get; set; }

        [MaxLength(40)]
        public string Genre { get; set; }

        public int Duration { get; set; }

    }
}
