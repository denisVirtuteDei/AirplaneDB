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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using Cursed1.ManagmentTables;
using Cursed1.Windows;

namespace Cursed1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window //, INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        //{
        //    field = value;
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        private FlightManagmentContext db;
        private ObservableCollection<FlightTable> _listBoxItemFlight;


        public MainWindow()
        {
            InitializeComponent();

            db = new FlightManagmentContext();

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

            DB.ItemsSource = _listBoxItemFlight;
            DB.Items.Refresh();
        }

        private void TextBlock_Click(object sender, RoutedEventArgs e)
        {
            WindowDialog wd = new WindowDialog();
            if (wd.ShowDialog() == true)
            {
                AdminWindow adminW = new AdminWindow();
                App.Current.MainWindow = adminW;
                adminW.Show();
                this.Close();
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
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


            DB.ItemsSource = _listBoxItemFlight;
            DB.Items.Refresh();
            db.SaveChanges();
        }

        private void Reservation_Click(object sender, RoutedEventArgs e)
        {
            if(DB.SelectedIndex != -1)
            {
                var item = _listBoxItemFlight.ToList()[DB.SelectedIndex];
                ReservationWin reservationWin = new ReservationWin(item.PK_Flight, item.FK_Route);
                reservationWin.Owner = this;

                reservationWin.ShowDialog();

                DB.SelectedIndex = -1;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            db.Dispose();
            this.Close();
        }

        private void DoSort_Click(object sender, RoutedEventArgs e)
        {
            var index = (SortingList.SelectedIndex == 1 ? 1 : 0).ToString();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(DB.ItemsSource);
            view.SortDescriptions.Insert(0,(new SortDescription(
                ((ComboBoxItem)TableHeaderList.SelectedItem).Tag.ToString() ?? "PK_Flight",
                (ListSortDirection)Enum.Parse(ListSortDirection.Ascending.GetType(), index))));

            DB.Items.Refresh();
            db.SaveChanges();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }


}
