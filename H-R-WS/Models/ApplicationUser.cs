﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.Models
{
    //Модель користувача
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ProfilePic { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}
