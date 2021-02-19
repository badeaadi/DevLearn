using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestsData
{
    class User
    {
        [Key]
        public string Mail { get; set; }
        public string Name { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
