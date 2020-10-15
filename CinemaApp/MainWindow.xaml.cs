using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CinemaApp.Models;
using CinemaApp.ModelToView;
using SQLite;

namespace CinemaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        WindowSessions windowSessions;
        WindowAuditoriums windowAuditoriums;
        WindowMovies windowMovies;
        public MainWindow()
        {
            readDatabase();
            createSessionsToView();
            createMoviesToView();
            createAuditoriumsToView();
            InitializeComponent();

            windowSessions = new WindowSessions();
            windowAuditoriums = new WindowAuditoriums();
            windowMovies = new WindowMovies();
            TabItemSessions.Content = windowSessions;
            TabItemAuditoriums.Content = windowAuditoriums;
            TabItemMovies.Content = windowMovies;
        }

        private void createAuditoriumsToView()
        {
            SharedData.AuditoriumsToView = new ObservableCollection<Auditorium>(SharedData.AuditoriumsFromDatabase);
        }

        private void createMoviesToView()
        {
            SharedData.MoviesToView = new ObservableCollection<MovieToView>();

            foreach (Movie movieDatabase in SharedData.MoviesFromDatabase)
            {
                SharedData.MoviesToView.Add(new MovieToView(movieDatabase.MovieID, movieDatabase.Title, movieDatabase.ReleaseYear, movieDatabase.Genre, new TimeSpan(0, 0, movieDatabase.Duration)));
            }
        }

        private void createSessionsToView()
        {
            SharedData.SessionsToView = new ObservableCollection<SessionToView>();
            foreach(Session session in SharedData.SessionsFromDatabase)
            {
                SessionToView sessionToView = new SessionToView();
                sessionToView.SessionId = session.SessionId;
                sessionToView.StartDate = Convert.ToDateTime(session.StartDate);
                sessionToView.EndDate = Convert.ToDateTime(session.EndDate);
                sessionToView.Type = session.Type;
                using (SQLiteConnection connection = new SQLiteConnection(SharedData.DatabaseLocation))
                {
                    connection.CreateTable<Movie>();
                    connection.CreateTable<Ticket>();
                    ///get all tickets to current session
                    List<Ticket> ticketsToSession = connection.Query<Ticket>("SELECT * FROM Ticket WHERE SessionNumber = ?", session.SessionId);

                    ///get all available tickets
                    List<Ticket> availableToSellTickets = (from t in ticketsToSession where t.SellDate == "" && t.IsBooked == 0 select t).ToList();
                    sessionToView.AvailableTickets = availableToSellTickets.Count;
                    Movie movie = connection.Query<Movie>("SELECT * FROM Movie WHERE MovieId = ?",ticketsToSession[0].MovieNumber)[0];
                    sessionToView.MovieTitle = movie.Title;
                }
                SharedData.SessionsToView.Add(sessionToView);
            }
        }

        private void readDatabase()
        {
            using (SQLiteConnection connection = new SQLiteConnection(SharedData.DatabaseLocation))
            {
                ///create tables if don't exist
                connection.CreateTable<Movie>();
                connection.CreateTable<Auditorium>();
                connection.CreateTable<Place>();
                connection.CreateTable<Session>();
                connection.CreateTable<Ticket>();

                SharedData.MoviesFromDatabase = connection.Query<Movie>("SELECT * FROM Movie");
                SharedData.AuditoriumsFromDatabase = connection.Query<Auditorium>("SELECT * FROM Auditorium");
                SharedData.SessionsFromDatabase = connection.Query<Session>("SELECT * FROM Session");
            }
        }
    }
}
