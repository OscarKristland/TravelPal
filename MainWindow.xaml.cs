﻿using System;
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
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserManager userManager = new();

        public MainWindow()
        {
            InitializeComponent();

            this.userManager = new();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public MainWindow(UserManager userManager)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.userManager = userManager;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new(userManager);
            registerWindow.Show();
            Close();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            List<User> users = userManager.GetAllUsers();

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            bool isFoundUser = false;

            foreach (User user in users)
            {
                if (user.Username == username && user.Password == password)
                {
                    // Logga in
                    isFoundUser = true;

                        //Show a user window
                    userManager.SignedInUser = user;
                    TravelWindow travelWindow = new(userManager);
                    travelWindow.Show();
                    Close();
                }
            }

            //If user isn't found this message pops up.
            if (!isFoundUser)
            {
                MessageBox.Show("Username or password is incorrect", "Warning");
            }

        }
    }
}
