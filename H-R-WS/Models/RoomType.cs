using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.Models
{
    //Модель типів кімнат
    public class RoomType
    {
        
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal BasePrice { get; set; }
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
