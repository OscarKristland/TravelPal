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
        public List<Travel> Travels { get; set; } = new();


        //adds travel
        public void AddTravel(Travel travel)
        {
            //Method to create a travel destination

            
            Travels.Add(travel);
            

        }


        //Method to create a trip
        public Travel CreateTrip(string destination, string country, int travellers, TripType type)
        {
            //Innehåll med trip specific info som leisure eller work

            Trip trip = new(destination, country, travellers, type);
            AddTravel(trip);

            return trip;
        }

        //Method to create a vacation
        public Travel CreateVacation(string destination, string country, int travellers, bool allInclusive)
        {
            //Innehåll med vacation specific info, som allinclusive eller ej

            Vacation vacation = new(destination, country, travellers, allInclusive);
            AddTravel(vacation);

            return vacation;
        }

        //Method to remove a travel
        public void RemoveTravel(Travel travel)
        {
            //ta bort en resa
            Travels.Remove(travel);
        }
    }
}
