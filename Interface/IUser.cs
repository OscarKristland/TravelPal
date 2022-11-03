using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Countries;
using TravelPal.Managers;

namespace TravelPal.Interface
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public AllCountries Location { get; set; }
        
    }
}
