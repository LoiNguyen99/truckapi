using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace truckapi.Models
{
    public class Request
    {

        public int RequestId { get; set; }
        public String CommodityName { get; set; }
        public float Weight { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime ValidDate { get; set; }
        public String Status { get; set; }

        public String UserId { get; set; }

        public User user { get; set; }

        public ICollection<Quotation> quotations { get; set; }


    }
}
