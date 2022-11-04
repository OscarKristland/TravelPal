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
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelDetails.xaml
    /// </summary>
    public partial class TravelDetails : Window
    {
        private string selectedTravelType;
        private TravelManager travelManager;
        private UserManager userManager;
        private User user;
        private Travel travels;

        public TravelDetails(UserManager userManager,TravelManager travelManager, Travel travel)
        {
            InitializeComponent();

            lblTripDestination.Content = travel.Destination;
            lblCountryDestination.Content = travel.Countries;
            lblNumberOfTravelers.Content = travel.Travellers;
            lblTripOrVacation.Content = travel.GetType().Name;

            if(travel is Trip)
            {
                Trip trip = travel as Trip;
                lblWorkOrLeisure.Content = trip.Type;
            }
            else if (travel is Vacation)
            {
                Vacation vacation = travel as Vacation;
                
                if(vacation.AllInclusive)
                {
                    lblWorkOrLeisure.Content = "All inclusive";
                }
                else
                {
                    lblWorkOrLeisure.Content = "Not all inclusive";
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
