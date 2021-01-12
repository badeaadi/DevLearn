using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TestsData
{
    public class Author
    {
        [Key]
        [Column("IdAuthor")]
        public int IdAuthor { get; set; }
        
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        public ICollection<Lecture> Lectures { get; set; }
        //public virtual TestsDataInfo TestsDataInfo {get; set;}

    }
}