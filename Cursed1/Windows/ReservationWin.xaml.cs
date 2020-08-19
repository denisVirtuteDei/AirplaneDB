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
using System.Data.SqlClient;
using System.Collections.ObjectModel;

namespace Cursed1.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReservationWin.xaml
    /// </summary>
    public partial class ReservationWin : Window
    {
        private FlightManagmentContext db;
        private int fk_flight, fk_route;
        //private ObservableCollection<Passengers> _listBoxItemFlight;

        public ReservationWin(int f, int r)
        {
            InitializeComponent();
            db = new FlightManagmentContext();

            fk_flight = f;
            fk_route = r;
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            var res = db.Passengers.Select(PK => PK).ToList().Last();

            var fio = FIO.Text.Split(' ');

            Passengers passengers = new Passengers
            {
                PK_Passenger = res.PK_Passenger + 1,
                Surname = fio[0],
                Name = fio[1],
                FatherName = fio[2],
                E_mail = Mail.Text,
                PasAddress = Address.Text,
                Telephone = Telephone.Text
            };

            var tic = db.Tickets.Select(PK => PK).ToList().Last();

            Tickets tickets = new Tickets
            {
                FK_Flight = fk_flight,
                FK_Route = fk_route,
                FK_Passenger = passengers.PK_Passenger,
                PK_Ticket = tic.PK_Ticket + 1,
                Passengers = passengers
            };

            db.Passengers.Add(passengers);
            db.Tickets.Add(tickets);

            db.SaveChanges();

            Close();
        }
    }
}
