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
    /// Interaction logic for TravelWindow.xaml
    /// 
    /// TODO
    /// Info knappen ska ha mer skrivet till sig om hur man använder systemet med att lägga till travel och hela det köret
    /// 
    /// </summary>
    public partial class TravelWindow : Window
    {
        public TravelManager travelManager;
        private UserManager userManager;
        private User user;
        


        //public TravelWindow(UserManager userManager)
        //{
            
        //    this.userManager = userManager;
            

        //    if (userManager.SignedInUser is User)
        //    {
        //        this.user = userManager.SignedInUser as User;
        //    }

        //    InitializeComponent();
        //    WindowStartupLocation = WindowStartupLocation.CenterScreen;
        //    lblUsername.Content = user.Username;

            
        //}

        public TravelWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();
            this.travelManager = travelManager;
            this.userManager = userManager;
            btnRemove.Visibility = Visibility.Hidden;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (userManager.SignedInUser is User)
            {
                this.user = userManager.SignedInUser as User;
            }
            else if(userManager.SignedInUser is Admin)
            {
                
                btnRemove.Visibility = Visibility.Visible;
            }
            else

            
            DisplayTravels();
            lblUsername.Content = user.Username;
        }

        private void DisplayTravels()
        {
            lvAddedTravels.Items.Clear();

            foreach (Travel travel in this.travelManager.Travels)
            {
                ListViewItem item = new();

                item.Content = travel.GetInfo();
                item.Tag = travel;

                lvAddedTravels.Items.Add(item);

            }


        }

        private void btnSignout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(this.userManager, this.travelManager);
            mainWindow.Show();
            this.userManager.SignedInUser = null;
            Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            //Show some great info
            MessageBox.Show("Error");
        }

        //User clicks on Account info and gets a new window that shows details of their account.
        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new(userManager, travelManager);
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
            AddTravelWindow addTravelWindow = new(userManager, travelManager);
            addTravelWindow.Show();
        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {
            //If clicked the item should have
            AddTravelWindow addTravelWindow = new(userManager, travelManager);
            addTravelWindow.ShowDialog();

            DisplayTravels();

        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
