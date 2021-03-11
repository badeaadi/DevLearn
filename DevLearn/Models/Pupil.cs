using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevLearn.Models
{
    public class Pupil
    {
        [Key]
        [Required]
        public int IdPupil{ get; set; }


        [Required(ErrorMessage = "Username is required")]
        public String Username { get; set; }


        [Required]
        [RegularExpression(@"^.*(?=.{6,18})(?=.*\d)(?=.*[A-Za-z])(?=.*[@%&#]{0,}).*$", ErrorMessage = "Password doesn't meet the requirements")]
        public String Password { get; set; }

        public int SolvedProblems { get; set; }
    }
}
