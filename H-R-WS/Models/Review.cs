using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.Models
{
    //Модель відгуків
    public class Review
    {
        public Guid ID { get; set; }
        public string RoomID { get; set; }
        public virtual Room Room { get; set; }
        public string ReviewerName { get; set; }
        public string ReviewerEmail { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

    }
}
