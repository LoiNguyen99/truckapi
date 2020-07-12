using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace truckapi.Models
{
    public class User
    {
        public String UserId { get; set; }
        public String FullName { get; set; }
        public String Password { get; set; }
        public String PhoneNumber { get; set; }
        public String Gender { get; set; }
        public String DateOfBirth { get; set; }
        public String ImagePath { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public List<Request> Requests { get; set; }
        public List<CommodityOwner> CommodityOwners { get; set; }
        public List<Reciver> Recivers { get; set; }
        public List<Quotation> Quotations { get; set; }
    }
}
