using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Models
{
    public class Vacation: Travel
    {
        public bool AllInclusive { get; set; }

        public Vacation(string destination, string countries, int travellers, bool allInclusive) : base(destination, countries, travellers)
        {
            Destination = destination;
            Countries = countries;
            Travellers = travellers;
            AllInclusive = allInclusive;
        }

        //+ allInclusive: bool
        //+ Vacation(allInclusive)
        //+ GetInfo() : string
        public override string GetInfo()
        {
            //Denna metod ska visa infon som gör att en resa är en vacation
            return $"Destination: {Destination} Country: {Countries} Travellers: {Travellers} AllInclusive: {AllInclusive}";
        }
    }
}
