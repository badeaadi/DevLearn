using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevLearn.Models
{
    public class Problem
    {

        [Key]
        [Required]
        public int IdProblem { get; set; }
        
        public Lecture ProblemLecture { get; set; }

        [Required]
        [MaxLength(250)]
        
        public String Link { get; set; }
        [Range(0, 10)]
        
        public int Dificultate { get; set; }
    }
}
