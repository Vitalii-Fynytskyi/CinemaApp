using CinemaApp.Models;
using CinemaApp.ModelToView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;

namespace CinemaApp
{
    public static class SharedData
    {
        ///used once when reading from database
        //public static List<Ticket> TicketsFromDatabase;
        public static List<Movie> MoviesFromDatabase;
        public static List<Auditorium> AuditoriumsFromDatabase;
        public static List<Session> SessionsFromDatabase;
        //public static List<Place> PlacesFromDatabase;


        public static ObservableCollection<SessionToView> SessionsToView;
        public static ObservableCollection<MovieToView> MoviesToView;
        public static ObservableCollection<Auditorium> AuditoriumsToView;

        public static string DatabaseLocation = Path.Combine(Directory.GetCurrentDirectory(), "CimemaAppDB.sqlite");
    }
}
