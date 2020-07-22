using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace truckapi.Models
{
    public class Journey
    {
        public int JourneyId { get; set; }
        public int DepartAddressId { get; set; }
        public int EndAddressId { get; set; }

        public String UserId { get; set; }

        public DateTime DepartDate { get; set; }

        public Address DepartAddress { get; set; }
        public Address EndAddress { get; set; }
        public User User { get; set; }

    }
}
