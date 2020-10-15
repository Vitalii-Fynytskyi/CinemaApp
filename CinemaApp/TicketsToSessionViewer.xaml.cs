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
    /// Логика взаимодействия для TicketsToSessionViewer.xaml
    /// </summary>
    public partial class TicketsToSessionViewer : UserControl
    {
        List<Ticket> tickets;
        Auditorium auditorium;
        public TicketsToSessionViewer(List<Ticket> ticketsToSet, WindowObserveSession windowObserveSession)
        {
            tickets = ticketsToSet;
            InitializeComponent();
            using (SQLiteConnection connection = new SQLiteConnection(SharedData.DatabaseLocation))
            {
                connection.CreateTable<Auditorium>();
                auditorium = connection.Query<Auditorium>("SELECT * FROM Auditorium WHERE AuditoriumId = ?", tickets[0].AuditoriumNumber).FirstOrDefault();
            }
            int countRows = auditorium.CountRows, placesPerRow = auditorium.CountPlaces / auditorium.CountRows;
            for(int i = 0; i < countRows; ++i)
            {
                StackPanel horizontalStackPanel = new StackPanel();
                horizontalStackPanel.Orientation = Orientation.Horizontal;
                for(int j = 0; j < placesPerRow; ++j)
                {
                    TicketElement ticketElement = new TicketElement(tickets[placesPerRow * i + j], windowObserveSession);
                    horizontalStackPanel.Children.Add(ticketElement);
                }
                StackPanelOuter.Children.Add(horizontalStackPanel);
            }
        }
    }
}
