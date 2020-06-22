using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace truckapi.Models
{
    public class Quotation
    {
        public int QuotationId { get; set; }
        public double Price { get; set; }
        public String Note { get; set; }

        public String DriverId { get; set; }
        public User Driver { get; set; }

        public int RequestId { get; set; }
        public Request Request { get; set; }
    }
}
