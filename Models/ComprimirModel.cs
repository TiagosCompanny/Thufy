using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Thufy.Models
{
    public class ComprimirModel
    {
        [Required]
        public HttpPostedFileBase InputFile { get; set; }

        [Required]
        public int CompressionType { get; set; }
        
    }
}