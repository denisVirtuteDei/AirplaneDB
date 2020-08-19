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
    public class TicketTable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int tickets;
        private int routes;
        private int passengers;
        private int flights;

        public int PK_Ticket
        {
            get { return tickets; }
            set { tickets = value; NotifyPropertyChanged(); }
        }        
        public int FK_Route
        {
            get { return routes; }
            set { routes = value; NotifyPropertyChanged(); }
        }
        public int FK_Passenger
        {
            get { return passengers; }
            set { passengers = value; NotifyPropertyChanged(); }
        }
        public int FK_Flight
        {
            get { return flights; }
            set { flights = value; NotifyPropertyChanged(); }
        }
    }
}
