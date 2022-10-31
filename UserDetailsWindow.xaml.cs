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
        private UserManager userManager;
        private User user;

        public UserDetailsWindow(UserManager userManager, User user)
        {
            this.userManager = userManager;
            this.user = user;

            InitializeComponent();


            //Show details of the user
            lblUsername.Content = user.Username;
            lblPassword.Content = user.Password;
            lblCountry.Content = user.Location;
            
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            TravelWindow travelWindow = new(userManager);
            travelWindow.Show();
            Close();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            //Make the textboxes editeable
        }
    }
}
