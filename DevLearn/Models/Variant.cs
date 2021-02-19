using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestsData
{
    public class Variant
    {   
        [Key]
        public int IdVariant { get; set; }
        public string VariantInformation { get; set; }
    }
}
