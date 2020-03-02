using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.Models
{
    //Модель бронювання кімнати
    public class Booking
    {
        public Guid ID { get; set; }
        public Guid RoomID { get; set; } //Ідентифікатор кімнати
        public virtual Room Room { get; set; }
        public DateTime DateCreated { get; set; } 
        public DateTime CheckIn { get; set; } //Дата заїзду
        public DateTime CheckOut { get; set; } //Дата виїзду
        public int Guests { get; set; } //Гості
        public decimal TotalFee { get; set; }
        public bool Paid { get; set; }
        public bool Completed { get; set; }
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string CustomerName { get; set; } //Дані замовника
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string OtherRequests { get; set; }

    }
}
