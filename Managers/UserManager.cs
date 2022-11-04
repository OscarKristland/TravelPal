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
            //TravelManager.CreateTrip(paris);

            //Trip trip = new(destination, countryDestinationString, travellers, TripType.Work);


            
            Users.Add(admin);
            Users.Add(albin);
        }

        public List<IUser> GetAllUsers()
        {
            return Users;
        }

        //public bool AddUser(string username, string password, AllCountries location)
        //{
        //      ValidateUsername(username);
        //      User user = new(username, password, location);
        //      Users.Add(user);
        //
        //
        //}

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
                //ValidateUsername(newUsername.Username) == false
                //False dont create new user
                return false;
            }

        }

        public void RemoveUser(IUser user)
        {
            Users.Remove(user);
        }

        

        public bool UpdateUsername(IUser user, string newUsername)
        {
           if (ValidateUsername(newUsername) == true)
           {
                return true;
                //its updated if true

           }
           return false;
        }

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

        public bool SignInUser(string username, string password)
        {

            //return smth??????
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
