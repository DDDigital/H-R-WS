using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H_R_WS.Models
{
    public class Image
    {
        //Модель зображень
        public string ID { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string ImageUrl { get; set; }
        public string FilePath { get; set; }

    }
}
