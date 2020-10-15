using CinemaApp.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CinemaApp
{
    /// <summary>
    /// Логика взаимодействия для TicketElenent.xaml
    /// </summary>
    public partial class TicketElement : UserControl
    {
        Brush availableToPurchase = new SolidColorBrush(Color.FromRgb(0, 255, 0));
        Brush availableToPurchaseHovered = new SolidColorBrush(Color.FromRgb(0, 200, 0));
        Brush sold = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        Brush soldHovered = new SolidColorBrush(Color.FromRgb(200, 0, 0));
        Brush booked = new SolidColorBrush(Color.FromRgb(255, 200, 50));
        Brush bookedHovered = new SolidColorBrush(Color.FromRgb(255, 175, 50));


        Ticket ticket;
        WindowObserveSession windowObserveSession;
        string placeName;
        public TicketElement(Ticket ticketToSet, WindowObserveSession windowObserveSessionToSet)
        {
            ticket = ticketToSet;
            InitializeComponent();
            using (SQLiteConnection connection = new SQLiteConnection(SharedData.DatabaseLocation))
            {
                connection.CreateTable<Place>();
                placeName = connection.Query<Place>("SELECT * FROM Place WHERE PlaceId = ?", ticket.PlaceNumber).FirstOrDefault().PlaceName;
            }
            LabelTicketName.Content = placeName;
            if (ticket.SellDate != "")
            {
                OuterStackPanel.Background = sold;
                MenuItemMarkSold.IsEnabled = false;
                MenuItemMarkBooked.IsEnabled = false;
            }
            else if(ticket.IsBooked == 1)
            {
                OuterStackPanel.Background = booked;
                MenuItemDemarkBooked.IsEnabled = true;
                MenuItemMarkSold.IsEnabled = false;
                MenuItemMarkBooked.IsEnabled = false;
            }
            else
            {
                OuterStackPanel.Background = availableToPurchase;
            }

            windowObserveSession = windowObserveSessionToSet;
        }

        private void OuterStackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            if(OuterStackPanel.Background == availableToPurchase)
            {
                OuterStackPanel.Background = availableToPurchaseHovered;
            }
            else if(OuterStackPanel.Background == booked)
            {
                OuterStackPanel.Background = bookedHovered;

            }
            else
            {
                OuterStackPanel.Background = soldHovered;

            }
        }

        private void OuterStackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            if (OuterStackPanel.Background == availableToPurchaseHovered)
            {
                OuterStackPanel.Background = availableToPurchase;

            }
            else if (OuterStackPanel.Background == bookedHovered)
            {
                OuterStackPanel.Background = booked;
            }
            else if(OuterStackPanel.Background == soldHovered)
            {
                OuterStackPanel.Background = sold;
            }
        }


        private void MarkSold_Click(object sender, RoutedEventArgs e)
        {
            ticket.SellDate = DateTime.Now.ToString();
            using (SQLiteConnection connection = new SQLiteConnection(SharedData.DatabaseLocation))
            {
                connection.CreateTable<Ticket>();
                int row = connection.Execute("UPDATE Ticket SET SellDate = ? WHERE TicketId = ?", ticket.SellDate, ticket.TicketId);
                if (row != 1)
                {
                    MessageBox.Show("Не вдалось відмітити квиток проданим");
                    connection.Close();
                    return;
                }
                
            }
            windowObserveSession.sessionToView.AvailableTickets--;
            windowObserveSession.LabelAvailableTickets.Content = "Доступно квитків: " + windowObserveSession.sessionToView.AvailableTickets;
            OuterStackPanel.Background = sold;
            MenuItemMarkSold.IsEnabled = false;
            MenuItemDemarkBooked.IsEnabled = false;
            MenuItemMarkBooked.IsEnabled = false;
        }
        private void MarkBooked_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SharedData.DatabaseLocation))
            {
                connection.CreateTable<Ticket>();
                int row = connection.Execute("UPDATE Ticket SET IsBooked = ? WHERE TicketId = ?", 1, ticket.TicketId);
                if (row != 1)
                {
                    MessageBox.Show("Не вдалось відмітити квиток заброньованим");
                    connection.Close();
                    return;
                }
                
            }
            windowObserveSession.sessionToView.AvailableTickets--;
            windowObserveSession.LabelAvailableTickets.Content = "Доступно квитків: " + windowObserveSession.sessionToView.AvailableTickets;
            OuterStackPanel.Background = booked;
            MenuItemMarkBooked.IsEnabled = false;
            MenuItemDemarkBooked.IsEnabled = true;
        }
        private void DemarkBooked_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(SharedData.DatabaseLocation))
            {
                connection.CreateTable<Ticket>();
                int row = connection.Execute("UPDATE Ticket SET IsBooked = ? WHERE TicketId = ?", 0, ticket.TicketId);
                if (row != 1)
                {
                    MessageBox.Show("Не вдалось відмінити бронювання");
                    connection.Close();
                    return;
                }
            }
            windowObserveSession.sessionToView.AvailableTickets++;
            windowObserveSession.LabelAvailableTickets.Content = "Доступно квитків: " + windowObserveSession.sessionToView.AvailableTickets;
            OuterStackPanel.Background = availableToPurchase;
            MenuItemDemarkBooked.IsEnabled = false;
            MenuItemMarkBooked.IsEnabled = true;
        }
    }
}
