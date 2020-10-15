using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CinemaApp.Models
{
    [Table("Session")]
    public class Session
    {
        [PrimaryKey, AutoIncrement]
        public int SessionId { get; set; }
        [MaxLength(30)]
        public string StartDate { get; set; }
        [MaxLength(30)]
        public string EndDate { get; set; }
        [MaxLength(20)]
        public string Type { get; set; }
    }
}
