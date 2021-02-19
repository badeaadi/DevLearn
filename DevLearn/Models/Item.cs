﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestsData
{
    public class Item
    {
        [Key]
        public int IdItem { get; set; }
        public string ItemInformation { get; set; }

        public ICollection<Variant> Variants { get; set; }

        [Required(ErrorMessage = "Solution is required")]
        public int RightVariant { get; set; }

    }
}