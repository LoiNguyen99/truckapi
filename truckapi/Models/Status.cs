using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace truckapi.Models
{
    public class Status
    {
        public Status()
        {
        }

        public Status(int statusId, string value, String color)
        {
            StatusId = statusId;
            Value = value;
            Color = color;
        }

        public int StatusId { get; set; }
        public String Value { get; set; }

        public String Color { get; set; }
        public List<Request> Requests { get; set; }
    }
}
