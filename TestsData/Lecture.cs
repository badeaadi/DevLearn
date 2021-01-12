using System;
using System.Collections.Generic;
using System.Text;

namespace TestsData
{
    public class Lecture
    {
        public ICollection<Slide> Slides { get; set; }
        public Author Author { get; set; }

        public DateTime AddedDate {get; set;}


    }
}
