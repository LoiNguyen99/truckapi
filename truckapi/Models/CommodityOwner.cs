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
        public bool IsDefault { get; set; }
        public int AddressId { get; set; }
        public String UserId { get; set; }
        public Address Address { get; set; }
        public User User { get; set; }
        public List<Request> Requests { get; set; }

    }
}
