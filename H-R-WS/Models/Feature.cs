using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.Models
{
    //Модель особливостей
    public class Feature
    {
        public virtual ICollection<RoomFeature> Rooms { get; set; }
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }

    }
}
