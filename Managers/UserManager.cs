using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TravelPal.Countries;
using TravelPal.Interface;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public class UserManager
    {
        /// <summary>
        /// 
        /// TODO
        /// Fixa så att gandalf kan logga in
        /// 
        /// 
        /// </summary>

        private List<User> users = new();

        public IUser SignedInUser { get; set; }

        public UserManager()
        {
            User albin = new("Gandalf", "password", AllCountries.Sweden);

            users.Add(albin);
            //users.Add(albin);
            //SignedInUser = albin;

            User admin = new("admin", "admin", AllCountries.Switzerland);
            users.Add(admin);
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public void AddUser(string username, string password, AllCountries location)
        {
            User user = new(username, password, location);

            users.Add(user);
        }
    }
}
