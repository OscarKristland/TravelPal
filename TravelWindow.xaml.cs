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
    /// Interaction logic for TravelWindow.xaml
    /// 
    /// TODO
    /// Info knappen ska ha mer skrivet till sig om hur man använder systemet med att lägga till travel och hela det köret
    /// 
    /// </summary>
    public partial class TravelWindow : Window
    {
        private UserManager userManager;
        private User user;
       

        public TravelWindow(UserManager userManager)
        {
            
            this.userManager = userManager;

            if(userManager.SignedInUser is User)
            {
                this.user = userManager.SignedInUser as User;
            }

            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            lblUsername.Content = user.Username;
        }

        private void btnSignout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(userManager);
            mainWindow.Show();

            Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            //Show some great info
        }

        //User clicks on Account info and gets a new window that shows details of their account.
        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new(userManager, user);
            userDetailsWindow.Show();
            Close();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            // window showing all sorts of stuff
            //Should be a window that shows up with already locked in information.
            //the info should have been filled in from the "addtravelwindow"
            //Ska user och usermanager skickas med? Eller båda?
            //The window that this clickevent should be linked needs to have an "edit"-button
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            //If clicked the item should have
            AddTravelWindow addTravelWindow = new(userManager);
            addTravelWindow.Show();
        }
    }
}
