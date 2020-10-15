using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CinemaApp.Models
{
    [Table("Place")]
    public class Place
    {
        [PrimaryKey,AutoIncrement]
        public int PlaceId { get; set; }

        public int Row { get; set; }

        public int Number { get; set; }

        [MaxLength(3)]
        public string PlaceName { get; set; }


    }
}
