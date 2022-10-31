using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Countries;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public class TravelManager
    {
        public List<Travel> travels = new();

        public void AddTravel(string destination,string tripOrVacation,int passengers, AllCountries countryDestination, string tripType)
        {
            //Method to create a travel destination
            
        }
        //Ska få med från user och därmed usermanager?
        //+ travels: List<Travel>

        //+ addTravel(Travel): void
        //+ removeTravel(Travel) : void
        public void RemoveTravel()
        {
            //ta bort en resa
        }
    }
}
