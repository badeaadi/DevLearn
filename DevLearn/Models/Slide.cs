using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DevLearn.Models
{
    public class Slide
    {
        [Key]
        public int IdSlide { get; set; }

        public int LectureIdLecture { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]

        public string Description { get; set; }
    }
}
