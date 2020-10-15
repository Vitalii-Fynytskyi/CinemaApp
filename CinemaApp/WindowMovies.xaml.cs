using CinemaApp.ModelToView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для WindowMovies.xaml
    /// </summary>
    public partial class WindowMovies : UserControl
    {
        public WindowMovies()
        {
            InitializeComponent();
            ListViewMovies.ItemsSource = SharedData.MoviesToView;
        }

        private void ButtonAddNewMovie_Click(object sender, RoutedEventArgs e)
        {
            WindowAddMovie windowAddMovie = new WindowAddMovie();
            windowAddMovie.ShowDialog();
        }
    }
}
