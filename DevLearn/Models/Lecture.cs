using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestsData
{
    public class Lecture
    {
        [Key]
        [Required]
        public int IdLecture {get;set;}
        public ICollection<Slide> Slides { get; set; }
        
        [Required]
        public Author Author { get; set; }
        
        [Required]
        public DateTime AddedDate {get; set;}


    }
}
