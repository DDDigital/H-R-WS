﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.Models
{
    //Модель особливостей
    public class Feature
    {
        public virtual ICollection<RoomFeature> Rooms { get; set; }
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }

    }
}
