using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.Models
{
    public class Room
    {

        public string ID { get; set; }
        public int Number { get; set; }
        public string RoomTypeID { get; set; }
        public virtual RoomType RoomType { get; set; }
        public decimal Price { get; set; }
        public bool Available { get; set; }
        public string Description { get; set; }
        public int MaximumGuests { get; set; }
  
        public virtual List<Image> RoomImages { get; set; }
        public virtual List<Review> Reviews { get; set; }
        public virtual List<Booking> Bookings { get; set; }



        public virtual ICollection<RoomFeature> Features { get; set; }
    }
}
