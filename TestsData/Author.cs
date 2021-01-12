using System;
using System.Collections.Generic;
using System.Text;

namespace TestsData
{
    public class Author
    {
        public int IdAuthor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public ICollection<Lecture> Lectures { get; set; }
        //public virtual TestsDataInfo TestsDataInfo {get; set;}

    }
}