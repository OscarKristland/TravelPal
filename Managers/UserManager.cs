using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        /// 
        /// 
        /// 
        /// </summary>

        public List<IUser> Users { get; set; } = new();

        public IUser SignedInUser { get; set; }

        public UserManager()
        {
            User albin = new("Gandalf", "password", AllCountries.Sweden);
            Admin admin = new("Admin", "password", AllCountries.Switzerland);

            Trip trip1 = new("Paris", Convert.ToString(AllCountries.France), 3, TripType.Work);
            albin.travels.Add(trip1);
            Vacation vacation1 = new("Stockholm", Convert.ToString(AllCountries.Sweden), 8, true);
            albin.travels.Add(vacation1);
            
            Users.Add(admin);
            Users.Add(albin);
        }

        //method that returns all users
        public List<IUser> GetAllUsers()
        {
            return Users;
        }

        //Method that adds a user
        public bool AddUser(IUser newUser)
        {
            if (ValidateUsername(newUser.Username) == true)
            {
                //If true, create user
                Users.Add(newUser);
                return true;
            }
            else
            {
                //False dont create new user
                return false;
            }

        }

        //Method to remove a user
        public void RemoveUser(IUser user)
        {
            Users.Remove(user);
        }
        //Updates the username when edited
        public bool UpdateUsername(IUser userUpdate, string newUsername)
        {
            if (!ValidateNewUsername(newUsername))
            {
                return false;
            }

            userUpdate.Username = newUsername;

            return true;
        }
        //Updates the password when edited
        public bool UpdatePassword(IUser userUpdate, string newPassword)
        {
            if (!ValidateNewPassword(newPassword))
            {
                return false;
            }

            userUpdate.Password = newPassword;

            return true;
        }
        //Updates the country when edited
        public void UpdateCountry(IUser userUpdate, AllCountries location)
        {
            userUpdate.Location = location;
        }

        //Check if new username already exists
        public bool ValidateNewUsername(string newUsername)
        {
            foreach (IUser user in Users)
            {
                if (user.Username == newUsername)
                {
                    MessageBox.Show("Username is taken");
                    return false;
                }
            }

            return true;
        }

        //Check if it's a new password when we're updating it
        public bool ValidateNewPassword(string newPassword)
        {
            foreach (IUser user in Users)
            {
                if (user.Password == newPassword)
                {
                    return false;
                }
            }
            return true;
        }

        //checking if the username is taken
        private bool ValidateUsername(string username)
        {
            foreach(IUser user in Users)
            {
                if (user.Username == username)
                {
                    MessageBox.Show("Username is taken");
                    return false;
                }
            }
            return true;
        }

        //signs the user in
        public bool SignInUser(string username, string password)
        {

            foreach (User user in Users)
            {
                if (user.Username == username && user.Password == password)
                {

                    SignedInUser = user;
                    // Logga in
                    return true;

                }
                
            }
            return false;
        }
    }
}
