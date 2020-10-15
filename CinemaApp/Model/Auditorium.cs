using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CinemaApp.Models
{
    [Table("Auditorium")]
    public class Auditorium
    {
        [PrimaryKey, AutoIncrement]
        public int AuditoriumId { get; set; }

        public int InternalNumber { get; set; }

        public int CountPlaces { get; set; }

        public int CountRows { get; set; }


    }
}
