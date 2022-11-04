using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Models
{
    public class Travel
    {
        public string Destination { get; set; }
        public string Countries { get; set; }
        public int Travellers { get; set; }

        public Travel(string destination, string countries, int travellers)
        {
            Destination = destination;
            Countries = countries;
            Travellers = travellers;
        }

        //Shows info on the travel
        public virtual string GetInfo()
        {   
            return $"Destination: {Destination} Country: {Countries} Travellers: {Travellers}";
        }
    }
}
