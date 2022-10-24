﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interface;

namespace TravelPal.Managers
{/// <summary>
/// User
/// They need to have a username and password,
/// Data that is to be saved to the individual user is travel data. IE, destinations added in the TravelManager
/// </summary>
    public class User: IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        //public List<Travel> travels = new();
      
    }
}
