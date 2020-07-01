using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace truckapi.Models
{
    public class Place
    {
        public int PlaceId { get; set; }
        public String PlaceName { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; } 

    }
}
