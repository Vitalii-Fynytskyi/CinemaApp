using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CinemaApp.ModelToView
{
    public class SessionToView : INotifyPropertyChanged
    {
        public int SessionId
        {
            get => sessionId;
            set
            {
                sessionId = value;
                OnPropertyChanged("SessionId");
            }
        }
        public string MovieTitle
        {
            get => movieTitle;
            set
            {
                movieTitle = value;
                OnPropertyChanged("MovieTitle");
            }
        }
        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                OnPropertyChanged("StartDate");
            }
        }
        public DateTime EndDate
        {
            get => endDate;
            set
            {
                endDate = value;
                OnPropertyChanged("EndDate");
            }
        }
        public int AvailableTickets
        {
            get => availableTickets;
            set
            {
                availableTickets = value;
                OnPropertyChanged("AvailableTickets");
            }
        }
        public string Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged("Type");
            }
        }
        public SessionToView(int sessionIdToSet,string movieTitleToSet, DateTime startDateToSet, DateTime endDateToSet, int availableTicketsToSet, string typeToSet)
        {
            SessionId = sessionIdToSet;
            MovieTitle = movieTitleToSet;
            StartDate = startDateToSet;
            EndDate = endDateToSet;
            AvailableTickets = availableTicketsToSet;
            Type = typeToSet;
        }
        public SessionToView() { }

        int sessionId;
        string movieTitle;
        DateTime startDate;
        DateTime endDate;
        int availableTickets;
        string type;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
