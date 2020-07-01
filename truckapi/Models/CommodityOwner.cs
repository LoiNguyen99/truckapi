using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace truckapi.Models
{
    public class CommodityOwner
    {
        public int CommodityOwnerId { get; set; } 
        public String FullName { get; set; }
        public String PhoneNumber { get; set; }
        public int AddressId { get; set; }

        public Address Address { get; set; }

        public List<Request> Requests { get; set; }

    }
}
