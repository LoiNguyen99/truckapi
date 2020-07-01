﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace truckapi.Models
{
    public class Reciver
    {
        public int ReciverId { get; set; } 
        public String FullName { get; set; }
        public String PhoneNumber { get; set; }

        public Address Address { get; set; }

        public List<Request> Requests { get; set; }

    }
}
