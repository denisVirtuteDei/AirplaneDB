using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Cursed1.ManagmentTables
{
    public class FlightTable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int flights;
        private int routes;
        private int seatCount;
        private string departurePoint;
        private string arrivalPoint;
        private DateTime departureDate;
        private DateTime arrivalDate;
        public int PK_Flight
        {
            get { return flights; }
            set { flights = value; NotifyPropertyChanged(); }
        }
        public int FK_Route
        {
            get { return routes; }
            set { routes = value; NotifyPropertyChanged(); }
        }
        public int SeatCount
        {
            get { return seatCount; }
            set { seatCount = value; NotifyPropertyChanged(); }
        }
        public string DeparturePoint
        {
            get { return departurePoint; }
            set { departurePoint = value; NotifyPropertyChanged(); }
        }
        public string ArrivalPoint
        {
            get { return arrivalPoint; }
            set { arrivalPoint = value; NotifyPropertyChanged(); }
        }
        public DateTime DepartureDate
        {
            get { return departureDate; }
            set { departureDate = value; NotifyPropertyChanged(); }
        }
        public DateTime ArrivalDate
        {
            get { return arrivalDate; }
            set { arrivalDate = value; NotifyPropertyChanged(); }
        }
    }
}
