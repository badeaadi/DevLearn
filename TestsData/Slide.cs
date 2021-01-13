using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestsData
{
    public class Slide
    {
        [Key]
        public int IdSlide { get; set; }

        [Required]
        public string Information { get; set; }


    }
}
