using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace truckapi.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public String StreetName { get; set; }

        public ICollection<Place> Places { get; set; }
    }
}
