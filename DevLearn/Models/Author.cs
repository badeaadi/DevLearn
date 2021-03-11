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


        [Required(ErrorMessage ="Name is required")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}