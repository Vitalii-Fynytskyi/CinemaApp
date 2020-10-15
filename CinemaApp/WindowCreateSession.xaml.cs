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
    /// Логика взаимодействия для WindowCreateSession.xaml
    /// </summary>
    public partial class WindowCreateSession : Window
    {
        DateTime startDate;
        DateTime endDate;
        public WindowCreateSession()
        {
            startDate = DateTime.Now;
            InitializeComponent();
            comboBoxMovieNames.ItemsSource = SharedData.MoviesFromDatabase;
            comboBoxAuditoriums.ItemsSource = SharedData.AuditoriumsFromDatabase;
            textBoxStartDate.Text = startDate.ToString();
        }

        private void comboBoxMovieNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //get duration of movie
            int duration = ((Movie)e.AddedItems[0]).Duration;

            //convert duration to timespan
            TimeSpan movieDuration = new TimeSpan(0, 0, duration);

            //get the default end date
            endDate = startDate + movieDuration;

            //display the date to text box
            textBoxEndDate.Text = endDate.ToString();

            //display duration to label
            LabelMovieDuration.Content = "Тривалість: " + movieDuration.ToString();
        }

        private void comboBoxAuditoriums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //get the selected auditorium's count places
            int auditoriumCountPlaces = ((Auditorium)e.AddedItems[0]).CountPlaces;

            LabelCountPlaces.Content = "Кількість місць: " + auditoriumCountPlaces;
        }
        bool hasErrors()
        {
            if(comboBoxMovieNames.SelectedItem == null)
            {
                MessageBox.Show("Не обрано назву фільму");
                return true;
            }
            if (comboBoxAuditoriums.SelectedItem == null)
            {
                MessageBox.Show("Не обрано зал");
                return true;
            }
            if(!Int32.TryParse(textBoxTicketPrice.Text,out int price))
            {
                MessageBox.Show("Ціну квитка вказано неправильно");
                return true;
            }
            if (comboBoxSessionType.SelectedItem == null)
            {
                MessageBox.Show("Не обрано тип сеансу");
                return true;
            }
            if (!DateTime.TryParse(textBoxStartDate.Text,out DateTime startDate))
            {
                MessageBox.Show("Не вірно вказано дату початку");
                return true;
            }
            if (!DateTime.TryParse(textBoxEndDate.Text, out DateTime endDate))
            {
                MessageBox.Show("Не вірно вказано дату кінця");
                return true;
            }
            int duration = (comboBoxMovieNames.SelectedItem as Movie).Duration;
            TimeSpan movieDuration= new TimeSpan(0,0,duration);
            if(endDate - startDate < movieDuration)
            {
                MessageBox.Show("Тривалість фільму довша ніж різниця між вказаними датами");
                return true;
            }
            return false;
        }
        private void buttonCreateNewSession_Click(object sender, RoutedEventArgs e)
        {
            if (hasErrors()) return;
            //get the start and end session dates
            DateTime.TryParse(textBoxStartDate.Text, out DateTime startDate);
            DateTime.TryParse(textBoxEndDate.Text, out DateTime endDate);
            string type = comboBoxSessionType.Text;
            Session sessionToInsert = new Session()
            {
                StartDate = startDate.ToString(),
                EndDate = endDate.ToString(),
                Type = type
            };
            int row = 0;
            using (SQLiteConnection connection = new SQLiteConnection(SharedData.DatabaseLocation))
            {
                connection.CreateTable<Session>();
                connection.CreateTable<Place>();
                connection.CreateTable<Ticket>();

                row = connection.Insert(sessionToInsert);
                if (row == 0)
                {
                    MessageBox.Show("Не вдалось створити сеанс 1");
                    connection.Close();
                    return;
                }
                Auditorium selectedAuditorium = comboBoxAuditoriums.SelectedItem as Auditorium;
                Movie selectedMovie = comboBoxMovieNames.SelectedItem as Movie;
                int selectedPrice = Convert.ToInt32(textBoxTicketPrice.Text);

                //create tickets that are available to be sold
                List<Ticket> ticketsToInsert = new List<Ticket>(selectedAuditorium.CountPlaces);

                //select places from database
                List<Place> placesFromDatabase = connection.Query<Place>("SELECT * FROM Place");

                int placesPerRow = selectedAuditorium.CountPlaces / selectedAuditorium.CountRows;

                for (int i = 0; i < selectedAuditorium.CountRows; ++i)
                {
                    char seatChar = Convert.ToChar((int)'A' + i);
                    for (int j = 1; j <= placesPerRow; ++j)
                    {
                        string seatNumber = j.ToString();
                        Place existedPlace = (from p in placesFromDatabase where p.Row == i + 1 && p.Number == j select p).FirstOrDefault();
                        if(existedPlace == null)
                        {
                            Place placeToInsert = new Place()
                            {
                                Row = i + 1,
                                Number = j,
                                PlaceName = $"{seatChar}{seatNumber}"
                            };
                            connection.Insert(placeToInsert);
                            placesFromDatabase.Add(placeToInsert);
                            existedPlace = placeToInsert;
                        }
                        ticketsToInsert.Add(new Ticket()
                        {
                            MovieNumber=selectedMovie.MovieID,
                            SessionNumber = sessionToInsert.SessionId,
                            PlaceNumber = existedPlace.PlaceId,
                            AuditoriumNumber = selectedAuditorium.AuditoriumId,
                            SellDate= "",
                            Price=selectedPrice
                        });
                        
                    }
                }
                connection.InsertAll(ticketsToInsert);
                SharedData.SessionsToView.Add(new SessionToView()
                {
                    SessionId = sessionToInsert.SessionId,
                    MovieTitle = selectedMovie.Title,
                    StartDate = startDate,
                    EndDate = endDate,
                    AvailableTickets = ticketsToInsert.Count,
                    Type = type
                });
            }
            this.Close();
        }
    }
}
