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
using TravelPal.Interface;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for TravelWindow.xaml
    /// 
    /// TODO
    /// Info knappen ska ha mer skrivet till sig Typ Visit travelpalbyboat.com to get more info
    /// Remove knappen
    /// 
    /// 
    /// </summary>
    public partial class TravelWindow : Window
    {
        public TravelManager travelManager;
        private UserManager userManager;
        private User user;
        private Admin admin;
        public List<Travel> Travels { get; }




        public TravelWindow(UserManager userManager, TravelManager travelManager)
        {
            InitializeComponent();
            this.travelManager = travelManager;
            this.userManager = userManager;
            
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            

            if (userManager.SignedInUser is User)
            {
                this.user = userManager.SignedInUser as User;
                
            }
            else if(userManager.SignedInUser is Admin)
            {
                
                
            }

            DisplayTravels();
            lblUsername.Content = userManager.SignedInUser.Username;
        }


        //displays travels depending on if it's a user or an admin
        private void DisplayTravels()
        {
            lvAddedTravels.Items.Clear();


            if(userManager.SignedInUser is User)
            {
                // Visa resor från användarens lista
                foreach (Travel travel in this.user.travels)
                {
                    ListViewItem item = new();

                    item.Content = travel.GetInfo();
                    item.Tag = travel;

                    lvAddedTravels.Items.Add(item);

                }
            }
            else if(userManager.SignedInUser is Admin)
            {
                // Visa resor från TravelManager
                foreach (Travel travel in this.travelManager.Travels)
                {
                    ListViewItem item = new();

                    item.Content = travel.GetInfo();
                    item.Tag = travel;

                    lvAddedTravels.Items.Add(item);

                }
            }



        }
        //the user is signed out
        private void btnSignout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(this.userManager, this.travelManager);
            mainWindow.Show();
            this.userManager.SignedInUser = null;
            Close();
        }

        //The info button where it only says to visit the travelpal website
        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("Please visit www.TravelPalByBoat.com for more info on how to use this app");
        }

        //User clicks on Account info and gets a new window that shows details of their account.
        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            UserDetailsWindow userDetailsWindow = new(userManager, travelManager);
            userDetailsWindow.Show();
            Close();
        }

        //Opens a new window that shows information on the selected travel from the listview
        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = lvAddedTravels.SelectedItem as ListViewItem;

            if (selectedItem == null)
            {
                AddTravelWindow addTravelWindow = new(userManager, travelManager);
                addTravelWindow.Show();
            }
            else
            {
                Travel selectedTravel = selectedItem.Tag as Travel;

                TravelDetails travelDetails = new(userManager, travelManager, selectedTravel);
                travelDetails.Show();
            }
        }

        //If clicked by the user, they are taken to the addtravelwindow where they can add travels for themselves.
        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {

            if (userManager.SignedInUser is User)
            {
                
                AddTravelWindow addTravelWindow = new(userManager, travelManager);
                addTravelWindow.ShowDialog();

                DisplayTravels();
            }
            else if (userManager.SignedInUser is Admin)
            {

                MessageBox.Show("You're the admin why would u wanna add a travel? You don't even have your own list");
            }

            

        }

        //removes the selected travel from the listview as well as from the users travel list
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem selectedItem = lvAddedTravels.SelectedItem as ListViewItem;
            

            if (selectedItem == null)
            {
                MessageBox.Show("Please select a trip to remove");
            }
            else if(userManager.SignedInUser is User)
            {
                Travel removeTravel = selectedItem.Tag as Travel;
                ((User)userManager.SignedInUser).travels.Remove(removeTravel);
                travelManager.RemoveTravel(removeTravel);
            }
            else if (userManager.SignedInUser is Admin)
            {
                Admin admin = (Admin)userManager.SignedInUser;
                Travel removeTravel = selectedItem.Tag as Travel;
                foreach (IUser user in userManager.Users)
                {
                    if (user is User)
                    {
                        bool found = false;
                        foreach (Travel travel in ((User)user).travels)
                        {
                            if(travel == removeTravel)
                            {
                                found = true;
                            }

                        }
                        if (found)
                        {
                            ((User)user).travels.Remove(removeTravel);
                            break;
                        }

                    }
                }
                travelManager.RemoveTravel(removeTravel);
                
            }
            DisplayTravels();
        }
    }
}
