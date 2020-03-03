using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.Models
{
    public class Feature
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<RoomFeature> Rooms { get; set; }
    }
}
