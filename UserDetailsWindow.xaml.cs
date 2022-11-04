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
using TravelPal.Interface;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for UserDetailsWindow.xaml
    /// 
    /// TODO
    /// Function to edit account info
    /// 
    /// 
    /// </summary>
    public partial class UserDetailsWindow : Window
    {
        public TravelManager travelManager;
        private UserManager userManager;
        private IUser user;

        public UserDetailsWindow(UserManager userManager, TravelManager travelManager)
        {
            this.userManager = userManager;
            this.travelManager = travelManager;
            this.user = this.userManager.SignedInUser;
            
            InitializeComponent();

            lblnewUsername.Visibility = Visibility.Hidden;
            lblnewPassword.Visibility = Visibility.Hidden;
            lblnewConfirmPassword.Visibility = Visibility.Hidden;
            lblnewCountry.Visibility = Visibility.Hidden;
            txtnewUsername.Visibility = Visibility.Hidden;
            txtnewPsword.Visibility = Visibility.Hidden;
            txtnewConfirmPassword.Visibility = Visibility.Hidden;
            cbCountry.Visibility = Visibility.Hidden;
            Save.Visibility = Visibility.Hidden;

            //Show details of the user
            lblUsername.Content = user.Username;
            lblPassword.Content = user.Password;
            lblCountry.Content = user.Location;
        }
        //Returns the user to the travelwindow
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            TravelWindow travelWindow = new(this.userManager, this.travelManager);
            travelWindow.Show();
            Close();
        }


        //Make the textboxes editeable
        private void edit_Click(object sender, RoutedEventArgs e)
        {

            lblnewUsername.Visibility = Visibility.Visible;
            lblnewPassword.Visibility = Visibility.Visible;
            lblnewConfirmPassword.Visibility = Visibility.Visible;
            lblnewCountry.Visibility = Visibility.Visible;
            txtnewUsername.Visibility = Visibility.Visible;
            txtnewPsword.Visibility = Visibility.Visible;
            txtnewConfirmPassword.Visibility = Visibility.Visible;
            cbCountry.Visibility = Visibility.Visible;
            Save.Visibility = Visibility.Visible;

            //Loading the combobox with items from the enum AllCountries
            cbCountry.ItemsSource = Enum.GetNames(typeof(AllCountries));
            cbCountry.SelectedIndex = (int)user.Location;
        }

        //Saves the edits that the user wants to do to their own account
        private void Save_Click(object sender, RoutedEventArgs e)
        {

            string locationString = cbCountry.SelectedItem as string;
            AllCountries location = (AllCountries)Enum.Parse(typeof(AllCountries), locationString);

            string newUsername = txtnewUsername.Text;
            string newPassword = txtnewPsword.Text;
            

            if (txtnewPsword.Text != userManager.SignedInUser.Password && txtnewUsername.Text != userManager.SignedInUser.Username)
            {
                userManager.UpdatePassword(userManager.SignedInUser, newPassword);
                userManager.UpdateUsername(userManager.SignedInUser, newUsername);
                userManager.UpdateCountry(userManager.SignedInUser, location);

            }
            else if (txtnewPsword.Text != txtnewConfirmPassword.Text)
            {
                //The passwords are not the same
                MessageBox.Show("Please align the passwords");
            }
            else if (txtnewPsword.Text.Length < 5 && txtnewPsword.Text.Length > 1)
            {
                //if length > 5 = can't create a new one
                MessageBox.Show("Please enter a longer password");
            }
            else if (String.IsNullOrEmpty(txtnewUsername.Text) || String.IsNullOrEmpty(txtnewPsword.Text) || String.IsNullOrEmpty(txtnewConfirmPassword.Text))
            {
                //shouldn't work to set it as empy
                MessageBox.Show("You have not chosen to edit anything, please do before continuing");

            }
            else if (txtnewUsername.Text.Length < 1 && txtnewUsername.Text.Length > 1)
            {
                //if length > 3 = can't create a new username
                MessageBox.Show("Please enter a longer username");
            }
            else
            {
                TravelWindow travelWindow = new(userManager, travelManager);
                travelWindow.Show();
                Close();
            }
        }
    }
}
