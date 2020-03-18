using H_R_WS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.ViewModels
{
    public class SelectedRoomFeatureViewModel
    {
        public string FeatureID { get; set; }
        public virtual Feature Feature { get; set; }
        public bool Selected { get; set; }
    }
}
