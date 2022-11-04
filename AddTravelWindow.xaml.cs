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
        private TravelManager travelManager;
        private UserManager userManager;
        private User user;
        private Travel travels;

        public AddTravelWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.userManager = userManager;
            this.user = userManager.SignedInUser as User;
            this.travelManager = travelManager;

            UpdateUi();
        }

        //Updates the UI, makes unique comboboxes hidden
        private void UpdateUi()
        {
            cboTripOrVacation.ItemsSource = Enum.GetNames(typeof(TripOrVacation));

            //Gör comboboxarna osynliga, sedan beroende på vilket val användaren gör blir de synliga.
            chboAllInclusive.Visibility = Visibility.Hidden;
            cboTripType.Visibility = Visibility.Hidden;
            lblWorkOrLeisure.Visibility = Visibility.Hidden;

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

        //checkbox if its all inclusive or not
        private void chboAllInclusive_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        //Button where a travel is added to the users own list of travels
        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
                        

            // error messages if all fields haven't been filled in
            if (String.IsNullOrEmpty(txtDestination.Text))
            {
                MessageBox.Show("Please fill in the destination of your trip");
            }
            else if (cboTripOrVacation.SelectedItem == null)
            {
                MessageBox.Show("Please choose if this is a trip or vacation.");
            }
            else if (String.IsNullOrEmpty(txtNumberOfTravellers.Text))
            {
                MessageBox.Show("Please specify the number of travellers");
            }
            else if (cboCountryDestination.SelectedItem == null)
            {
                MessageBox.Show("Please select a country");
            }
            else
            {
                string destination = txtDestination.Text;
                string tripOrVacation = Convert.ToString(cboTripOrVacation.SelectedItem);
                int travellers = Convert.ToInt32(txtNumberOfTravellers.Text);
                string countryDestinationString = cboCountryDestination.SelectedItem.ToString();
                AllCountries countryDestination = (AllCountries)Enum.Parse(typeof(AllCountries), countryDestinationString);

                if (cboTripOrVacation.SelectedItem.ToString() == "Vacation")
                {
                    //Create vacation
                    bool isAllInclusive = false;
                    if (chboAllInclusive.IsChecked == true)
                    {
                        isAllInclusive = true;
                    }


                    
                    Travel newTravel = travelManager.CreateVacation(destination, countryDestinationString, travellers, isAllInclusive);

                    User user = userManager.SignedInUser as User;
                    user.travels.Add(newTravel);
                }
                else if (cboTripOrVacation.SelectedItem.ToString() == "Trip")
                {
                    
                    if (cboTripType.SelectedItem == null)
                    {
                        MessageBox.Show("Please select what trip type this will be.");
                    }
                    
                    //Create trip
                    string type = cboTripType.SelectedItem.ToString();
                    TripType triptype = (TripType)Enum.Parse(typeof(TripType), type);
                    Travel newTrip = travelManager.CreateTrip(destination, countryDestinationString, travellers, triptype);


                    User user = userManager.SignedInUser as User;
                    user.travels.Add(newTrip);
                }
                else
                {
                    //Error
                    MessageBox.Show("Error please try again");
                }
                Close();
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

            this.selectedTravelType = cboTripOrVacation.SelectedItem.ToString();

            if (this.selectedTravelType == "Trip")
            {
                cboTripType.Visibility = Visibility.Visible;
                chboAllInclusive.Visibility = Visibility.Hidden;
                lblWorkOrLeisure.Visibility = Visibility.Visible;
            }
            else if (this.selectedTravelType == "Vacation")
            {
                cboTripType.Visibility = Visibility.Hidden;
                chboAllInclusive.Visibility = Visibility.Visible;
            }
        }

    }
}
