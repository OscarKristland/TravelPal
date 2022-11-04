using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Models
{
    public class Trip: Travel
    {
        public TripType Type { get; set; }

        public Trip(string destination, string countries, int travellers, TripType type) : base(destination, countries, travellers)
        {
            Destination = destination;
            Countries = countries;
            Travellers = travellers;
            Type = type;
        }

        public override string GetInfo()
        {
            //Denna metod ska visa infon som gör att en resa är en trip
            //Returnera all info
            return $"Destination: {Destination}        Country: {Countries}        Travellers: {Travellers}        Type: {Type} ";
        }
    }
}
