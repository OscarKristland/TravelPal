using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interface;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public class UserManager : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        private List<User> users = new();

        public UserManager()
        {
            User albin = new();
            albin.Username = "Gandalf";
            albin.Password = "password";
            users.Add(albin);
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public void AddUser(string username, string password)
        {
            User user = new();
            user.Username = username;
            user.Password = password;

            users.Add(user);
        }
    }
}
