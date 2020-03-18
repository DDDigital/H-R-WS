using H_R_WS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using H_R_WS.ViewModels;

namespace H_R_WS.ViewModels
{
    public class AddImagesViewModel
    {
        public List<string> UploadErrors { get; set; }
        public List<Image> AddedImages { get; set; }
    }
}
