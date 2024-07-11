using Services;
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

namespace View
{
    /// <summary>
    /// Interaction logic for HomeAdmin.xaml
    /// </summary>
    public partial class HomeAdmin : Page
    {
        private IBookingReservationService reservationService;
        public HomeAdmin()
        {
            InitializeComponent();
            reservationService = new BookingReservationService();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var listResevation = reservationService.getListBookingReservation();
            Decimal? total = listResevation.Sum(c => c.TotalPrice);
            DateOnly dateNow = DateOnly.FromDateTime(DateTime.Now);
            Decimal? totalPerDay = listResevation.Where(c=>c.BookingDate==dateNow).Sum(c=>c.TotalPrice);
            int count =listResevation.Count();
            txt_totalRevenue.Content=total.ToString();
            txt_revenueInDay.Content = totalPerDay.ToString();
            txt_NumberBooking.Content = count.ToString();
        }
    }
}
