using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestsData;

namespace DevLearn.Data
{
    public class LectureData
    {


        public int IdLecture { get; set; }
        public Author Author { get; set; }
        public DateTime AddedDate { get; set; }

    }
}
