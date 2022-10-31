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
using TravelPal.Countries;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        private string selectedTravelType;
        public TravelManager travelManager;
        private UserManager userManager;
        private User user;


        public AddTravelWindow(UserManager userManager)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.userManager = userManager;
            this.user = userManager.SignedInUser as User;

            cboTripOrVacation.ItemsSource = Enum.GetNames(typeof(TripOrVacation));

            //Gör comboboxarna osynliga, sedan beroende på vilket val användaren gör blir de synliga.
            chboAllInclusive.Visibility = Visibility.Hidden;
            cboTripType.Visibility = Visibility.Hidden;

            //Laddar comboboxen för triptype
            foreach (TripType triptype in Enum.GetValues(typeof(TripType)))
            {
                cboTripType.Items.Add(triptype.ToString());
            }
            //laddar comboboxen för destinationslandet
            foreach (AllCountries countries in Enum.GetValues(typeof(AllCountries)))
            {
                cboCountryDestination.Items.Add(countries.ToString());
            }
        }

        private void chboAllInclusive_Checked(object sender, RoutedEventArgs e)
        {
            //All inclusive checked
            
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            string destination = txtDestination.Text;
            string tripOrVacation = Convert.ToString(cboTripOrVacation.SelectedItem);
            int passengers = Convert.ToInt32(txtNumberOfPassengers.Text);
            string countryDestinationString = cboCountryDestination.SelectedItem as string;
            AllCountries countryDestination = (AllCountries)Enum.Parse(typeof(AllCountries), countryDestinationString);
            string tripType = Convert.ToString(cboTripType.SelectedItem);

            // error messages if all fields haven't been filled in
            if (String.IsNullOrEmpty(txtDestination.Text))
            {
                MessageBox.Show("Please fill in the destination of your trip");
            }
            else if (cboTripOrVacation.SelectedItem == null)
            {
                MessageBox.Show("Please choose if this is a trip or vacation.");
            }
            else if (String.IsNullOrEmpty(txtNumberOfPassengers.Text))
            {
                MessageBox.Show("Please specify the number of passengers");
            }
            else if (cboCountryDestination.SelectedItem == null)
            {
                MessageBox.Show("Please select a country");
            }
            else if (cboTripType.SelectedItem == null)
            {
                MessageBox.Show("Please select what trip type this will be.");
            }
            else
            {
                //Add travel, ska skickas med????? till travelwindow, travelmanager och usermanager?????
                this.travelManager.AddTravel(destination, tripOrVacation, passengers, countryDestination, tripType);
                TravelWindow travelWindow = new(userManager);
                travelWindow.Show();

                //user travel = för att usern ska få sin resa till sitt användarkonto
                //travelmanager ska också få listan för att admin ska kunna se resan
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //Return to the travel window
            Close();
        }

        private void cboTripOrVacation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Should enable different things
            //if trip = trip type -> Leisure or work
            //if trip = vacation -> enable checkbox for all inclusive


            //Båda ska vara osynliga först, sen efter val ska den ena göras synlig.

            this.selectedTravelType = cboTripOrVacation.SelectedItem as string;

            if (this.selectedTravelType == "Trip")
            {
                cboTripType.Visibility = Visibility.Visible;
                chboAllInclusive.Visibility = Visibility.Hidden;
            }
            else if (this.selectedTravelType == "Vacation")
            {
                cboTripType.Visibility = Visibility.Hidden;
                chboAllInclusive.Visibility = Visibility.Visible;
            }
        }

    }
}
