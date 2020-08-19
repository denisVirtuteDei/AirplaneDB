using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Cursed1.ManagmentTables;

namespace Cursed1
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private FlightManagmentContext db;
        private ObservableCollection<FlightTable> _listBoxItemFlight;
        private ObservableCollection<TicketTable> _listBoxItemTicket;

        public AdminWindow()
        {
            InitializeComponent();

            db = new FlightManagmentContext();

            Refreshh();

            var routesid = (
                from pass in db.RoutePass
                select pass).ToList();

            foreach (var elem in routesid)
            {
                fk.Items.Add(elem.PK_Route);
                depPoint.Items.Add(elem.DeparturePoint);
                depDate.Items.Add(elem.DepartureDate);
                arrPoint.Items.Add(elem.ArrivalPoint);
                arrDate.Items.Add(elem.ArrivalDate);
                fk_edit.Items.Add(elem.PK_Route);
            }

            var lastindex =
                from index in db.Flights
                select index;

            pk.Text = (lastindex.ToList().Last().PK_Flight + 1).ToString();

        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainW = new MainWindow();
            App.Current.MainWindow = mainW;
            mainW.Show();
            this.Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!fk.Text.Equals("") && !seats.Text.Equals(""))
            {
                Flights flights = new Flights
                {
                    FK_Route = Convert.ToInt32(fk.Text),
                    PK_Flight = Convert.ToInt32(pk.Text),
                    SeatCount = Convert.ToInt32(seats.Text)
                };

                db.Flights.Add(flights);
                db.SaveChanges();
                Flight_DB.Items.Refresh();
                pk.Text = (Convert.ToInt32(pk.Text) + 1).ToString();
                Refreshh();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Flight_DB.SelectedIndex != -1)
            {
                var item = _listBoxItemFlight.ToList()[Flight_DB.SelectedIndex];

                RoutePass routePass = db.RoutePass
                    .Where(o => o.PK_Route == item.FK_Route)
                    .FirstOrDefault();

                Flights flights = db.Flights
                    .Where(o => o.PK_Flight == item.PK_Flight)
                    .FirstOrDefault();


                routePass.ArrivalDate = Convert.ToDateTime(arrDate_edit.Text);
                routePass.ArrivalPoint = arrPoint_edit.Text;
                routePass.DepartureDate = Convert.ToDateTime(depDate_edit.Text);
                routePass.DeparturePoint = depPoint_edit.Text;
                flights.FK_Route = Convert.ToInt32(fk_edit.Text);
                flights.PK_Flight = Convert.ToInt32(pk_edit.Text);
                flights.SeatCount = Convert.ToInt32(seats_edit.Text);

                flights.RoutePass = routePass;

                db.SaveChanges();
                Refreshh();
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (Ticket_DB.SelectedIndex != -1)
            {
                var item = _listBoxItemTicket.ToList()[Ticket_DB.SelectedIndex];

                Tickets tickets = new Tickets
                {
                    PK_Ticket = item.PK_Ticket,
                    FK_Flight = item.FK_Flight,
                    FK_Passenger = item.FK_Passenger,
                    FK_Route = item.FK_Route,
                };

                db.Tickets.Attach(tickets);
                db.Tickets.Remove(tickets);

                db.SaveChanges();

                Ticket_DB.Items.Refresh();

                Ticket_DB.SelectedIndex = -1;

                Refreshh();
            }
            else if(Flight_DB.SelectedIndex != -1)
            {
                var item = _listBoxItemFlight.ToList()[Flight_DB.SelectedIndex];

                Flights flights = new Flights
                {
                    PK_Flight = item.PK_Flight,
                    SeatCount = item.SeatCount,
                    FK_Route = item.FK_Route,
                };

                db.Flights.Attach(flights);
                db.Flights.Remove(flights);

                db.SaveChanges();

                Flight_DB.Items.Refresh();
                Flight_DB.SelectedIndex = -1;

                Refreshh();
            }
        }

        private void DBList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DBList.SelectedIndex == 0 ? true : false)
            {
                AddButton.IsEnabled = true;
                EditButton.IsEnabled = true;
                Remove.IsEnabled = false;
            }
            else
            {
                AddButton.IsEnabled = false;
                EditButton.IsEnabled = false;
                Remove.IsEnabled = true;
            }
        }

        private void EditTab_Selected(object sender, RoutedEventArgs e)
        {
            //if (Flight_DB.SelectedIndex != -1)
            //{
            //    var item = _listBoxItemFlight.ToList()[Flight_DB.SelectedIndex];

            //    pk_edit.Text = item.PK_Flight.ToString();
            //    fk_edit.Text = item.FK_Route.ToString();
            //    seats_edit.Text = item.SeatCount.ToString();
            //    depPoint_edit.Text = item.DeparturePoint;
            //    arrPoint_edit.Text = item.ArrivalPoint;
            //    depDate_edit.Text = item.DepartureDate.ToString();
            //    arrDate_edit.Text = item.ArrivalDate.ToString();

            //}
            //else
            //{
            //    pk_edit.Text = "";
            //    fk_edit.Text = "";
            //    seats_edit.Text = "";
            //    depPoint_edit.Text = "";
            //    arrPoint_edit.Text = "";
            //    depDate_edit.Text = "";
            //    arrDate_edit.Text = "";
            //}
        }

        private void Flights_Selected(object sender, RoutedEventArgs e)
        {
            if (Flight_DB.SelectedIndex != -1)
            {
                var item = _listBoxItemFlight.ToList()[Flight_DB.SelectedIndex];

                pk_edit.Text = item.PK_Flight.ToString();
                fk_edit.Text = item.FK_Route.ToString();
                seats_edit.Text = item.SeatCount.ToString();
                depPoint_edit.Text = item.DeparturePoint;
                arrPoint_edit.Text = item.ArrivalPoint;
                depDate_edit.Text = item.DepartureDate.ToString();
                arrDate_edit.Text = item.ArrivalDate.ToString();

            }
            else
            {
                pk_edit.Text = "";
                fk_edit.Text = "";
                seats_edit.Text = "";
                depPoint_edit.Text = "";
                arrPoint_edit.Text = "";
                depDate_edit.Text = "";
                arrDate_edit.Text = "";
            }
        }

        private void AddTab_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void Refreshh()
        {
            _listBoxItemFlight = new ObservableCollection<FlightTable>(
                                 (from flights in db.Flights
                                  join Routes in db.RoutePass on flights.FK_Route equals Routes.PK_Route
                                  select new FlightTable
                                  {
                                      PK_Flight = flights.PK_Flight,
                                      FK_Route = flights.FK_Route,
                                      SeatCount = flights.SeatCount,
                                      DeparturePoint = Routes.DeparturePoint,
                                      ArrivalPoint = Routes.ArrivalPoint,
                                      DepartureDate = Routes.DepartureDate,
                                      ArrivalDate = Routes.ArrivalDate
                                  }));

            _listBoxItemTicket = new ObservableCollection<TicketTable>(
                                 (from tickets in db.Tickets
                                  join flights in db.Flights on tickets.FK_Flight equals flights.PK_Flight
                                  join routes in db.RoutePass on tickets.FK_Route equals routes.PK_Route
                                  join pass in db.Passengers on tickets.FK_Passenger equals pass.PK_Passenger
                                  select new TicketTable
                                  {
                                      PK_Ticket = tickets.PK_Ticket,
                                      FK_Flight = tickets.FK_Flight,
                                      FK_Route = tickets.FK_Route,
                                      FK_Passenger = tickets.FK_Passenger
                                  }));

            Flight_DB.ItemsSource = _listBoxItemFlight;
            Flight_DB.Items.Refresh();
            Ticket_DB.ItemsSource = _listBoxItemTicket;
            Ticket_DB.Items.Refresh();
        }
    }
}
