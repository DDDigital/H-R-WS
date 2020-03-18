using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.Models
{
    //Модель бронювання кімнати
    public class Booking
    {
        public string ID { get; set; }
        public string RoomID { get; set; } //Ідентифікатор кімнати
        public virtual Room Room { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CheckIn { get; set; } //Дата заїзду
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CheckOut { get; set; } //Дата виїзду
        public int Guests { get; set; } //Гості
        public decimal TotalFee { get; set; }
        public bool Paid { get; set; }
        public bool Completed { get; set; }
        public Guid ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        public string CustomerName { get; set; } //Дані замовника
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public string CustomerPhone { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        [Required]
        public string CustomerCity { get; set; }
        public string OtherRequests { get; set; }

    }
}
