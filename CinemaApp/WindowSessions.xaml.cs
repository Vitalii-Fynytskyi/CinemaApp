using CinemaApp.Models;
using CinemaApp.ModelToView;
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
    /// Логика взаимодействия для SessionsWindow.xaml
    /// </summary>
    public partial class WindowSessions : UserControl
    {
        public WindowSessions()
        {
            InitializeComponent();
            listViewFutureSessions.ItemsSource = SharedData.SessionsToView;
        }

        private void buttonViewSessionDetails_Click(object sender, RoutedEventArgs e)
        {
            SessionToView sessionToView = listViewFutureSessions.SelectedItem as SessionToView;
            WindowObserveSession windowObserveSession = new WindowObserveSession(sessionToView);
            windowObserveSession.ShowDialog();
        }

        private void buttonCreateNewSession_Click(object sender, RoutedEventArgs e)
        {
            WindowCreateSession windowCreateSession = new WindowCreateSession();
            windowCreateSession.ShowDialog();
        }

        private void listViewFutureSessions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            buttonViewSessionDetails.IsEnabled = true;
        }
    }
}
