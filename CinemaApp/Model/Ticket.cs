using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CinemaApp.Models
{
    [Table("Ticket")]
    public class Ticket
    {
        [PrimaryKey,AutoIncrement]
        public int TicketId { get; set; }

        [Indexed]
        public int MovieNumber { get; set; }
        [Indexed]
        public int SessionNumber { get; set; }
        [Indexed]
        public int PlaceNumber { get; set; }
        [Indexed]
        public int AuditoriumNumber { get; set; }
        [MaxLength(30)]
        public string SellDate { get; set; }
        public int Price { get; set; }
        public byte IsBooked { get; set; } //0 is false, 1 is true

    }
}
