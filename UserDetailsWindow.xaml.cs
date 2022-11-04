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

            //Show details of the user
            lblUsername.Content = user.Username;
            lblPassword.Content = user.Password;
            lblCountry.Content = user.Location;
            
        }

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


            //Loading the combobox with items from the enum AllCountries
            cbCountry.ItemsSource = Enum.GetNames(typeof(AllCountries));
            cbCountry.SelectedIndex = (int)user.Location;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string newUsername = txtnewUsername.Text;
            string newPassword = txtnewPsword.Text;
            string locationString = cbCountry.SelectedItem as string;


            //if (String.IsNullOrEmpty(txtnewUsername.Text) || String.IsNullOrEmpty(txtnewPsword.Text) || String.IsNullOrEmpty(txtnewConfirmPassword.Text))
            //{
            //    //shouldn't work to set it as empy
            //    MessageBox.Show("Please enter a valid username//password or the confirm password and password do not align");

            //}
            if (txtnewUsername.Text.Length < 3 && txtnewUsername.Text.Length > 1)
            {
                //if length > 3 = can't log in either
                MessageBox.Show("Please enter a longer username");
            }
            else if (txtnewPsword.Text.Length < 5 && txtnewPsword.Text.Length > 1)
            {
                //if length > 5 = can't log in either
                MessageBox.Show("Please enter a longer password");
            }
            else if (txtnewPsword.Text != txtnewConfirmPassword.Text)
            {
                //The passwords are not the same
                MessageBox.Show("Please align the passwords");
            }
            else
            {
                AllCountries location = (AllCountries)Enum.Parse(typeof(AllCountries), locationString);
                user.Username = newUsername;
                user.Password = newPassword;
                user.Location = location;


                //User details is updated
                this.userManager.UpdateUsername(userManager.SignedInUser, newUsername);


            }
        }
    }
}
