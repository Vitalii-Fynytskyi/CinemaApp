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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для WindowAuditoriums.xaml
    /// </summary>
    public partial class WindowAuditoriums : UserControl
    {
        public WindowAuditoriums()
        {
            InitializeComponent();
            ListViewAuditoriums.ItemsSource = SharedData.AuditoriumsToView;

        }

        private void ButtonAddAuditorium_Click(object sender, RoutedEventArgs e)
        {
            WindowAddAuditorium windowAddAuditorium = new WindowAddAuditorium();
            windowAddAuditorium.ShowDialog();
        }
    }
}
