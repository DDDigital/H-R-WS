using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.Models
{
    public class RoomFeature
    {
        public string RoomID { get; set; }
        public virtual Room Room { get; set; }

        public string FeatureID { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
