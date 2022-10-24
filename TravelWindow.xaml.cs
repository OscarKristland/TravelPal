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
    /// </summary>
    public partial class TravelWindow : Window
    {
        private UserManager userManager;
        private User user;
       

        public TravelWindow(UserManager userManager, User user)
        {
            
            this.userManager = userManager;
            this.user = user;
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            lbUsername.Content = user.Username;
        }

        private void btnSignout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(userManager);
            mainWindow.Show();

            Close();
        }

        //lbl username . content user . username
    }
}
