using CinemaApp.Models;
using CinemaApp.ModelToView;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для WindowObserveSession.xaml
    /// </summary>
    public partial class WindowObserveSession : Window
    {
        public SessionToView sessionToView;
        public WindowObserveSession(SessionToView sessionViewToSet)
        {
            InitializeComponent();
            sessionToView = sessionViewToSet;
            LabelMovieTitle.Content = "Назва фільму: " + sessionToView.MovieTitle;
            LabelMovieDuration.Content = "Триваість: " + (sessionToView.EndDate - sessionToView.StartDate);
            LabelTypeSession.Content = "Тип: " + sessionToView.Type;
            LabelStartDate.Content = "Дата початку: " + sessionToView.StartDate;
            LabelEndDate.Content = "Дата кінця: " + sessionToView.EndDate;
            LabelAvailableTickets.Content = "Доступно квитків: " + sessionToView.AvailableTickets;

            ///Get the tickets to current session from database
            List<Ticket> ticketsToSession;
            using (SQLiteConnection connection = new SQLiteConnection(SharedData.DatabaseLocation))
            {
                connection.CreateTable<Ticket>();
                connection.CreateTable<Movie>();
                ticketsToSession = connection.Query<Ticket>("SELECT * FROM Ticket WHERE SessionNumber = ?", sessionToView.SessionId);
                LabelReleaseYear.Content = "Рік виходу: " + connection.Query<Movie>("SELECT * FROM Movie WHERE MovieId = ?", ticketsToSession[0].MovieNumber).FirstOrDefault().ReleaseYear;
            }
            StackPanelOuter.Children.Add(new TicketsToSessionViewer(ticketsToSession, this));
        }
    }
}
