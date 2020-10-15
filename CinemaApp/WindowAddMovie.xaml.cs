using CinemaApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для WindowAddMovie.xaml
    /// </summary>
    public partial class WindowAddMovie : Window
    {
        public WindowAddMovie()
        {
            InitializeComponent();
        }
        private bool hasErrors()
        {
            if (String.IsNullOrWhiteSpace(TextBoxMovieTitle.Text))
            {
                MessageBox.Show("Недопустима назва фільму");
                return true;
            }
            if(!Int32.TryParse(TextBoxReleaseYear.Text,out int result))
            {
                MessageBox.Show("Невірно введено рік");
                return true;
            }
            if (String.IsNullOrWhiteSpace(TextBoxGenre.Text))
            {
                MessageBox.Show("Недопустимо вказано жанр");
                return true;
            }
            if (!TimeSpan.TryParse(TextBoxDuration.Text,out TimeSpan timeSpanResult))
            {
                MessageBox.Show("Невірно введено тривалість фільму");
                return true;
            }
            return false;
        }

        private void ButtonAddMovie_Click(object sender, RoutedEventArgs e)
        {
            if (hasErrors()) return;
            TimeSpan.TryParse(TextBoxDuration.Text, out TimeSpan movieDuration);
            Movie newMovie = new Movie()
            {
                Title = TextBoxMovieTitle.Text,
                ReleaseYear = Convert.ToInt32(TextBoxReleaseYear.Text),
                Genre = TextBoxGenre.Text,
                Duration = Convert.ToInt32(movieDuration.TotalSeconds)
            };
            int row = 0;
            using (SQLiteConnection connection = new SQLiteConnection(SharedData.DatabaseLocation))
            {
                connection.CreateTable<Movie>();
                row = connection.Insert(newMovie);
                if (row == 0)
                {
                    MessageBox.Show("Не вдалось додати фільм");
                }
            }
            if (row > 0)
            {
                SharedData.MoviesToView.Add(new ModelToView.MovieToView(newMovie.MovieID, newMovie.Title, newMovie.ReleaseYear, newMovie.Genre, movieDuration));
                SharedData.MoviesFromDatabase.Add(newMovie);
            }
            this.Close();
        }
    }
}
