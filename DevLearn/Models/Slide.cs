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

        [Required(ErrorMessage = "Information is required")]
        public string Information { get; set; }
    }
}
