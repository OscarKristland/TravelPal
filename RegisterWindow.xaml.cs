using System;
using System.Collections.Generic;
using System.Data;
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

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// Register window where the user has to input a username longer than 3 letters
    /// and a password longer than 5 letters.
    /// 
    /// TODO
    /// 
    /// Make the register only work if pass and username is longer than 3 and 5 letters
    /// Make it go back to mainwindow for  both cancel and register
    /// 
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private UserManager userManager;

        public RegisterWindow(UserManager userManager)
        {
            InitializeComponent();
            this.userManager = userManager;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;


            string[] country = Enum.GetNames(typeof(AllCountries));

            foreach (string var in country)
            {
                cbCountry.Items.Add(country);
            }
        }


        //If you don't want to register you can click cancel, should be sent back to main window
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //Closer this window and go back to the main window
            
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }

        //This should take you to back to the mainwindow again and make you either log in or register again
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if(String.IsNullOrEmpty(txtUsername.Text) || String.IsNullOrEmpty(txtPassword.Text) || String.IsNullOrEmpty(txtConfirmPassword.Text))
            {

                //txtUsername.Text == || txtPassword.Text == "" || txtConfirmPassword.Text == ""
                //Trim
                //shouldn't work to set it as empy
                MessageBox.Show("Please enter a valid username//password or the confirm password and password do not align");


               
            }
            else if (txtUsername.Text.Length < 3)
            {
                //if length > 3 = can't log in either
                MessageBox.Show("Please enter a longer username");
            }
            else if (txtPassword.Text.Length < 5)
            {
                //if length > 5 = can't log in either
                MessageBox.Show("Please enter a longer password");
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                //The passwords are not the same
                MessageBox.Show("Please align the passwords");
            }
            else
            {
                //User is added to a list with their individual username and password
                this.userManager.AddUser(username, password);

                MainWindow mainWindow = new(userManager);
                mainWindow.Show();

                Close();
            }

            
        }
    }
}
