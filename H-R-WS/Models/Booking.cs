﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.Models
{
    public class Booking
    {
        public string ID { get; set; }
        public string RoomID { get; set; }
        public virtual Room Room { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int Guests { get; set; }
        public decimal TotalFee { get; set; }
        public bool Paid { get; set; }
        public bool Completed { get; set; }
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string OtherRequests { get; set; }
    }
}
